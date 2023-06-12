using System;

using System.Collections.Generic;

using System.IO;

class Employee

{

    public string Name { get; set; }

    public string EmployeeType { get; set; }

    public virtual double CalculateSalary()

    {

        return 0; // Base implementation for the salary calculation

    }

}

class Staff : Employee

{

    public override double CalculateSalary()

    {

        return 300; // Specific implementation for staff salary calculation

    }

}

class Intern : Employee

{

    public override double CalculateSalary()

    {

        return 50; // Specific implementation for intern salary calculation

    }

}

class HourlyPaid : Employee

{

    public int HoursWorked { get; set; }

    public double AmountPerHour { get; set; }

    public override double CalculateSalary()

    {

        return HoursWorked * AmountPerHour; // Specific implementation for hourly paid employee salary calculation

    }

}

class CommissionBased : Employee

{

    public int CommissionPercentage { get; set; }

    public int BaseSalary { get; set; }

    public override double CalculateSalary()

    {

        double commissionAmount = (CommissionPercentage / 100.0) * BaseSalary;

        return BaseSalary + commissionAmount; // Specific implementation for commission-based employee salary calculation

    }

}

class EmployeeFactory

{

    public static Employee CreateEmployee(string employeeType)

    {

        switch (employeeType)

        {

            case "Staff":

                return new Staff();

            case "Intern":

                return new Intern();

            case "HourlyPaid":

                return new HourlyPaid();

            case "CommissionBased":

                return new CommissionBased();

            default:

                throw new ArgumentException("Invalid employee type: " + employeeType);

        }

    }

}

class SalaryCalculator

{

    static void Main()

    {

        List<Employee> employees = ReadEmployeeDataFromFile("employees.txt");

        foreach (Employee employee in employees)

        {

            double salary = employee.CalculateSalary();

            Console.WriteLine(employee.Name + "'s average salary is " + salary + "k");

        }

    }

    static List<Employee> ReadEmployeeDataFromFile(string filePath)

    {

        List<Employee> employees = new List<Employee>();

        try

        {

            using (StreamReader reader = new StreamReader(filePath))

            {

                while (!reader.EndOfStream)

                {

                    string line = reader.ReadLine();

                    string[] data = line.Split(',');

                    string employeeType = data[0];

                    string name = data[1];

                    try

                    {

                        Employee employee = EmployeeFactory.CreateEmployee(employeeType);

                        employee.EmployeeType = employeeType;

                        employee.Name = name;

                        // Set additional properties based on the employee type

                        if (employee is HourlyPaid hourlyPaidEmployee)

                        {

                            hourlyPaidEmployee.AmountPerHour = double.Parse(data[2]);

                            hourlyPaidEmployee.HoursWorked = int.Parse(data[3]);

                        }

                        else if (employee is CommissionBased commissionBasedEmployee)

                        {

                            commissionBasedEmployee.BaseSalary = int.Parse(data[2]);

                            commissionBasedEmployee.CommissionPercentage = int.Parse(data[3]);

                        }

                        employees.Add(employee);

                    }

                    catch (ArgumentException e)

                    {

                        Console.WriteLine("Invalid employee type in file: " + e.Message);

                    }

                }

            }

        }

        catch (IOException e)

        {

            Console.WriteLine("Error reading the file: " + e.Message);

        }

        return employees;

    }

}


using System;

class SalaryCalculator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the salary calculator");

        Console.WriteLine("Enter the number of employees you want to calculate for:");
        int amountOfEmployees = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < amountOfEmployees; i++)
        {
            Console.WriteLine("Enter the name of the employee:");
            string nameOfEmployee = Console.ReadLine();

            string kindOfStaff;
            bool isValidEmployeeType = false;

            do
            {
                Console.WriteLine("Enter the class of the employee:");
                kindOfStaff = Console.ReadLine();

                string[] employeeTypes = new string[] { "staff", "intern", "hourlypaid", "commissionbased" };

                foreach (string employeeType in employeeTypes)
                {
                    if (kindOfStaff == employeeType)
                    {
                        isValidEmployeeType = true;
                        break;
                    }
                }

                if (!isValidEmployeeType)
                {
                    Console.WriteLine("Invalid employee type! Please enter a valid employee type.");
                }
            } while (!isValidEmployeeType);

            int staffSalary = 300;
            int internSalary = 50;
            int commissionSalary = 70;
            double amountPerHour = 10;

            if (kindOfStaff == "staff")
            {
                Console.WriteLine(nameOfEmployee + "'s average salary is " + staffSalary + "k");
            }
            else if (kindOfStaff == "intern")
            {
                Console.WriteLine(nameOfEmployee + "'s average salary is " + internSalary + "k");
            }
            else if (kindOfStaff == "hourlypaid")
            {
                Console.WriteLine("Enter the number of hours worked:");
                int hours = Convert.ToInt32(Console.ReadLine());

                double hourlySalary = HourlyPaid(amountPerHour, hours);
                Console.WriteLine(nameOfEmployee + "'s average salary is " + hourlySalary + "k");
            }
            else if (kindOfStaff == "commissionbased")
            {
                Console.WriteLine("How much commission was remitted in %?");
                int commissionRemitted = Convert.ToInt32(Console.ReadLine());

                if (commissionRemitted == 0)
                {
                    Console.WriteLine("Since no commission was realized, " + nameOfEmployee + "'s average salary is " + commissionSalary + "k");
                }
                else
                {
                    double commissionSalaryRealized = CommissionBased(commissionRemitted, commissionSalary);
                    Console.WriteLine(nameOfEmployee + "'s average salary is " + commissionSalaryRealized + "k");
                }
            }
        }
    }

    static double HourlyPaid(double amountPerHour, double hours)
    {
        double hourlySalary = amountPerHour * hours;
        return hourlySalary;
    }

    static double CommissionBased(int commissionRemitted, int commissionSalary)
    {
        double commissionRealized = (commissionRemitted / 100.0) * commissionSalary;
        double commissionSalaryRealized = commissionRealized + commissionSalary;
        return commissionSalaryRealized;
    }
}



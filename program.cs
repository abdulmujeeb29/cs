using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter amount of courses offered ");
            int coursesOFFered = Convert.ToInt32(Console.ReadLine());

            string[] courseNames = new string[coursesOFFered];
            int[] courseUnits = new int[coursesOFFered];
            int [] courseGrades = new int[coursesOFFered];


            for (int i = 0; i < coursesOFFered; i++)
            {
                Console.WriteLine(" Enter name of course " + (i + 1) + " : ");
                courseNames[i] = Console.ReadLine();

                Console.WriteLine(" Enter the unit for the course " + ( i + 1) + " : ");
                courseUnits[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter grade for the course " + (i + 1) + " : ");
                courseGrades[i] = Convert.ToInt32(Console.ReadLine());
            }


            double cgpa = calculateCGPA(courseUnits, courseGrades);
            Console.WriteLine("Your gp for this semester is " + cgpa.ToString("0.00"));

            
        }

        static double calculateCGPA(int[] courseUnits, int[] courseGrades )
        {
            int totalUnits = 0;
            double totalGrade = 0;

            for (int i = 0; i < courseUnits.Length; i++ )
            {
                totalUnits += courseUnits[i];
                totalGrade += courseUnits[i] * calculateGrade((int)courseGrades[i]);
            }

            double cgpa = totalGrade / totalUnits;
            return cgpa;
             

        }


        static double calculateGrade(int grade)
        {
            if (grade >= 80 && grade < 100)
                return 5.0;
            else if (grade >= 60 && grade < 80)
                return 4.0;
            else if (grade >= 50 && grade < 60)
                return 3.0;
            else if (grade >= 30 && grade < 50)
                return 2.0;
            else if (grade >= 20 && grade < 30)
                return 1.0;
            else 
                return 0.0;
        }
    }

       
        
}


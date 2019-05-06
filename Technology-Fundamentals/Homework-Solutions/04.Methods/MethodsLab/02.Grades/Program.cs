using System;

namespace grades
{
    class Program
    {
        public static void Main()
        {
            double grade = double.Parse(Console.ReadLine());

            string result = GetGrade(grade);
            Console.WriteLine(result);
        }

        private static string GetGrade(double grade)
        {
            string result = string.Empty;

            if (grade < 3)
            {
                result = "Fail";
            }
            else if (grade < 3.5)
            {
                result = "Poor";
            }
            else if (grade < 4.5)
            {
                result = "Good";
            }
            else if (grade < 5.5)
            {
                result = "Very good";
            }
            else
            {
                result = "Excellent";
            }

            return result;
        }
    }
}

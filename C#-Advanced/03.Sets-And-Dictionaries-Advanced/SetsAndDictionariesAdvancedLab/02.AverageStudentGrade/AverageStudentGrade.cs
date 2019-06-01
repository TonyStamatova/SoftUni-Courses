namespace _02.AverageStudentGrade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AverageStudentGrade
    {
        public static void Main()
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<double>());
                }

                studentGrades[name].Add(grade);
            }

            foreach (var student in studentGrades)
            {
                string grades = GetGradesAsString(student.Value);
                Console.WriteLine(
                    $"{student.Key} -> {grades}(avg: {student.Value.Average():f2})");
            }
        }

        private static string GetGradesAsString(List<double> grades)
        {
            string result = string.Empty;

            foreach (var grade in grades)
            {
                result += $"{grade:f2} ";
            }

            return result;
        }
    }
}

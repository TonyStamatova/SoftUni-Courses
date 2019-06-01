using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.studentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<double>());
                }

                students[student].Add(grade);
            }

            students = students.Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}

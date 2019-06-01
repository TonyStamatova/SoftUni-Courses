using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputArr = input.Split(" : ");
                string courseName = inputArr[0];
                string studentName = inputArr[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);

                input = Console.ReadLine();
            }

            courses = courses.OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                item.Value.Sort();
                foreach (var student in item.Value)
                {
                    Console.WriteLine("-- " + student);
                }
            }
        }
    }
}

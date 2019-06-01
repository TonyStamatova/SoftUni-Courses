using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Student student = new Student(input[0], input[1], double.Parse(input[2]));
                students.Add(student);
            }

            students.Sort((x, y) => y.Grade.CompareTo(x.Grade));
            Console.WriteLine(string.Join(Environment.NewLine, students));
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
}

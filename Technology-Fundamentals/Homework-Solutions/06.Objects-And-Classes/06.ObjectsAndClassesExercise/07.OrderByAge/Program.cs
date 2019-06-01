using System;
using System.Collections.Generic;

namespace _07.orderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> people = new List<Person>();

            while (input != "End")
            {
                string[] array = input.Split();
                string name = array[0];
                string id = array[1];
                int age = int.Parse(array[2]);
                Person newPerson = new Person(name, id, age);
                people.Add(newPerson);
                input = Console.ReadLine();
            }

            people.Sort((x, y) => x.Age.CompareTo(y.Age));
            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}

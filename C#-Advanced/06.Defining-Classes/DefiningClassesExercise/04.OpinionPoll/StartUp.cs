namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person newPerson = new Person(name, age);
                people.Add(newPerson);
            }

            people = people
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();

            people.ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
        }
    }
}

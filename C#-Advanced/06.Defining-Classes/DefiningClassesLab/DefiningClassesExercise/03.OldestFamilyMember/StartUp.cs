namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Family family = new Family();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person newPerson = new Person(name, age);
                family.AddMember(newPerson);
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}

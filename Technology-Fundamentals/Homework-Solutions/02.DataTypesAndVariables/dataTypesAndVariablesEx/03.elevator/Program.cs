using System;

namespace _03.elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleToLift = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int remainder = default(int);

            if (peopleToLift % capacity > 0)
            {
                remainder = 1;
            }

            int courses = peopleToLift / capacity + remainder;
            Console.WriteLine(courses);
        }
    }
}

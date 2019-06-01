namespace PrintEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PrintEvenNumbers
    {
        public static void Main()
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int count = numbers.Count;

            for (int i = 0; i < count; i++)
            {
                int number = numbers.Dequeue();

                if (number % 2 == 0)
                {
                    numbers.Enqueue(number);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}

namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeriodicTable
    {
        public static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            var elements = new SortedSet<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine().Split();

                for (int j = 0; j < input.Length; j++)
                {
                    elements.Add(input[j]);
                }
            }
            
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}

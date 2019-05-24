namespace _01.CountSameValuesInArray
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CountSameValuesInArray
    {
        public static void Main()
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> elements = new Dictionary<double, int>();

            foreach (var number in input)
            {
                if (!elements.ContainsKey(number))
                {
                    elements.Add(number, 1);
                }
                else
                {
                    elements[number]++;
                }
            }

            foreach (var element in elements)
            {
                Console.WriteLine($"{element.Key} - {element.Value} times");
            }
        }
    }
}

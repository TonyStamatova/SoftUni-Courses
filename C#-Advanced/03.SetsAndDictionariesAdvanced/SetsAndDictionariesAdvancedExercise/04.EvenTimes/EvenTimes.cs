namespace _04.EvenTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EvenTimes
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            var elements = new Dictionary<string, int>();

            for (int i = 0; i < count; i++)
            {
                var newElement = Console.ReadLine();

                if (!elements.ContainsKey(newElement))
                {
                    elements.Add(newElement, 0);
                }

                elements[newElement]++;
            }

            var desiredElement = elements
                .FirstOrDefault(x => x.Value % 2 == 0)
                .Key;

            Console.WriteLine(desiredElement);
        }
    }
}

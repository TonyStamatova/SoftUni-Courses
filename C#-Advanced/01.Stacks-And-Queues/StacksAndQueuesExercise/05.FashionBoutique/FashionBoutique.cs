namespace _05.FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FashionBoutique
    {
        public static void Main()
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            int capacity = int.Parse(Console.ReadLine());

            int sum = default(int);
            int racks = 1;

            while (clothes.Count > 0)
            {
                
                int diff = capacity - sum;
                if (clothes.Peek() <= diff)
                {
                    sum += clothes.Pop();
                }
                else
                {
                    sum = 0;
                    racks++;
                }
            }

            Console.WriteLine(racks);
        }
    }
}

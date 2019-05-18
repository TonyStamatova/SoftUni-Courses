namespace _04.FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FastFood
    {
        public static void Main()
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                if (orders.Peek() <= foodQuantity)
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}

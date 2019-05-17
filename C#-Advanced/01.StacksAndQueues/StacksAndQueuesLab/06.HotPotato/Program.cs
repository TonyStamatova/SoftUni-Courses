namespace _06.HotPotato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine()
                .Split());
            int tosses = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                for (int i = 1; i < tosses; i++)
                {
                    string kidName = kids.Dequeue();
                    kids.Enqueue(kidName);
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}

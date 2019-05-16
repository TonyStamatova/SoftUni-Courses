namespace _05.Supermarket
{
    using System;
    using System.Collections.Generic;

    public class Supermarket
    {
        public static void Main()
        {
            Queue<string> queue = new Queue<string>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while(queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}

namespace _02.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int dequeueCount = input[1];

            for (int i = 0; i < dequeueCount; i++)
            {
                queue.Dequeue();
            }

            int elementToFind = input[2];

            if (queue.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Count > 0 ? queue.Min() : 0);
            }
        }
    }
}

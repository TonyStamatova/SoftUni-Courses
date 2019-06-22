namespace _04.TheKitchen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Stack<int> knives = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Queue<int> forks = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            List<int> sets = new List<int>();

            while (knives.Count > 0 && forks.Count > 0)
            {
                int currentKnife = knives.Pop();
                int currentFork = forks.Peek();

                if (currentKnife > currentFork)
                {
                    int newSet = currentKnife + currentFork;
                    sets.Add(newSet);
                    forks.Dequeue();
                }
                else if (currentKnife == currentFork)
                {
                    forks.Dequeue();
                    currentKnife++;
                    knives.Push(currentKnife);
                }
            }

            int maxSet = sets.Max();

            Console.WriteLine($"The biggest set is: {maxSet}");

            Console.WriteLine(string.Join(" ", sets));
        }
    }
}

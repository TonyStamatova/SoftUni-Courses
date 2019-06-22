namespace _01.Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Stack<int> left = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Queue<int> right = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            List<int> pairs = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                int leftSock = left.Pop();
                int rightSock = right.Peek();

                if (leftSock > rightSock)
                {
                    pairs.Add(leftSock + rightSock);
                    right.Dequeue();
                }
                else if (leftSock == rightSock)
                {
                    right.Dequeue();
                    leftSock++;
                    left.Push(leftSock);
                }
            }

            int biggestSet = pairs
                .OrderByDescending(p => p)
                .FirstOrDefault();

            Console.WriteLine(biggestSet);

            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}

namespace _01.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            
            int popCount = input[1];

            for (int i = 0; i < popCount; i++)
            {
                stack.Pop();
            }

            int elementToFind = input[2];

            if (stack.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Count > 0 ? stack.Min() : 0);
            }
        }
    }
}

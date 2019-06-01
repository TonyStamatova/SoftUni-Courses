namespace _03.MaximumAndMinimumNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class MaximumAndMinimumNumbers
    {
        public static void Main()
        {
            int numberOfQuieries = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numberOfQuieries; i++)
            {
                string quierie = Console.ReadLine();

                if (quierie.Contains('1'))
                {
                    int element = int.Parse(quierie.Substring(2));
                    stack.Push(element);
                }
                else if(stack.Count > 0)
                {
                    switch (quierie)
                    {
                        case "2":
                            stack.Pop();
                            break;
                        case "3":
                            Console.WriteLine(stack.Max());
                            break;
                        case "4":
                            Console.WriteLine(stack.Min());
                            break;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}

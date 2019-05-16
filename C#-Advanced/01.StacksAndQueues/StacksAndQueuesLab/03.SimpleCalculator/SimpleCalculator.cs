namespace _03.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> elements = new Stack<string>(input.Reverse());

            while (elements.Count > 1)
            {
                int leftOperand = int.Parse(elements.Pop());
                string operatorr = elements.Pop();
                int rightOperand = int.Parse(elements.Pop());
                int result = default(int);

                switch (operatorr)
                {
                    case "+":
                        result = leftOperand + rightOperand;
                        break;
                    case "-":
                        result = leftOperand - rightOperand;
                        break;
                }

                elements.Push(result.ToString());
            }

            Console.WriteLine(elements.Pop());
        }
    }
}

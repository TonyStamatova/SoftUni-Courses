namespace _08.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesis
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            
            Stack<char> brackets = new Stack<char>();
            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == '{' || current == '[' || current == '(')
                {
                    brackets.Push(current);
                    continue;
                }

                if (brackets.Count == 0)
                {
                    isBalanced = false;
                    break;
                }
                else if (current == '}' && brackets.Peek() == '{')
                {
                    brackets.Pop();
                }
                else if (current == ']' && brackets.Peek() == '[')
                {
                    brackets.Pop();
                }
                else if (current == ')' && brackets.Peek() == '(')
                {
                    brackets.Pop();
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }
                        
            Console.WriteLine((brackets.Count == 0 && isBalanced == true) ? "YES" : "NO");
        }
    }
}

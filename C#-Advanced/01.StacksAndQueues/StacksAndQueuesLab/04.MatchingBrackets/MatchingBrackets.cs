namespace _04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = indexes.Pop();
                    int charsCount = i - startIndex + 1;
                    Console.WriteLine(input.Substring(startIndex, charsCount));
                }
            }
        }
    }
}

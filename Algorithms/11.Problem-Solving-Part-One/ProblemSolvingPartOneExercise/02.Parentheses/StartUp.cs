namespace _02.Parentheses
{
    using System;
    using System.Text;

    public class StartUp
    {
        private static int numberOfPairs;
        private static char[] vector;
        private static int openingBrackets;
        private static int closingBrackets;
        private static StringBuilder sb;

        public static void Main()
        {
            numberOfPairs = int.Parse(Console.ReadLine());

            vector = new char[2 * numberOfPairs];
            vector[0] = '(';
            vector[vector.Length - 1] = ')';

            openingBrackets = closingBrackets = numberOfPairs - 1;
            sb = new StringBuilder();
            Dfs(1);

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void Dfs(int index)
        {
            if (index == vector.Length - 1)
            {
                sb.AppendLine(new string(vector));
                return;
            }

            if (openingBrackets > 0)
            {
                openingBrackets--;
                vector[index] = '(';
                Dfs(index + 1);
                openingBrackets++;
            }

            if (closingBrackets > 0 && closingBrackets >= openingBrackets)
            {
                closingBrackets--;
                vector[index] = ')';
                Dfs(index + 1);
                closingBrackets++;
            }
        }
    }
}

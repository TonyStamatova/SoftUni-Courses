using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

namespace _10.rageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            MatchCollection matches = Regex.Matches(input, @"(?<text>(\D)+)(?<number>[0-9]+)");
            StringBuilder result = new StringBuilder();

            foreach (Match match in matches)
            {
                string text = match.Groups["text"].Value;
                int number = int.Parse(match.Groups["number"].Value);

                for (int i = 0; i < number; i++)
                {
                    result.Append(text);
                }
            }

            string resultStr = result.ToString();
            Dictionary<char, int> uniqueSymbols = new Dictionary<char, int>();

            for (int i = 0; i < resultStr.Length; i++)
            {
                if (!uniqueSymbols.ContainsKey(resultStr[i]))
                {
                    uniqueSymbols.Add(resultStr[i], 0);
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(resultStr);
        }
    }
}

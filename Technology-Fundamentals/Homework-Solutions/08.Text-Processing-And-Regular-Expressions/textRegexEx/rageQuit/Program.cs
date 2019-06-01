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
            StringBuilder result = new StringBuilder(10000);
            int number = default(int);
            Dictionary<char, int> uniqueSymbols = new Dictionary<char, int>();

            foreach (Match match in matches)
            {
                string textStr = match.Groups["text"].Value;
                number = int.Parse(match.Groups["number"].Value);

                for (int j = 0; j < textStr.Length; j++)
                {
                    if (number != 0 && !uniqueSymbols.ContainsKey(textStr[j]))
                    {
                        uniqueSymbols.Add(textStr[j], 0);
                    }
                }

                for (int i = 0; i < number; i++)
                {

                    result.Append(textStr);
                }

            }


            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(result);
        }
    }
}

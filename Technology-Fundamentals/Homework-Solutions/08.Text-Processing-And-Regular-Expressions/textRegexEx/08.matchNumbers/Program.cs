using System;
using System.Text.RegularExpressions;

namespace _08.matchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, @"(?<=^|\s)-?\d+\.?\d*(?=\s|$)");

            Console.WriteLine(string.Join(" ", matches));
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace _01.validUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            string regex = @"(?<=^|,{1}\ )[A-Za-z0-9_-]{3,16}(?=$|,{1}\ {1})";
            MatchCollection matched = Regex.Matches(names, regex);
            Console.WriteLine(string.Join(Environment.NewLine, matched));
        }
    }
}

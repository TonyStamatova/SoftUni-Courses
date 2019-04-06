using System;
using System.Text.RegularExpressions;

namespace _01.validUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");

            string regex = @"(?<=^)[A-Za-z0-9_-]{3,16}$";

            foreach (var item in names)
            {
                string matched = Regex.Match(item, regex).ToString();
                if (matched != "")
                {
                    Console.WriteLine(matched);
                }                
            }            
        }
    }
}

using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                Match nameMatch = Regex.Match(input, @"(?<=([#\$%\*&]{1}))(?<name>([A-Za-z]+))\1=(?<length>([0-9]+))!!(?<geohash>(.+))$");

                if (nameMatch.ToString() == "")
                {
                    Console.WriteLine("Nothing found!");
                    input = Console.ReadLine();
                    continue;
                }

                int length = int.Parse(nameMatch.Groups["length"].ToString());
                string geohash = nameMatch.Groups["geohash"].ToString();

                if (geohash.Length != length)
                {
                    Console.WriteLine("Nothing found!");
                    input = Console.ReadLine();
                    continue;
                }

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < geohash.Length; i++)
                {
                    char charToAppend = (char)(geohash[i] + length);
                    builder.Append(charToAppend);
                }

                string name = nameMatch.Groups["name"].ToString();
                Console.WriteLine($"Coordinates found! {name} -> {builder}");
                break;
            }
        }
    }
}

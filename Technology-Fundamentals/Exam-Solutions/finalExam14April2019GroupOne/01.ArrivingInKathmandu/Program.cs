using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _01.ArrivingInKathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "Last note")
                {
                    break;
                }
                
                Match validMessage = Regex.Match(input, @"^(?<name>[A-Za-z0-9!@#$?]+)=(?<length>\d+)<<(?<geohash>.+)$");

                if (validMessage.ToString() == "")
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                string name = validMessage.Groups["name"].ToString();
                int length =int.Parse(validMessage.Groups["length"].ToString());
                string geohash = validMessage.Groups["geohash"].ToString();

                if (geohash.Length != length)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }
                else
                {
                    StringBuilder decipheredName = new StringBuilder();
                    MatchCollection nameParts = Regex.Matches(name, @"\w+");

                    foreach (var part in nameParts)
                    {
                        decipheredName.Append(part);
                    }

                    Console.WriteLine($"Coordinates found! {decipheredName} -> {geohash}");
                }
            }
        }
    }
}

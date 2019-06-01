using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace _02.activationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"(?<=^|&)([A-Za-z0-9]{16,25})(?=&|$)");

            List<string> keys = new List<string>();

            foreach (var match in matches)
            {
                string key = match.ToString().ToUpper();
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < key.Length; i++)
                {
                    char charToAppend = key[i];

                    if (Char.IsDigit(key[i]))
                    {
                        int newDigit = 9 - int.Parse(key[i].ToString());
                        charToAppend = char.Parse(newDigit.ToString());
                    }

                    builder.Append(charToAppend);
                }

                keys.Add(builder.ToString());
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].Length == 16)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        result.Append(keys[i].Substring(4 * j, 4) + "-");
                    }

                    result.Append(keys[i].Substring(12));
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        result.Append(keys[i].Substring(5 * j, 5) + "-");
                    }

                    result.Append(keys[i].Substring(20));
                }

                if (i == keys.Count - 1)
                {
                    break;
                }

                result.Append(", ");
            }

            Console.WriteLine(result);
        }
    }
}

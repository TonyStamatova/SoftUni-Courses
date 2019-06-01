using System;
using System.Text.RegularExpressions;

namespace _1.lettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(new char[] { ' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            double totSum = default(double);

            for (int i = 0; i < strings.Length; i++)
            {
                double number = double.Parse(Regex.Match(strings[i], @"\d+").ToString());
                char firstLetter = strings[i][0];
                char lastLetter = strings[i][strings[i].Length - 1];

                if (Char.IsUpper(firstLetter))
                {
                    int divider = GetValue(firstLetter, 'A');
                    number /= divider;
                }
                else
                {
                    int multiplier = GetValue(firstLetter, 'a');
                    number *= multiplier;
                }

                if (Char.IsUpper(lastLetter))
                {
                    int substrat = GetValue(lastLetter, 'A');
                    number -= substrat;
                }
                else
                {
                    int addition = GetValue(lastLetter, 'a');
                    number += addition;
                }

                totSum += number;
            }

            Console.WriteLine($"{totSum:f2}");
        }

        private static int GetValue(char letter, char startingASCIILetter)
        {
            return letter - startingASCIILetter + 1;
        }
    }
}

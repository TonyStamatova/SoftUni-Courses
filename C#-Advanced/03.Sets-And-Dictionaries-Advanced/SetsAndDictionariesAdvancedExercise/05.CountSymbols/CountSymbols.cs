namespace _05.CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var symbols = new SortedDictionary<char, int>();

            foreach (var character in input)
            {
                if (!symbols.ContainsKey(character))
                {
                    symbols.Add(character, 1);
                }
                else
                {
                    symbols[character]++;
                }
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}

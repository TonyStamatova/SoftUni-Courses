namespace _03.CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isUppercase = x => char.IsUpper(x[0]);

            string[] filteredWords = input
                .Where(isUppercase)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, filteredWords));
        }
    }
}

namespace _07.PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, int, bool> filter = (x, y) => x.Length <= y;

            names = names
                .Where(x => filter(x, length))
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}

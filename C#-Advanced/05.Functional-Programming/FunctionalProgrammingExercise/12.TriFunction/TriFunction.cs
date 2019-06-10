namespace _12.TriFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TriFunction
    {
        public static void Main()
        {
            int desiredSum = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, int, bool> sumIsEqual = (n, s)
            => n.Select(c => (int)c).Sum() >= s;
                        
            Func<List<string>, int, Func<string, int, bool>, string> findFirst = (l, s, f) 
                => l.FirstOrDefault(n => f(n,s));

            string result = findFirst(names, desiredSum, sumIsEqual);
            Console.WriteLine(result);
        }
    }
}

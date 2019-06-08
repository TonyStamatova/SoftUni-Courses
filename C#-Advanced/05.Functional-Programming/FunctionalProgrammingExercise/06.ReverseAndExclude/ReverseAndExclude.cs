namespace _06.ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int filterNumber = int.Parse(Console.ReadLine());

            Func<int, int, bool> filter = (x, y) => x % y != 0;

            numbers = numbers.Where(x => filter(x, filterNumber))
                .Reverse()
                .ToList();

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            print(numbers);
        }
    }
}

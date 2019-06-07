namespace _05.AppliedArithmetics
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, Func<int, int>, List<int>> operation = (x,y) => x.Select(y).ToList();
            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x => x * 2;
            Func<int, int> subtract = x => x - 1;

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = operation(numbers, add);
                        break;
                    case "multiply":
                        numbers = operation(numbers, multiply);
                        break;
                    case "subtract":
                        numbers = operation(numbers, subtract);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }                
            }
        }
    }
}

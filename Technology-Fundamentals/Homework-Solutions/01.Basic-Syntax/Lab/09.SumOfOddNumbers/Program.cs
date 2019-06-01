using System;

namespace _09.sumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = default(int);

            for (int i = 1; i <= 2 * n; i += 2)
            {
                Console.WriteLine(i);
                sum += i;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}

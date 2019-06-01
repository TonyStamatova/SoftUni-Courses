using System;

namespace _02.sumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int digit = default(int);
            int sum = default(int);

            while (num > 0)
            {
                digit = num % 10;
                sum += digit;
                num /= 10;
            }

            Console.WriteLine(sum);
        }
    }
}

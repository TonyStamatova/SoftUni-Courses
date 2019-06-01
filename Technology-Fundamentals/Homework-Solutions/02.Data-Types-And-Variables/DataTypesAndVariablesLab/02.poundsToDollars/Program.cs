using System;

namespace _02.poundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());

            money *= 1.31m;
            Console.WriteLine($"{money:f3}");
        }
    }
}

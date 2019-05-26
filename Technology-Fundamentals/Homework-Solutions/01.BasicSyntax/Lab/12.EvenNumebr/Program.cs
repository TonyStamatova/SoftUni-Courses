﻿using System;

namespace _12.evenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            while (number % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                number = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {Math.Abs(number)}");
        }
    }
}

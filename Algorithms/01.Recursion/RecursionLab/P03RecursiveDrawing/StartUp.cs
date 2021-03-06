﻿namespace P03RecursiveDrawing
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Draw(number);
        }

        public static void Draw(int number)
        {
            if (number == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', number));
            Draw(number - 1);
            Console.WriteLine(new string('#', number));
        }
    }
}

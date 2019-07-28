﻿namespace P01RecursiveArraySum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(array, 0));
        }

        public static int Sum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}

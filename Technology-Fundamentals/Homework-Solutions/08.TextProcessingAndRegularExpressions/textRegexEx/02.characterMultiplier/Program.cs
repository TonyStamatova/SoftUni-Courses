using System;

namespace _02.characterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            string first = strings[0];
            string second = strings[1];
            int totSum = default(int);

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                int sum = first[i] * second[i];
                totSum += sum;
            }

            for (int i = Math.Min(first.Length, second.Length); i < Math.Max(first.Length, second.Length); i++)
            {
                if (first.Length > i)
                {
                    totSum += first[i];
                }
                else
                {
                    totSum += second[i];
                }
            }

            Console.WriteLine(totSum);
        }
    }
}

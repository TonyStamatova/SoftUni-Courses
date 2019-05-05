using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int result = FindMinOfThreeNumbers(firstNum, secondNum, thirdNum);
            Console.WriteLine(result);
        }

        private static int FindMinOfThreeNumbers(int firstNum, int secondNum,
            int thirdNum)
        {
            int result = Math.Min(firstNum, secondNum);
            result = Math.Min(result, thirdNum);
            return result;
        }
    }
}

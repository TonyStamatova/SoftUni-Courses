using System;

namespace _01.integerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            int tot = ((firstNum + secondNum) / thirdNum) * fourthNum;
            Console.WriteLine(tot);
        }
    }
}

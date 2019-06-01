using System;

namespace _01.sortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double biggestNum = double.MinValue;
            double middleNum = double.MinValue;
            double smallestNum = double.MinValue;
            
            for (double i = 0; i < 3; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());

                if (currentNum > biggestNum)
                {
                    smallestNum = middleNum;
                    middleNum = biggestNum;
                    biggestNum = currentNum;
                }
                else if (currentNum > middleNum)
                {
                    smallestNum = middleNum;
                    middleNum = currentNum;
                }
                else
                {
                    smallestNum = currentNum;
                }
            }

            Console.WriteLine(biggestNum + Environment.NewLine + middleNum + Environment.NewLine + smallestNum);
        }
    }
}

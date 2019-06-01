using System;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            double difference = Math.Abs(firstNum - secondNum);

            Console.WriteLine(difference < 0.000001);
        }
    }
}

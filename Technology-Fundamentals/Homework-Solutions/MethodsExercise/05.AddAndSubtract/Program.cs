using System;

namespace _05.addAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            int thirdInt = int.Parse(Console.ReadLine());

            int additionResult = Sum(firstInt, secondInt);
            int result = Substract(additionResult, thirdInt);

            Console.WriteLine(result);
        }

        private static int Substract(int substractedInt, int substraction)
        {
            return substractedInt - substraction;
        }

        private static int Sum(int firstInt, int secondInt)
        {
            return firstInt + secondInt;
        }
    }
}

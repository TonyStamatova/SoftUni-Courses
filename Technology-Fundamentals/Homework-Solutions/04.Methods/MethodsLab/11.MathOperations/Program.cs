using System;

namespace _11.mathOperations
{
    class Program
    {
        public static void Main()
        {
            double firstNum = double.Parse(Console.ReadLine());
            char operationType = char.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Round
                (GetResult(firstNum, operationType, secondNum), 2));
        }

        private static double GetResult(double firstNumber, char operation, double secondNumber)
        {
            double result = default(double);

            switch (operation)
            {
                case '/':
                    result = firstNumber / secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                default:
                    result = firstNumber - secondNumber;
                    break;
            }

            return result;
        }
    }
}

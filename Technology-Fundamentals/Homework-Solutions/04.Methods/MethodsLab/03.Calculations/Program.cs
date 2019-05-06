using System;

namespace calculations
{
    class Program
    {
        public static void Main()
        {
            string operation = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    PrintResultAdding(firstNum, secondNum);
                    break;
                case "multiply":
                    PrintResultMultiplying(firstNum, secondNum);
                    break;
                case "subtract":
                    PrintResultSubtraction(firstNum, secondNum);
                    break;
                default:
                    PrintResultDivision(firstNum, secondNum);
                    break;
            }
        }

        private static void PrintResultAdding(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum + secondNum);
        }

        private static void PrintResultSubtraction(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum - secondNum);
        }

        private static void PrintResultMultiplying(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum * secondNum);
        }

        private static void PrintResultDivision(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum / secondNum);
        }
    }
}


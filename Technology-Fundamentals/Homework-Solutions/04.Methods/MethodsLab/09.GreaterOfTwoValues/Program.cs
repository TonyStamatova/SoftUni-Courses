using System;

namespace _08.stupidSolution
{
    class Program
    {
        public static void Main()
        {
            string inputType = Console.ReadLine();

            switch (inputType)
            {
                case "int":
                    int firstNum = int.Parse(Console.ReadLine());
                    int secondNum = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstNum, secondNum));
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstChar, secondChar));
                    break;
                default:
                    string firstStr = Console.ReadLine();
                    string secondStr = Console.ReadLine();
                    Console.WriteLine(GetMax(firstStr, secondStr));
                    break;
            }
        }

        private static int GetMax(int firstInt, int secondInt)
        {
            int result = Math.Max(firstInt, secondInt);

            return result;
        }

        private static char GetMax(char firstSymbol, char secondSymbol)
        {
            if (firstSymbol > secondSymbol)
            {
                return firstSymbol;
            }
            else
            {
                return secondSymbol;
            }
        }

        private static string GetMax(string firstString, string secondString)
        {
            string result = string.Empty;

            for (int i = 0; i < firstString.Length; i++)
            {
                if (firstString[i] > secondString[i])
                {
                    result = firstString;
                    break;
                }
                else if (firstString[i] < secondString[i])
                {
                    result = secondString;
                    break;
                }
            }

            return result;
        }
    }
}

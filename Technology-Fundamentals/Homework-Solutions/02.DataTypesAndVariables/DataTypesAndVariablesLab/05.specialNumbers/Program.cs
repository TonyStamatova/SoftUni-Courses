using System;

namespace _05.specialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int currentNum = i;
                int sumOfDigits = default(int);

                while (currentNum != 0)
                {
                    int remainder = currentNum % 10;
                    sumOfDigits += remainder;
                    currentNum /= 10;                    
                }

                switch (sumOfDigits)
                {
                    case 5:
                    case 7:
                    case 11:
                        Console.WriteLine($"{i} -> True");
                        break;
                    default:
                        Console.WriteLine($"{i} -> False");
                        break;
                }
            }
        }
    }
}

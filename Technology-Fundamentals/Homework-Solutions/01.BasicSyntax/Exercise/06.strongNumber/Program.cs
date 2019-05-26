using System;

namespace _06.strongNumber
{
    class Program
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            int currentNum = num;
            int digit = default(int);
            int sum = default(int);
            int factorial = 1;

            while (currentNum != 0)
            {
                digit = currentNum % 10;

                for (int i = 2; i <= digit; i++)
                {
                    factorial *= i;
                }

                sum += factorial;
                currentNum /= 10;
                factorial = 1;
            }

            if (sum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}

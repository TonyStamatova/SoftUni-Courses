using System;

namespace _02.division
{
    class Program
    {
        public static void Main()
        {
            //2, 3, 6, 7, 10

            int num = int.Parse(Console.ReadLine());
            int resultNum = default(int);
            bool isDevisible = true;

            if (num % 10 == 0)
            {
                resultNum = 10;
            }
            else if (num % 7 == 0)
            {
                resultNum = 7;
            }
            else if (num % 6 == 0)
            {
                resultNum = 6;
            }
            else if (num % 3 == 0)
            {
                resultNum = 3;
            }
            else if (num % 2 == 0)
            {
                resultNum = 2;
            }
            else
            {
                isDevisible = false;
                Console.WriteLine("Not divisible");
            }

            if (isDevisible)
            {
                Console.WriteLine($"The number is divisible by {resultNum}");
            }
        }
    }
}

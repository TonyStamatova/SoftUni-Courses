using System;

namespace _04.printAndSum
{
    class Program
    {
        public static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int sum = default(int);

            for (int i = firstNum; i <= secondNum; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }

            Console.WriteLine(Environment.NewLine + $"Sum: {sum}");
        }
    }
}

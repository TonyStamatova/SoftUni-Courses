namespace _02.SumTo13
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[] numbers;

        public static void Main()
        {
            numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SumNumber(0, 0);

            Console.WriteLine("No");
        }

        private static void SumNumber(int index, int sum)
        {       
            if (index >= numbers.Length)
            {
                if (sum == 13)
                {
                    Console.WriteLine("Yes");
                    Environment.Exit(0);
                }

                return;
            }

            SumNumber(index + 1, sum + numbers[index]);
            SumNumber(index + 1, sum - numbers[index]);
        }
    }
}

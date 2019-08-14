namespace _01.Fibonacci
{
    using System;

    public class StartUp
    {
        private static long[] values;

        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            values = new long[number + 1];

            Console.WriteLine(Fibonacci(number));
        }

        static long Fibonacci(int number)
        {
            if (values[number] != 0)
            {
                return values[number];
            }

            if (number == 1 || number == 2)
            {
                return 1;
            }

            long result = Fibonacci(number - 1) + Fibonacci(number - 2);
            values[number] = result;

            return result;
        }
    }
}

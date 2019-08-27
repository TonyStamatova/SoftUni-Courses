namespace _02.Enter_Numbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                int number = 1;

                try
                {
                    for (int i = 1; i < 10; i++)
                    {
                        number = ReadNumber(number, 100);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }

                break;
            }
        }

        public static int ReadNumber(int start, int end)
        {
            string numberAsString = Console.ReadLine();
            int number = default(int);

            try
            {
                number = int.Parse(numberAsString);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid number. Enter all numbers again!");
            }

            if (number <= start || number >= end)
            {
                throw new ArgumentException("Number should be in the specified range. Enter all numbers again!");
            }

            return number;
        }
    }
}

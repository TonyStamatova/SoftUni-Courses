namespace _01.RecursiveArraySum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();

            Console.WriteLine(Sum(input, 0));
        }

        public static int Sum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + Sum(array, ++index);
        }
    }
}

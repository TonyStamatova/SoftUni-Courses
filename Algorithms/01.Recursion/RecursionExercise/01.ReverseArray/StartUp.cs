namespace _01.ReverseArray
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] array = Console.ReadLine().Split();

            Print(array, 0);
        }

        private static void Print(string[] array, int index)
        {
            if (index == array.Length)
            {
                return;
            }

            Print(array, index + 1);
            Console.Write(array[index] + " ");
        }
    }
}

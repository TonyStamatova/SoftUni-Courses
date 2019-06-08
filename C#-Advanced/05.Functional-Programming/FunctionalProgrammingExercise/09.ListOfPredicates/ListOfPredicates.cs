namespace _09.ListOfPredicates
{
    using System;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            int endOfRange = int.Parse(Console.ReadLine());
            int[] sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> checkDivision = (x, y) => x % y != 0;

            for (int i = 1; i <= endOfRange; i++)
            {
                bool isDivisible = true;

                foreach (var item in sequence)
                {
                    if (checkDivision(i, item))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write(i + " ");
                }
            }

        }
    }
}

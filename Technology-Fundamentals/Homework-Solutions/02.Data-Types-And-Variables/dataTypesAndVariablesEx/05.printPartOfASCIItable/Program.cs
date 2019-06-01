using System;

namespace _05.printPartOfASCIItable
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstCharNum = int.Parse(Console.ReadLine());
            int lastCharNum = int.Parse(Console.ReadLine());

            for (int i = firstCharNum; i <= lastCharNum; i++)
            {
                Console.Write((char)i + " ");
            }
            Console.WriteLine();
        }
    }
}

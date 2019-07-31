namespace _04.TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Stack<int> source = new Stack<int>();
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        private static int stepsTaken = default(int);

        public static void Main()
        {
            int diskCount = int.Parse(Console.ReadLine());

            for (int i = diskCount; i > 0; i--)
            {
                source.Push(i);
            }

            PrintRods();
            MoveDisk(diskCount, source, destination, spare);
        }

        private static void MoveDisk(
            int bottomDisk, 
            Stack<int> source, 
            Stack<int> destination, 
            Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                TakeANewStep(source, destination);
                return;
            }

            MoveDisk(bottomDisk - 1, source, spare, destination);

            TakeANewStep(source, destination);

            MoveDisk(bottomDisk - 1, spare, destination, source);
        }

        private static void TakeANewStep(Stack<int> source, Stack<int> destination)
        {
            stepsTaken++;
            destination.Push(source.Pop());
            Console.WriteLine($"Step #{stepsTaken}: Moved disk");
            PrintRods();
        }

        private static void PrintRods()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }
    }
}

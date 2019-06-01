namespace _06.Jagged_ArrayModification
{
    using System;
    using System.Linq;

    public class JaggedArrayModification
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] array = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                array[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commandData = input.Split();
                input = Console.ReadLine();
                string command = commandData[0];
                int row = int.Parse(commandData[1]);
                int col = int.Parse(commandData[2]);
                int value = int.Parse(commandData[3]);

                if (!AreInBounds(row, col, array))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        array[row][col] += value;
                        break;
                    case "Subtract":
                        array[row][col] -= value;
                        break;
                }
            }

            foreach (var row in array)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool AreInBounds(int row, int col, int[][] array)
        {
            if (row >= 0 && row < array.Length)
            {
                if (col >= 0 && col < array[row].Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

namespace _01.TheGarden
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] garden = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                garden[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            int countOfCarrots = default(int);
            int countOfPotatos = default(int);
            int countOfLettuce = default(int);
            int harmedVegetables = default(int);

            string input = Console.ReadLine();

            while (input != "End of Harvest")
            {
                string[] commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandInfo[0];
                int row = int.Parse(commandInfo[1]);
                int col = int.Parse(commandInfo[2]);

                switch (command.ToLower())
                {
                    case "harvest":
                        if (PositionIsValid(row, col, garden)
                            && garden[row][col] != ' ')
                        {
                            switch (garden[row][col])
                            {
                                case 'C':
                                    countOfCarrots++;
                                    break;
                                case 'P':
                                    countOfPotatos++;
                                    break;
                                case 'L':
                                    countOfLettuce++;
                                    break;
                            }

                            garden[row][col] = ' ';
                        }
                        break;

                    case "mole":
                        string direction = commandInfo[3].ToLower();

                        switch (direction)
                        {
                            case "up":
                                for (int currentRow = row; currentRow >= 0; currentRow -= 2)
                                {
                                    if (PositionIsValid(currentRow, col, garden) && garden[currentRow][col] != ' ')
                                    {
                                        harmedVegetables++;
                                        garden[currentRow][col] = ' ';
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "down":
                                for (int currentRow = row; currentRow < garden.Length; currentRow += 2)
                                {
                                    if (PositionIsValid(currentRow, col, garden) && garden[currentRow][col] != ' ')
                                    {
                                        harmedVegetables++;
                                        garden[currentRow][col] = ' ';
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "left":
                                for (int currentCol = col; currentCol >= 0; currentCol -= 2)
                                {
                                    if (PositionIsValid(row, currentCol, garden) && garden[row][currentCol] != ' ')
                                    {
                                        harmedVegetables++;
                                        garden[row][currentCol] = ' ';
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "right":
                                for (int currentCol = col; currentCol < garden[row].Length; currentCol += 2)
                                {
                                    if (PositionIsValid(row, currentCol, garden) && garden[row][currentCol] != ' ')
                                    {
                                        harmedVegetables++;
                                        garden[row][currentCol] = ' ';
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Carrots: {countOfCarrots}"
                + Environment.NewLine + $"Potatoes: {countOfPotatos}"
                + Environment.NewLine + $"Lettuce: {countOfLettuce}"
                + Environment.NewLine + $"Harmed vegetables: {harmedVegetables}");
        }

        private static bool PositionIsValid(int row, int col, char[][] array)
        {
            if (row >= 0
                && row < array.Length
                && col >= 0
                && col < array[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}

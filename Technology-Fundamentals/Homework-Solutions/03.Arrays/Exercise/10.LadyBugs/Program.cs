using System;
using System.Linq;

namespace _09.ladyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string initialIndexes = Console.ReadLine();

            int[] field = new int[fieldSize];
            int[] initialIndexesArr = initialIndexes.Split().Select(int.Parse).ToArray();

            for (int i = 0; i < initialIndexesArr.Length; i++)
            {
                if (initialIndexesArr[i] >= field.Length || initialIndexesArr[i] < 0)
                {
                    continue;
                }

                field[initialIndexesArr[i]] = 1;
            }

            string command = string.Empty;
            string[] flyCommand = new string[3];
            int ladybugCellIndex = default(int);
            int flightLength = default(int);
            int newCellIndex = default(int);

            while (true)
            {
                command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                flyCommand = command.Split().ToArray();
                ladybugCellIndex = int.Parse(flyCommand[0]);
                flightLength = int.Parse(flyCommand[2]);

                if (ladybugCellIndex < 0 || ladybugCellIndex >= field.Length)
                {
                    continue;
                }

                if (field[ladybugCellIndex] == 0)
                {
                    continue;
                }

                field[ladybugCellIndex] = 0;

                if (flyCommand[1] == "right")
                {
                    newCellIndex = ladybugCellIndex + flightLength;
                }
                else
                {
                    newCellIndex = ladybugCellIndex - flightLength;
                }

                if (newCellIndex < 0 || newCellIndex >= field.Length)
                {
                    continue;
                }

                while (field[newCellIndex] == 1)
                {
                    if (flyCommand[1] == "right")
                    {
                        newCellIndex += flightLength;
                    }
                    else
                    {
                        newCellIndex -= flightLength;
                    }

                    if (newCellIndex < 0 || newCellIndex >= field.Length)
                    {
                        break;
                    }
                }

                if (newCellIndex < 0 || newCellIndex >= field.Length)
                {
                    continue;
                }

                if (field[newCellIndex] == 0)
                {
                    field[newCellIndex] = 1;
                }
            }

            string result = string.Join(" ", field);
            Console.WriteLine(result);
        }
    }
}

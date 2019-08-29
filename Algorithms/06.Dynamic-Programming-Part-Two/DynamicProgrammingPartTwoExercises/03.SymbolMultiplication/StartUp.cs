namespace _03.SymbolMultiplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        private static char[,] multiplicationMatrix;
        private static string available;
        private static List<bool[]> isCombined;

        public static void Main()
        {
            int alphabetLength = Regex
                .Matches(Console.ReadLine(), @"(?<=[{,])[a-z]")
                .Count;

            Console.ReadLine();

            multiplicationMatrix = new char[alphabetLength, alphabetLength];
            FillMultiplicationMatrix();

            isCombined = new List<bool[]>();

            available = Regex.Match(Console.ReadLine(), @"[a-z]+").ToString();

            TraverseAvailableString(available);

            Console.WriteLine("No solution");
        }

        private static void TraverseAvailableString(string sequence)
        {
            if (sequence.Length == 1)
            {
                if (sequence == "a")
                {
                    ReconstructSolution(available, isCombined);
                    Environment.Exit(0);
                }

                return;
            }

            bool[] currentRotation = new bool[sequence.Length - 1];
            isCombined.Add(currentRotation);

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                char firstLetter = sequence[i];
                char secondLetter = sequence[i + 1];

                int resultRow = firstLetter - 97;
                int resultCol = secondLetter - 97;

                string multiplicationResult = multiplicationMatrix[resultRow, resultCol].ToString();
                string combined = sequence.Remove(i, 2).Insert(i, multiplicationResult);

                currentRotation[i] = true;
                TraverseAvailableString(combined);
                currentRotation[i] = false;
            }

            isCombined.Remove(currentRotation);
        }

        private static void ReconstructSolution(string initialString, List<bool[]> isCombined)
        {
            List<string[]> resultReconstruction = new List<string[]>();

            string[] firstRow = initialString
                .Select(c => c.ToString())
                .ToArray();

            resultReconstruction.Add(firstRow);

            foreach (var array in isCombined)
            {
                string[] previous = resultReconstruction.Last();
                string[] currentRotation = new string[array.Length];

                int previousIndex = -1;

                for (int i = 0; i < array.Length; i++)
                {
                    previousIndex++;

                    if (array[i])
                    {
                        currentRotation[i] = $"({previous[previousIndex]}*{previous[previousIndex + 1]})";
                        previousIndex++;
                        continue;
                    }

                    currentRotation[i] = previous[previousIndex];
                }

                resultReconstruction.Add(currentRotation);
            }

            Console.WriteLine(string.Join("", resultReconstruction.Last()));
        }

        private static void FillMultiplicationMatrix()
        {
            for (int i = 0; i < multiplicationMatrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .Trim()
                    .ToCharArray();

                for (int j = 0; j < multiplicationMatrix.GetLength(1); j++)
                {
                    multiplicationMatrix[i, j] = row[j];
                }
            }
        }
    }
}

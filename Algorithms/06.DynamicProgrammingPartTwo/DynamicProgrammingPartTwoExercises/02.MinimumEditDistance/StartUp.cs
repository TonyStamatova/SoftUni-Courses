namespace _02.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string[] replaceCostInfo = Console.ReadLine().Split();
            int replaceCost = int.Parse(replaceCostInfo[2]);
            string[] insertCostInfo = Console.ReadLine().Split();
            int insertCost = int.Parse(insertCostInfo[2]);
            string[] deleteCostInfo = Console.ReadLine().Split();
            int deleteCost = int.Parse(deleteCostInfo[2]);

            string[] s1Info = Console.ReadLine().Split('=');
            string s1 = s1Info[1].Trim();
            string[] desiredStringInfo = Console.ReadLine().Split('=');
            string desired = desiredStringInfo[1].Trim();

            int[,] costMatrix = new int[s1.Length + 1, desired.Length + 1];

            CalculateRowZero(desired, costMatrix, insertCost);

            CalculateColZero(s1, costMatrix, deleteCost);

            FillCostMatrix(desired, s1, costMatrix, insertCost, deleteCost, replaceCost);

            List<string> result = ReconstructSolution(costMatrix, replaceCost, insertCost, deleteCost, desired, s1);

            int minCost = costMatrix[costMatrix.GetLength(0) - 1, costMatrix.GetLength(1) - 1];

            PrintResult(minCost, result);
        }

        private static void PrintResult(int minCost, List<string> result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Minimum edit distance: {minCost}");

            foreach (var operation in result)
            {
                sb.AppendLine(operation);
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static List<string> ReconstructSolution(
            int[,] costMatrix,
            int replaceCost,
            int insertCost,
            int deleteCost,
            string desired,
            string s1)
        {
            List<string> result = new List<string>();

            int currentRow = costMatrix.GetLength(0) - 1;
            int currentCol = costMatrix.GetLength(1) - 1;

            while (currentRow != 0 && currentCol != 0)
            {
                char desiredSymbol = desired[currentCol - 1];
                char s1Symbol = s1[currentRow - 1];

                if (desiredSymbol == s1Symbol)
                {
                    currentRow--;
                    currentCol--;
                    continue;
                }

                int costIfReplaced = costMatrix[currentRow - 1, currentCol - 1] + replaceCost;
                int costIfDeleted = costMatrix[currentRow - 1, currentCol] + deleteCost;
                int costIfInserted = costMatrix[currentRow, currentCol - 1] + insertCost;

                int minCost = Math.Min(costIfReplaced, Math.Min(costIfInserted, costIfDeleted));

                if (minCost == costIfReplaced)
                {
                    result.Add($"REPLACE({currentRow - 1}, {desired[currentCol - 1]})");
                    currentRow--;
                    currentCol--;
                }
                else if (minCost == costIfInserted)
                {
                    result.Add($"INSERT({currentCol}, {desired[currentCol - 1]})");
                    currentCol--;
                }
                else
                {
                    result.Add($"DELETE({currentRow - 1})");
                    currentRow--;
                }
            }

            while (currentRow != 0)
            {
                result.Add($"DELETE({currentRow - 1})");
                currentRow--;
            }

            while (currentCol != 0)
            {
                result.Add($"INSERT({currentCol - 1}, {desired[currentCol - 1]})");
                currentCol--;
            }

            result.Reverse();
            return result;
        }

        private static void FillCostMatrix(
            string desired, 
            string s1, 
            int[,] costMatrix,
            int insertCost,
            int deleteCost,
            int replaceCost)
        {
            for (int row = 1; row < costMatrix.GetLength(0); row++)
            {
                int s1Index = row - 1;

                for (int col = 1; col < costMatrix.GetLength(1); col++)
                {
                    int desiredIndex = col - 1;

                    if (desired[desiredIndex] == s1[s1Index])
                    {
                        costMatrix[row, col] = costMatrix[row - 1, col - 1];
                    }
                    else
                    {
                        int costIfDeleted = costMatrix[row - 1, col] + deleteCost;
                        int costIfInserted = costMatrix[row, col - 1] + insertCost;
                        int costIfReplaced = costMatrix[row - 1, col - 1] + replaceCost;

                        costMatrix[row, col] = Math.Min(costIfDeleted, Math.Min(costIfInserted, costIfReplaced));
                    }
                }
            }
        }

        private static void CalculateColZero(string s1, int[,] costMatrix, int deleteCost)
        {
            for (int i = 1; i <= s1.Length; i++)
            {
                costMatrix[i,0] = costMatrix[i - 1, 0] + deleteCost;
            }
        }

        private static void CalculateRowZero(string desired, int[,] costMatrix, int insertCost)
        {
            for (int i = 1; i <= desired.Length; i++)
            {
                costMatrix[0, i] = costMatrix[0, i - 1] + insertCost;
            }
        }
    }
}

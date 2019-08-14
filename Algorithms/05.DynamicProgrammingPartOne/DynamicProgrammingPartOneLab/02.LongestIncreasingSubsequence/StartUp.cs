namespace _02.LongestIncreasingSubsequence
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] length = new int[numbers.Length];
            int[] previousIndex = new int[numbers.Length];

            int maxSolution = default(int);
            int maxSolutionIndex = default(int);

            for (int i = 0; i < numbers.Length; i++)
            {
                int solution = 1;

                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] > numbers[j] && length[j] >= solution)
                    {
                        solution = length[j] + 1;
                        previousIndex[i] = j;
                    }
                }

                length[i] = solution;

                if (solution > maxSolution)
                {
                    maxSolution = solution;
                    maxSolutionIndex = i;
                }
            }

            int[] result = new int[maxSolution];

            result[result.Length - 1] = numbers[maxSolutionIndex];

            for (int i = result.Length - 2; i >= 0; i--)
            {
                result[i] = numbers[previousIndex[maxSolutionIndex]];
                maxSolutionIndex = previousIndex[maxSolutionIndex];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

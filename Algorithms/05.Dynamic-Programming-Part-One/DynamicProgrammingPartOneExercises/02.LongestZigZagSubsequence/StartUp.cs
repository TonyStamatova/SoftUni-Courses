namespace _02.LongestZigZagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static HashSet<int[]> subsequences;

        public static void Main()
        {
            int[] sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            subsequences = new HashSet<int[]>();

            FindTheLongestSubsequence(sequence);

            int[] longest = subsequences
                .OrderByDescending(s => s.Length)
                .FirstOrDefault();

            Console.WriteLine(string.Join(" ", longest));
        }

        private static void FindTheLongestSubsequence(int[] sequence)
        {
            foreach (var number in sequence)
            {
                foreach (var subsequence in subsequences.ToList())
                {
                    if (subsequence.Length < 2)
                    {
                        AddNewSequence(number, subsequence);
                        continue;
                    }

                    int lastNumber = subsequence[subsequence.Length - 1];
                    int secondToLastNumber = subsequence[subsequence.Length - 2];

                    if (NumberCanBeAdded(number, lastNumber, secondToLastNumber))
                    {
                        AddNewSequence(number, subsequence);
                    }
                }

                subsequences.Add(new int[1] { number });
            }
        }

        private static void AddNewSequence(int number, int[] subsequence)
        {
            int[] newSubsequence = new int[subsequence.Length + 1];

            for (int i = 0; i < newSubsequence.Length - 1; i++)
            {
                newSubsequence[i] = subsequence[i];
            }

            newSubsequence[newSubsequence.Length - 1] = number;
            subsequences.Add(newSubsequence);
        }

        private static bool NumberCanBeAdded(int number, int lastNumber, int secondToLastNumber)
        {
            return (number > lastNumber && lastNumber < secondToLastNumber)
                                    || (number < lastNumber && lastNumber > secondToLastNumber);
        }
    }
}

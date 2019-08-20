namespace _02.LongestCommonSubsequence
{
    using System;

    public class StartUp
    {
        private static int[,] longestCommon;

        private static string firstSequence;
        private static string secondSequence;

        public static void Main()
        {
            firstSequence = Console.ReadLine();
            secondSequence = Console.ReadLine();

            longestCommon = new int[firstSequence.Length, secondSequence.Length];

            FillLongestCommonSequencesLength();

            Console.WriteLine(longestCommon[firstSequence.Length - 1, secondSequence.Length - 1]);
        }

        private static void FillLongestCommonSequencesLength()
        {
            for (int row = 0; row < firstSequence.Length; row++)
            {
                for (int col = 0; col < secondSequence.Length; col++)
                {
                    if (firstSequence[row] == secondSequence[col])
                    {
                        if (row == 0 || col == 0)
                        {
                            longestCommon[row, col] = 1;
                            continue;
                        }

                        longestCommon[row, col] = longestCommon[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        if (row == 0 && col == 0)
                        {
                            longestCommon[row, col] = 0;
                            continue;
                        }

                        if (row == 0)
                        {
                            longestCommon[row, col] = longestCommon[row, col - 1];
                            continue;
                        }

                        if (col == 0)
                        {
                            longestCommon[row, col] = longestCommon[row - 1, col];
                            continue;
                        }

                        longestCommon[row, col] = Math.Max(longestCommon[row - 1, col], longestCommon[row, col - 1]);
                    }
                }
            }
        }
    }
}

namespace _03.Towns
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[] towns;
        private static int[] lis;
        private static int[] lds;

        public static void Main()
        {
            int townCount = int.Parse(Console.ReadLine());
            towns = new int[townCount];
            ReadTownInfo(townCount);

            lis = new int[townCount];
            FindLongestIncreasingSubsequence(lis);

            lds = new int[townCount];
            towns = towns.Reverse().ToArray();
            FindLongestIncreasingSubsequence(lds);
            lds = lds.Reverse().ToArray();

            int result = FindLongestSatisfactorySubsequence();
            Console.WriteLine(result);
        }

        private static int FindLongestSatisfactorySubsequence()
        {
            int maxLength = 0;

            for (int i = 0; i < towns.Length; i++)
            {
                int length = lis[i] + lds[i];

                if (length > maxLength)
                {
                    maxLength = length;
                }
            }

            maxLength--;
            return maxLength;
        }

        private static void FindLongestIncreasingSubsequence(int[] lentghs)
        {
            lentghs[0] = 1;

            for (int i = 1; i < towns.Length; i++)
            {
                int bestLength = 0;

                for (int j = i - 1; j >= 0; j--)
                {
                    int length = lentghs[j];

                    if (towns[j] < towns[i] && length > bestLength)
                    {
                        bestLength = length;
                    }
                }

                lentghs[i] = bestLength + 1;
            }
        }

        private static void ReadTownInfo(int townCount)
        {
            for (int i = 0; i < townCount; i++)
            {
                towns[i] = int.Parse(Console.ReadLine().Split()[0]);
            }
        }
    }
}

namespace _04.RodCutting
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[] price;
        private static int[] bestPrice;
        private static int[] bestCombo;

        public static void Main()
        {
            price = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int wholeLength = int.Parse(Console.ReadLine());

            bestPrice = new int[price.Length];
            bestCombo = new int[price.Length];

            Console.WriteLine(CutRod(wholeLength));

            ReconstructSolution(wholeLength);
        }

        private static void ReconstructSolution(int wholeLength)
        {
            while (wholeLength - bestCombo[wholeLength] != 0)
            {
                Console.Write(bestCombo[wholeLength] + " ");
                wholeLength -= bestCombo[wholeLength];
            }

            Console.WriteLine(bestCombo[wholeLength]);
        }

        private static int CutRod(int wholeLength)
        {
            for (int i = 1; i <= wholeLength; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    int currentBest = Math.Max(bestPrice[i], price[j] + bestPrice[i - j]);
                     if (currentBest > bestPrice[i])
                    {
                        bestPrice[i] = currentBest;
                        bestCombo[i] = j;
                     }
                }
            }

            return bestPrice[wholeLength];
        }
    }
}

namespace _05.CombinationsWithoutRepetition
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int setSize = int.Parse(Console.ReadLine());
            int combinationSize = int.Parse(Console.ReadLine());

            GenerateCombination(1, setSize, new int[combinationSize], 0);
        }

        private static void GenerateCombination(
            int startIndex, 
            int setSize, 
            int[] combination, 
            int combinationIndex)
        {
            if (combinationIndex == combination.Length)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            for (int i = startIndex; i <= setSize; i++)
            {
                combination[combinationIndex] = i;
                GenerateCombination(startIndex + 1, setSize, combination, combinationIndex + 1);
                startIndex++;
            }
        }
    }
}

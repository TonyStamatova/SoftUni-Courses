namespace P05GeneratingCombinations
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] set = Console.ReadLine().Split();

            int elementsCount = int.Parse(Console.ReadLine());

            LoopNumberOfLoops(set, 0, new string[elementsCount], 0);
        }

        public static void LoopNumberOfLoops(
            string[] wholeSet,
            int setIndex,
            string[] result,
            int resultIndex)
        {
            if (resultIndex == result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = setIndex; i < wholeSet.Length; i++)
            {
                result[resultIndex] = wholeSet[i];
                LoopNumberOfLoops(wholeSet, i + 1, result, resultIndex + 1);               
            }
        }
    }
}

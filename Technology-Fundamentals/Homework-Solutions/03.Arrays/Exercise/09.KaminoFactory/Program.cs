using System;
using System.Linq;

namespace _09.kaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int DNAlength = int.Parse(Console.ReadLine());
            string input = string.Empty;

            int[] sequence = new int[DNAlength];
            int sum = default(int);
            int biggestSumForCurrentSequence = default(int);
            int biggestSum = default(int);
            int currentStartingIndex = default(int);
            int startingIndex = int.MaxValue;
            int largestArraySum = default(int);
            int sequenceCounter = default(int);
            int bestSampleIndex = default(int);
            int[] bestDNA = new int[DNAlength];

            while (true)
            {
                input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }


                sequence = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                sequenceCounter++;
                biggestSumForCurrentSequence = 0;

                for (int i = 0; i < sequence.Length; i++)
                {
                    sum = 0;

                    while (sequence[i] == 1)
                    {
                        sum++;
                        i++;
                        if (i == sequence.Length)
                        {
                            break;
                        }
                    }

                    if (biggestSumForCurrentSequence < sum)
                    {
                        biggestSumForCurrentSequence = sum;
                        currentStartingIndex = i - sum;
                    }
                }

                int currentSumOfArray = sequence.Sum();

                if (biggestSumForCurrentSequence > biggestSum)
                {
                    biggestSum = biggestSumForCurrentSequence;
                    startingIndex = currentStartingIndex;
                    largestArraySum = sequence.Sum();
                    bestSampleIndex = sequenceCounter;
                    bestDNA = sequence;
                }
                else if (biggestSumForCurrentSequence == biggestSum)
                {
                    if (startingIndex > currentStartingIndex)
                    {
                        biggestSum = biggestSumForCurrentSequence;
                        startingIndex = currentStartingIndex;
                        largestArraySum = sequence.Sum();
                        bestSampleIndex = sequenceCounter;
                        bestDNA = sequence;
                    }
                    else if (startingIndex == currentStartingIndex && currentSumOfArray > largestArraySum)
                    {
                        biggestSum = biggestSumForCurrentSequence;
                        startingIndex = currentStartingIndex;
                        largestArraySum = currentSumOfArray;
                        bestSampleIndex = sequenceCounter;
                        bestDNA = sequence;
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestSampleIndex} with sum: {largestArraySum}.");
            Console.WriteLine(string.Join(" ", bestDNA));
        }
    }
}

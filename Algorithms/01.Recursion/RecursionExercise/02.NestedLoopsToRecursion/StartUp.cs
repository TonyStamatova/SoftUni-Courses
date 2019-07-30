namespace _02.NestedLoopsToRecursion
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfLoops = int.Parse(Console.ReadLine());

            Loop(new int[numberOfLoops],  0);
        }

        private static void Loop(int[] loopSequence, int index)
        {
            if (index == loopSequence.Length)
            {
                Console.WriteLine(string.Join(" ",loopSequence));
                return;
            }

            for (int i = 1; i <= loopSequence.Length; i++)
            {
                loopSequence[index] = i;
                Loop(loopSequence, index + 1);
            }
        }
    }
}

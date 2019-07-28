namespace P04Generating01Vectors
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            int[] vector = new int[length];

            GenerateCombinations(vector, 0);
        }

        public static void GenerateCombinations(int[] vector, int index)
        {
            if (index == vector.Length)
            {                
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <=1; i++)
            {
                vector[index] = i;
                GenerateCombinations(vector, index + 1);
            }
        }
    }
}

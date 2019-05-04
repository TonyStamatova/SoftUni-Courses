using System;

namespace printNumsInReverse
{
    class Program
    {
        static void Main()
        {
            int countOfNums = int.Parse(Console.ReadLine());

            double[] nums = new double[countOfNums];

            for (int i = countOfNums - 1; i >= 0; i--)
            {
                nums[i] = double.Parse(Console.ReadLine());
            }

            string result = string.Join(" ", nums);
            Console.WriteLine(result);
        }
    }
}

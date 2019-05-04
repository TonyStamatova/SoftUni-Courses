using System;
using System.Linq;

namespace roundingNumbers
{
    class Program
    {
        static void Main()
        {
            double[] nums = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < nums.Length; i++)
            {                
                Console.WriteLine(Math.Round(nums[i], 0, 
                    MidpointRounding.AwayFromZero));
            }
        }
    }
}

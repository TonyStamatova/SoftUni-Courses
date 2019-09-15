using System;
using System.Linq;
using System.Numerics;

public class StartUp
{
    public static void Main()
    {
        int majorityCount = int.Parse(Console.ReadLine());
        int parties = int.Parse(Console.ReadLine());

        int[] partySeats = new int[parties];

        for (int i = 0; i < parties; i++)
        {
            partySeats[i] = int.Parse(Console.ReadLine());
        }

        int totalSum = partySeats.Sum();

        BigInteger[] sums = new BigInteger[totalSum + 1];
        sums[0] = 1;
        BigInteger sum = 0;

        for (int i = 0; i < parties; i++)
        {
            for (int j = sums.Length - 1 - partySeats[i]; j >= 0; j--)
            {
                sum = sums[j];

                if (sum != 0)
                {
                    sums[j + partySeats[i]] += sum;
                }
            }
        }

        BigInteger result = 0;
        BigInteger currentSum = 0;

        for (int i = majorityCount; i < sums.Length; i++)
        {
            currentSum = sums[i];

            if (currentSum != 0)
            {
                result += currentSum;
            }
        }

        Console.WriteLine(result);
    }
}


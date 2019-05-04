using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToList();

        int maxNumber = 0;
        int maxCount = 0;

        int currentCount = 1;

        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[j] == numbers[i])
                {
                    currentCount++;
                }
                else
                {
                    break;
                }
            }

            if (currentCount > maxCount)
            {
                maxNumber = numbers[i];
                maxCount = currentCount;
            }

            currentCount = 1;
        }

        for (int i = 0; i < maxCount; i++)
        {
            Console.Write(maxNumber + " ");
        }

        Console.WriteLine();
    }
}


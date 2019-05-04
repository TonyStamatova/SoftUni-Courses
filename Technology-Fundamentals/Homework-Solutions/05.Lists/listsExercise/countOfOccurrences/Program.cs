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
        .Select(x => int.Parse(x)).ToList();

        numbers.Sort();

        List<int> occurredNums = new List<int>();

        int occurrences = 1;

        for (int i = 0; i < numbers.Count; i++)
        {

            if (!occurredNums.Contains(numbers[i]))
            {
                for (int j = i+1; j < numbers.Count; j++)
                {
                    if (numbers[j] == numbers[i])
                    {
                        occurrences++;
                    }
                }
                Console.WriteLine($"{numbers[i]} -> {occurrences} times");

                occurredNums.Add(numbers[i]);
            }

            occurrences = 1;
        }
    }
}


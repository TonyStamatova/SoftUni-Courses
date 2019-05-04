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

        int sum = 0;
        double average = 0;
        double count = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
            count++;
        }

        average = sum / count;
        if (sum == 0)
        {
            average = 0;
        }

        Console.WriteLine($"Sum={sum}; Average={average:f2}");
    }
}

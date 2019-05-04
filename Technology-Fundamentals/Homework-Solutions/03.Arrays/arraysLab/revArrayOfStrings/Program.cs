using System;
using System.Linq;

namespace revArrayOfStrings
{
    class Program
    {
        static void Main()
        {
            string[] array = Console.ReadLine().Split();
            string[] revArray = new string[array.Length];

            int indexInRevArray = revArray.Length-1;
            foreach (var item in array)
            {
                revArray[indexInRevArray] = item;
                indexInRevArray--;
            }

            string result = string.Join(" ",revArray);
            Console.WriteLine(result);
        }
    }
}

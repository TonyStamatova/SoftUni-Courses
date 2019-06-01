using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _05.multiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();            

            int multiplier = int.Parse(Console.ReadLine());
            List<int> newNumber = new List<int>();
            int number = default(int);
            int digit = default(int);
            int carry = default(int);

            if (multiplier != 0 && input.Length != 0)
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {                    
                    number = int.Parse(input[i].ToString()) * multiplier + carry;

                    if (number == 0)
                    {
                        newNumber.Add(0);
                        carry = 0;
                        continue;
                    }

                    digit = number % 10;
                    carry = number / 10;
                    newNumber.Add(digit);
                }

                if (carry != 0)
                {
                    newNumber.Add(carry);
                }

                newNumber.Reverse();
                string result = string.Join("", newNumber);
                Match zeroPrefix = Regex.Match(result, @"(?<=^)0+");
                if (zeroPrefix.Length != 0)
                {
                    result = result.Replace(zeroPrefix.ToString(), "");
                }

                Console.WriteLine(result);                
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}

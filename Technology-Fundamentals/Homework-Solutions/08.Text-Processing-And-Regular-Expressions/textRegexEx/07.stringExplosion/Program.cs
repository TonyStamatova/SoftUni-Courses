using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.stringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strength = default(int);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                }
                else if(strength > 0)
                {
                    strength--;
                    input = input.Remove(i, 1);
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}

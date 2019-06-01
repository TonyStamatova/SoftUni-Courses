using System;

namespace _05.stringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    int strength = int.Parse(input[i + 1].ToString());

                    for (int j = i; j < i + strength; j++)
                    {
                        if (input[j] == '>')
                        {
                            strength += int.Parse(input[j + 1].ToString());
                        }
                    }

                    input.Remove(input[i + 1], Math.Min(strength, input.Length - i - 1));
                }                
            }

            Console.WriteLine(input);
        }
    }
}

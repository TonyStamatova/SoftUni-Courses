using System;
using System.Text;

namespace stringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {            
                result.Append(input[i]);

                if (input[i] == '>')
                {
                    int startIndex = i + 1;
                    int strength = int.Parse(input[i + 1].ToString());

                    if (strength == 0)
                    {
                        continue;
                    }

                    int j = default(int);
                    for (j = startIndex; j < startIndex + strength; j++)
                    {
                        if (j == input.Length - 1)
                        {
                            break;
                        }

                        if (input[j] == '>')
                        {
                            result.Append(input[j]);
                            strength++;
                            int addedStrength = int.Parse(input[j + 1].ToString());
                            strength += addedStrength;
                        }
                    }

                    i = j - 1;
                }
            }

            Console.WriteLine(result);
        }
    }
}

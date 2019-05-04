using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            string input = string.Empty;
            bool isBalanced = true;

            for (int i = 0; i < numberOfLines; i++)
            {
                if ((input = Console.ReadLine()) == "(")
                {
                    isBalanced = false;

                    for (int j = i + 1; j < numberOfLines; j++)
                    {
                        i++;

                        if ((input = Console.ReadLine()) == "(")
                        {
                            break;
                        }
                        else if (input == ")")
                        {
                            isBalanced = true;
                            break;
                        }
                    }
                }
                else if (input == ")")
                {
                    isBalanced = false;

                    //for (int j = i + 1; j < numberOfLines; j++)
                    //{
                    //    i++;

                    //    if ((input = Console.ReadLine()) == "(")
                    //    {
                    //        isBalanced = true;
                    //        break;
                    //    }
                    //}

                    break;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}

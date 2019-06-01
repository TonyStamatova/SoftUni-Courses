using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine().ToLower();

            while (input != "stop")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = command[0].ToLower();

                switch (action)
                {
                    case "delete":
                        int index = int.Parse(command[1]);
                        //if (CheckIfValid(index, words))
                        //{
                            if (CheckIfValid(index + 1, words))
                            {
                                words.RemoveAt(index + 1);
                            }
                        //}
                        break;
                    case "swap":
                        string firstWord = command[1];
                        string secondWord = command[2];
                        if (words.Contains(firstWord) && words.Contains(secondWord))
                        {
                            int firstInd = words.IndexOf(firstWord);
                            int secondInd = words.IndexOf(secondWord);
                            words[firstInd] = secondWord;
                            words[secondInd] = firstWord;
                        }                        
                        break;
                    case "put":
                        string word = command[1];
                        int nextIndex = int.Parse(command[2]);
                        if (nextIndex - 1 <= words.Count && nextIndex - 1 >= 0)
                        {
                            words.Insert(nextIndex - 1, word);
                        }
                        break;
                    case "sort":
                        words.Sort();
                        words.Reverse();
                        break;
                    case "replace":
                        string newWord = command[1];
                        string wordToReplace = command[2];
                        if (words.Contains(wordToReplace))
                        {
                            int indexToChange = words.IndexOf(wordToReplace);
                            words[indexToChange] = newWord;
                        }
                        break;
                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine(string.Join(" ", words));
        }

        private static bool CheckIfValid(int index, List<string> list)
        {
            if (index >= 0 && index < list.Count)
            {
                return true;
            }

            return false;
        }
    }
}

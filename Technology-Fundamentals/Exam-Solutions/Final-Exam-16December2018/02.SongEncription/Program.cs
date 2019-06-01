using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _02.songEncription
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                Match artist = Regex.Match(input, @"(?<=^)[A-Z]{1}[a-z' ]+(?=:)");
                Match song = Regex.Match(input, @"(?<=:)[A-Z ]+(?=$)");

                if (artist.ToString() == "" || song.ToString() == "")
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                int key = artist.Length;

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    char newChar = input[i];

                    if (Char.IsLetter(newChar))
                    {
                        if (Char.IsLower(newChar))
                        {
                            for (int j = 0; j < key; j++)
                            {
                                newChar++;

                                if (newChar == 'z' && j < key - 1)
                                {
                                    j++;
                                    newChar = 'a';
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < key; j++)
                            {
                                newChar++;

                                if (newChar == 'Z' && j < key - 1)
                                {
                                    j++;
                                    newChar = 'A';
                                }
                            }
                        }
                    }
                    else if (newChar == ':')
                    {
                        newChar = '@';
                    }

                    builder.Append(newChar);
                }

                Console.WriteLine($"Successful encryption: {builder}");
                input = Console.ReadLine();
            }
        }
    }
}

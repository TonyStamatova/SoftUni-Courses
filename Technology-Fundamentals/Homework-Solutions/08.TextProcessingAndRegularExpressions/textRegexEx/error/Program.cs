using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

namespace _09.starEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                MatchCollection starLetters = Regex.Matches(message, @"(?i)[star]");
                int subtr = starLetters.Count;
                StringBuilder decryptedMessage = new StringBuilder();

                for (int j = 0; j < message.Length; j++)
                {
                    char current = (char)((int)message[j] - subtr);
                    decryptedMessage.Append(current);
                }

                message = decryptedMessage.ToString();
                string pattern 
                    = @"(@(?<name>[a-zA-Z]+))(?:[^-\@!:>]*)(:[0-9]+)(?:[^-\@!:>]*)(!(?<attackType>[AD]{1})!)(?:[^-\@!:>]*)(->[0-9]+)";
                Match match = Regex.Match(message, pattern);

                string planet = match.ToString();
                if (planet != "")
                {
                    string name = match.Groups["name"].Value;
                    string attackType = match.Groups["attackType"].Value;

                    switch (attackType)
                    {
                        case "A":
                            attackedPlanets.Add(name);
                            break;
                        case "D":
                            destroyedPlanets.Add(name);
                            break;
                    }
                }                
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets.Sort();

            foreach (var planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.Sort();

            foreach (var planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
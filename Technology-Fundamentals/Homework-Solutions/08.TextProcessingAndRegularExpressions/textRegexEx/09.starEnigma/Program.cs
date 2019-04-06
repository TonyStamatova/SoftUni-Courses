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
                string name = Regex.Match(message, @"\@[a-zA-Z]+").ToString();
                int nameIndex = message.IndexOf(name);
                string population = Regex.Match(message, @":\d+").ToString();
                int populationIndex = message.IndexOf(population);
                string attackType = Regex.Match(message, @"![AD]{1}!").ToString();
                int attackIndex = message.IndexOf(attackType);
                string soldierCount = Regex.Match(message, @"(->)\d+").ToString();
                int soldierIndex = message.IndexOf(soldierCount);

                if (name != null
                    && population != null
                    && attackType != null
                    && soldierCount != null
                    && message.IndexOf(name) < message.IndexOf(population)
                    && message.IndexOf(population) < message.IndexOf(attackType)
                    && message.IndexOf(attackType) < message.IndexOf(soldierCount))
                {
                    name = name.TrimStart('@');
                    attackType = attackType.Trim('!');
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

            //            Attacked planets: 1
            //->Alderaa
            //Destroyed planets: 1
            //->Cantonica

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

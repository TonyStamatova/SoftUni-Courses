using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _01.AnimalSanctuary
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            int totWeight = default(int);

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();
                Match validMessage = Regex.Match(input,
                    @"n:(?<name>[^;]+);t:(?<kind>[^;]+);c--(?<country>[a-zA-Z\s]+)$");

                if (validMessage.Value == "")
                {
                    continue;
                }

                string nameBeforeDecryption = validMessage.Groups["name"].ToString();
                string kindBeforeDecryption = validMessage.Groups["kind"].ToString();

                MatchCollection nameParts = Regex.Matches(nameBeforeDecryption, @"[a-zA-Z\s]+");                
                MatchCollection kindParts = Regex.Matches(kindBeforeDecryption, @"[a-zA-Z\s]+");

                string name = string.Join("", nameParts);
                string kind = string.Join("", kindParts);
                string country = validMessage.Groups["country"].ToString();

                Console.WriteLine($"{name} is a {kind} from {country}");
                
                totWeight += CalculateAnimalWeight(nameBeforeDecryption);
                totWeight += CalculateAnimalWeight(kindBeforeDecryption);
            }

            Console.WriteLine($"Total weight of animals: {totWeight}KG");
        }

        private static int CalculateAnimalWeight(string str)
        {
            int addedWeight = default(int);

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    addedWeight += int.Parse(str[i].ToString());
                }
            }

            return addedWeight;
        }
    }
}

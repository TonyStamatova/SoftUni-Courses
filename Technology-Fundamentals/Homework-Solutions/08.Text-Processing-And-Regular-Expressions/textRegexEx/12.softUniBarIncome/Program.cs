using System;
using System.Text.RegularExpressions;

namespace _12.softUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double totIncome = default(double);

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, @"(%(?<customer>[A-Z][a-z]+)%)(?:[^\|\$\.%]*)(<(?<product>\w+)>)(?:[^\|\$\.%]*)(\|(?<count>\d+)\|)(?:[^\|\$\.%\d]*)((?<price>\d+(\.\d*)?)\$)");
                
                if (match.ToString() != string.Empty)
                {
                    double totPrice = int.Parse(match.Groups["count"].Value.ToString()) 
                        * double.Parse(match.Groups["price"].Value.ToString());
                    Console.WriteLine($"{match.Groups["customer"].Value.ToString()}: {match.Groups["product"].Value.ToString()} - " +
                        $"{totPrice:f2}");
                    totIncome += totPrice;
                }
            }

            Console.WriteLine($"Total income: {totIncome:f2}");
        }
    }
}

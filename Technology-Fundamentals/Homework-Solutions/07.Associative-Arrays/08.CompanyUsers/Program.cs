using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.companyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (input != "End")
            {
                string[] data = input.Split(" -> ");
                string companyName = data[0];
                string employeeId = data[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }

                if (!companies[companyName].Contains(employeeId))
                {
                    companies[companyName].Add(employeeId);
                }

                input = Console.ReadLine();
            }

            companies = companies.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in companies)
            {
                Console.WriteLine(item.Key);
                foreach (var employee in item.Value)
                {
                    Console.WriteLine("-- " + employee);
                }
            }
        }
    }
}

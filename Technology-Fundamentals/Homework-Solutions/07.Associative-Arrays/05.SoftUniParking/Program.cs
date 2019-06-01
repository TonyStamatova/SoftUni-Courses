using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.softUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> carsByUsername = new Dictionary<string, string>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string username = input[1];

                switch (command)
                {
                    case "register":
                        string plate = input[2];
                        if (!carsByUsername.ContainsKey(username))
                        {
                            carsByUsername.Add(username, plate);
                            Console.WriteLine($"{username} registered {plate} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {plate}");
                        }
                        break;
                    case "unregister":
                        if (!carsByUsername.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        else
                        {
                            carsByUsername.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (var item in carsByUsername)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}

namespace _07.SoftUniParty
{
    using System;
    using System.Collections.Generic;

    public class SoftUniParty
    {
        public static void Main()
        {
            var vip = new HashSet<string>();
            var regular = new HashSet<string>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }
                else if (regular.Contains(input))
                {
                    regular.Remove(input);
                }
            }

            var countOfNonAttending = vip.Count + regular.Count;
            Console.WriteLine(countOfNonAttending);
            PrintGuests(vip);
            PrintGuests(regular);
        }

        private static void PrintGuests(HashSet<string> list)
        {
            foreach (var guest in list)
            {
                Console.WriteLine(guest);
            }
        }
    }
}

namespace _04.Telephony.Core
{
    using System;

    using _04.Telephony.Models;

    public static class Engine
    {
        public static void Start()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            Smartphone phone = new Smartphone(phoneNumbers, sites);

            Console.WriteLine(phone);
        }
    }
}

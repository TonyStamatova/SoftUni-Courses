namespace _03.Ferrari.Core
{
    using System;

    using _03.Ferrari.Models;

    public static class Engine
    {
        public static void Start()
        {
            string driver = Console.ReadLine();

            Ferrari newFerrari = new Ferrari(driver);
            Console.WriteLine(newFerrari);
        }
    }
}

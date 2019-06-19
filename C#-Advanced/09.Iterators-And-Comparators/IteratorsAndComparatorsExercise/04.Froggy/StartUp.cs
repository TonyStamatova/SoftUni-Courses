namespace _04.Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] stones = Console.ReadLine()
                  .Split(", ")
                  .Select(int.Parse)
                  .ToArray();

            Lake lochness = new Lake(stones);

            Console.WriteLine(string.Join(", ", lochness));
        }
    }
}

namespace _04.AddVAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
        {
            string[] prices = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(addVAT)
                .Select(format)
                .ToArray();
            
            Console.WriteLine(string.Join(Environment.NewLine, prices));
        }

        static Func<double, double> addVAT = x => x *= 1.2;
        static Func<double, string> format = x => $"{x:f2}";
    }
}

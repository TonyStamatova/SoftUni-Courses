namespace _01.BinomialCoefficients
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<string, long> calculated;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            calculated = new Dictionary<string, long>();

            Console.WriteLine(CalculateCoeficient(n, k));
        }

        private static long CalculateCoeficient(int n, int k)
        {
            if (n == k) return 1;

            if (k == 1) return n;
           
            if (k == 0) return 1;
            
            string key = $"{n}{k}";

            if (calculated.ContainsKey(key))
            {
                return calculated[key];
            }

            long result = CalculateCoeficient(n - 1, k) + CalculateCoeficient(n - 1, k - 1);
            calculated.Add(key, result);

            return result;
        }
    }
}

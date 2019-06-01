using System;
using System.Globalization;

namespace _04.BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.ParseExact(Console.ReadLine() + ":" + Console.ReadLine(), "H:mm",
                CultureInfo.InvariantCulture);
            time = time.AddMinutes(30);
            Console.WriteLine(time.ToString("H:mm"));
        }
    }
}

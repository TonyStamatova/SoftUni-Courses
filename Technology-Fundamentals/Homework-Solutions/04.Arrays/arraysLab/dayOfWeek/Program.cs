using System;

namespace dayOfWeek
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            string[] daysOfWeek = new string[] { "Monday", "Tuesday", "Wednesday",
                "Thursday", "Friday", "Saturday", "Sunday"};

            string result = string.Empty;

            if (num < 1 || num > 7)
            {
                result = "Invalid day!";
            }
            else
            {
                result = daysOfWeek[num - 1];
            }

            Console.WriteLine(result);
        }
    }
}

using System;

namespace _03.vacation
{
    class Program
    {
        public static void Main()
        {
            int people = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            decimal total = default(decimal);

            switch (typeOfGroup)
            {
                case "Students":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            total = 8.45m * people;
                            break;
                        case "Saturday":
                            total = 9.80m * people;
                            break;
                        case "Sunday":
                            total = 10.46m * people;
                            break;
                    }
                    if (people >= 30)
                    {
                        total -= 0.15m * total;
                    }
                    break;
                case "Business":
                    if (people >= 100)
                    {
                        people -= 10;
                    }
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            total = 10.90m * people;
                            break;
                        case "Saturday":
                            total = 15.60m * people;
                            break;
                        case "Sunday":
                            total = 16m * people;
                            break;
                    }
                    break;
                case "Regular":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            total = 15m * people;
                            break;
                        case "Saturday":
                            total = 20m * people;
                            break;
                        case "Sunday":
                            total = 22.5m * people;
                            break;
                    }
                    if (people >= 10 && people <= 20)
                    {
                        total -= 0.05m * total;
                    }
                    break;
            }

            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}

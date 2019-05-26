using System;

namespace _07.theatrePromotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string price = string.Empty;

            if (age < 0 || age > 122)
            {
                price = "Error!";
            }
            else if (age <= 18)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        price = "12$";
                        break;
                    case "Weekend":
                        price = "15$";
                        break;
                    case "Holiday":
                        price = "5$";
                        break;
                }
            }
            else if (age <= 64)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        price = "18$";
                        break;
                    case "Weekend":
                        price = "20$";
                        break;
                    case "Holiday":
                        price = "12$";
                        break;
                }
            }
            else
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        price = "12$";
                        break;
                    case "Weekend":
                        price = "15$";
                        break;
                    case "Holiday":
                        price = "10$";
                        break;
                }
            }

            Console.WriteLine(price);
        }
    }
}

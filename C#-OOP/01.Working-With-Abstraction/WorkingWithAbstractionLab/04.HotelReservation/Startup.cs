namespace _04.HotelReservation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();

            decimal pricePerDay = decimal.Parse(input[0]);
            int days = int.Parse(input[1]);

            Season season;
            Enum.TryParse(input[2], out season);

            Discount discount;
            if (input.Length == 4)
            {
                Enum.TryParse(input[3], out discount);
            }
            else
            {
                discount = Discount.None;
            }

            decimal totalPrice = PriceCalculator.GetTotalPrice(pricePerDay, days, season, discount);

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

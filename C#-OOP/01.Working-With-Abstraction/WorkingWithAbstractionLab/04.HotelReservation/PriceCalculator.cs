namespace _04.HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(
            decimal pricePerDay,
            int numberOfDays,
            Season season,
            Discount discountType)
        {
            pricePerDay *= (int)season;

            decimal discount = pricePerDay * ((decimal)discountType / 100);
            pricePerDay -= discount;

            decimal totalPrice = numberOfDays * pricePerDay;

            return totalPrice;
        }
    }
}

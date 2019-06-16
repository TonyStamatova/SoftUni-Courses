namespace HealthyHeaven
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Restaurant restaurant = new Restaurant("Casa Domingo");

            Vegetable tomato = new Vegetable("Tomato", 20);
            Vegetable cucumber = new Vegetable("Cucumber", 15);

            Salad salad = new Salad("Tomatoes with cucumbers");

            salad.Add(tomato);
            salad.Add(cucumber);

            Console.WriteLine(salad.GetTotalCalories());
            Console.WriteLine(salad.GetProductCount());

            Console.WriteLine(salad.ToString());

            restaurant.Add(salad);

            Console.WriteLine(restaurant.Buy("Invalid salad"));

            Vegetable corn = new Vegetable("Corn", 90);

            Salad casaDomingo = new Salad("Casa Domingo");

            casaDomingo.Add(tomato);
            casaDomingo.Add(cucumber);
            casaDomingo.Add(corn);

            restaurant.Add(casaDomingo);

            Console.WriteLine(restaurant.GetHealthiestSalad());
            Console.WriteLine(restaurant.GenerateMenu());
        }
    }
}
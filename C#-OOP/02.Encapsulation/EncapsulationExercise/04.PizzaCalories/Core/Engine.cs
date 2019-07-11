namespace _04.PizzaCalories.Core
{
    using _04.PizzaCalories.Models;
    using System;

    public class Engine
    {
        public static void Start()
        {
            try
            {
                string inputString = Console.ReadLine();

                string[] pizzaInput = inputString.Split();
                //string pizza = pizzaInput[0];
                string name = pizzaInput[1];

                inputString = Console.ReadLine();

                string[] doughtInput = inputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //string ingredient = doughtInput[0];
                string type = doughtInput[1];
                string technique = doughtInput[2];
                int weight = int.Parse(doughtInput[3]);

                Dough dough = new Dough(type, technique, weight);
                Pizza newPizza = new Pizza(name, dough);

                while ((inputString = Console.ReadLine()).ToUpper() != "END")
                {
                    string[] toppingInput = inputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    //ingredient = toppingInput[0];
                    type = toppingInput[1];
                    weight = int.Parse(toppingInput[2]);

                    //try
                    //{
                    Topping topping = new Topping(type, weight);
                    newPizza.AddTopping(topping);
                    //}
                    //catch (ArgumentException ex)
                    //{
                    //    throw new ArgumentException(ex.Message);
                    //}
                }

                int toppings = newPizza.NumberOfToppings;

                Console.WriteLine($"{newPizza.Name} - {newPizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

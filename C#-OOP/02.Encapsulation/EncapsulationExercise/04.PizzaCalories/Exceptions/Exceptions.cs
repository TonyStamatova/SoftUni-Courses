using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories.Exceptions
{
    public static class Exceptions
    {
        public const string INVALID_DOUGH_TYPE_EXCEPTION_MESSAGE = "Invalid type of dough.";
        public const string INVALID_DOUGH_WEIGHT_EXCEPTION_MESSAGE = "Dough weight should be in the range [1..200].";

        public const string INVALID_TOPPING_TYPE_EXCEPTION_MESSAGE = "Cannot place {0} on top of your pizza.";
        public const string INVALID_TOPPING_WEIGHT_EXCEPTION_MESSAGE ="{0} weight should be in the range[1..50].";

        public const string INVALID_PIZZA_NAME_EXCEPTION_MESSAGE = "Pizza name should be between 1 and 15 symbols.";
        public const string INVALID_TOPPING_COUNT_EXCEPTION_MESSAGE = "Number of toppings should be in range [0..10].";
    }
}

﻿namespace _03.WildFarm.Models.Food
{
    using _03.WildFarm.Contracts;

    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}

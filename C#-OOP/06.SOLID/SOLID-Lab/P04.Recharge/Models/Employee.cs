﻿namespace P04.Recharge.Models
{
    using P04.Recharge.Contracts;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }
    }
}

namespace _01.Vehicles.Validation
{
    using System;

    using _01.Vehicles.Exceptions;

    public static class Validator
    {
        public static void ValidateFuelQuantity(double fuelAmount, double tankCapacity, double fuelQuantity)
        {
            double remainingTankCapacity = tankCapacity - fuelQuantity;

            if (fuelAmount > remainingTankCapacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.TankOverflowMessage, fuelAmount));
            }

            if (fuelAmount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ZeroOrNegativeFuelMessage);
            }
        }
    }
}

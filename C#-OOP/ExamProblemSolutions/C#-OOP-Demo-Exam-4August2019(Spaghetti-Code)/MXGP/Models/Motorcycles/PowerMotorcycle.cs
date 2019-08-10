using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int MIN_HORSE_POWER = 70;
        private const int MAX_HORSE_POWER = 100;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, 450)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MIN_HORSE_POWER || value > MAX_HORSE_POWER)
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
    }
}

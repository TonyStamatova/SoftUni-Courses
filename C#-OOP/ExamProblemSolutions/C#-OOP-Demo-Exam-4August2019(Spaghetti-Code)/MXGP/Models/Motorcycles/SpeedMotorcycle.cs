using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int MIN_HORSE_POWER = 50;
        private const int MAX_HORSE_POWER = 69;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 125)
        {
        }

        public  override int HorsePower
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

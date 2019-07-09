namespace _01.ClassBoxData
{
    using System;
    
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get => this.length;

             set
            {
                if (value <= 0)
                {
                    throw new Exception($"{nameof(this.Length)} cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        private double Width
        {
            get => this.width;

            set
            {
                if (value <= 0)
                {
                    throw new Exception($"{nameof(this.Width)} cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        private double Height
        {
            get => this.height;

            set
            {
                if (value <= 0)
                {
                    throw new Exception($"{nameof(this.Height)} cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        private double GetSurfaceArea()
        {
            return 2 * this.Length * this.Width +
                   2 * this.Length * this.Height +
                   2 * this.Width * this.Height;
        }

        private double GetLateralSurfaceArea()
        {
            return 2 * this.Length * this.Height +
                   2 * this.Width * this.Height;
        }

        private double GetVolume()
        {
            return this.Length * this.Height * this.Width;
        }

        public string Results()
        {
            return $"Surface Area - {GetSurfaceArea():f2}"
                   + Environment.NewLine + $"Lateral Surface Area - {GetLateralSurfaceArea():f2}"
                   + Environment.NewLine + $"Volume - {GetVolume():f2}";
        }
    }
}

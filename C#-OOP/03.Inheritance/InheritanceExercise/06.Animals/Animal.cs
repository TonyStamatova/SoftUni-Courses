namespace Animals
{
    using System;
    using System.Text;

    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        
        public string Name
        {
            get => this.name;

            private set
            {
                if (value.Length < 2)
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;

            private set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{this.GetType().Name}");
            builder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            builder.AppendLine($"{this.ProduceSound()}");

            return builder.ToString().TrimEnd();
        }
    }
}

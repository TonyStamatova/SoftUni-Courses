namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
        }

        public override int Age
        {
            protected set
            {
                if (base.Age <= 15)
                {
                    this.Age = Age;
                }
            }
        }
    }
}

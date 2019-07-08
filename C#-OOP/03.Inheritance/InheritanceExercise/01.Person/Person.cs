namespace Person
{
    public abstract class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public virtual int Age
        {
            get => this.age;

            protected set
            {
                if (this.age >= 0)
                {
                    this.age = value;
                }                
            }
        }

        public override string ToString()
        {
           return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}

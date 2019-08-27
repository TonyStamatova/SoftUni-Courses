namespace _06.ValidPerson
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                ValidateName(value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                ValidateName(value);
                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Age should be an integer between 0 and 120!");
                }

                this.age = value;
            }
        }

        private static void ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", "Name should not be null or empty!");
            }
        }
    }
}

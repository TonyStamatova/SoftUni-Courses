namespace _06.EqualityLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Person : IComparable<Person>
    {
        public Person(params string[] personData)
        {
            this.Name = personData[0];
            this.Age = int.Parse(personData[1]);
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   this.Name == person.Name &&
                   this.Age == person.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Age);
        }
    }
}

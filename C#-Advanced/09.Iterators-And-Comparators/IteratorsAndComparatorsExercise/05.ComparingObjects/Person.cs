namespace _05.ComparingObjects
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
            this.Town = personData[2];
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            if (result == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}

namespace Repository
{
    using System.Collections.Generic;

    public class Repository
    {
        private Dictionary<int, Person> people;
        private int idCounter;

        public Repository()
        {
            this.people = new Dictionary<int, Person>();
            this.idCounter = 0;
        }

        public int Count => this.people.Count;

        public void Add(Person person)
        {
            this.people.Add(idCounter, person);
            idCounter++;
        }

        public Person Get(int id)
        {
            return this.people[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (!this.people.ContainsKey(id))
            {
                return false;
            }

            this.people[id] = newPerson;
            return true;
        }

        public bool Delete(int id)
        {
            return this.people.Remove(id);
        }
    }
}

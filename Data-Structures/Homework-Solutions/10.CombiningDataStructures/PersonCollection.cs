using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> byEmail = new Dictionary<string, Person>();

    private Dictionary<string, SortedDictionary<string, Person>> byDomain
        = new Dictionary<string, SortedDictionary<string, Person>>();

    private Dictionary<string, SortedDictionary<string, Person>> byNameAndTown
        = new Dictionary<string, SortedDictionary<string, Person>>();

    private OrderedDictionary<int, SortedDictionary<string, Person>> byAge
        = new OrderedDictionary<int, SortedDictionary<string, Person>>();

    private Dictionary<string,
        OrderedDictionary<int, SortedDictionary<string, Person>>> byAgeAndTown
        = new Dictionary<string,
            OrderedDictionary<int, SortedDictionary<string, Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.byEmail.ContainsKey(email))
        {
            return false;
        }

        Person person = new Person(email, name, age, town);
        this.byEmail.Add(email, person);
        this.AddByDomain(email, person);
        this.AddByNameAndTown(person);
        this.AddByAge(person);
        this.AddByTown(person);
        return true;
    }

    private void AddByTown(Person person)
    {
        string town = person.Town;
        int age = person.Age;

        if (!this.byAgeAndTown.ContainsKey(town))
        {
            this.byAgeAndTown[town]
                = new OrderedDictionary<int, SortedDictionary<string, Person>>();
        }

        if (!this.byAgeAndTown[town].ContainsKey(age))
        {
            this.byAgeAndTown[town][age] = new SortedDictionary<string, Person>();
        }

        this.byAgeAndTown[town][age].Add(person.Email, person);
    }

    private void AddByAge(Person person)
    {
        int age = person.Age;

        if (!this.byAge.ContainsKey(age))
        {
            byAge[age] = new SortedDictionary<string, Person>();
        }

        this.byAge[age].Add(person.Email, person);
    }

    private void AddByNameAndTown(Person person)
    {
        string key = person.Name + " " + person.Town;

        if (!this.byNameAndTown.ContainsKey(key))
        {
            this.byNameAndTown[key] = new SortedDictionary<string, Person>();
        }

        this.byNameAndTown[key].Add(person.Email, person);
    }

    private void AddByDomain(string email, Person person)
    {
        string domain = email.Split('@')[1];

        if (!this.byDomain.ContainsKey(domain))
        {
            this.byDomain[domain] = new SortedDictionary<string, Person>();
        }

        this.byDomain[domain].Add(email, person);
    }

    public int Count
    {
        get
        {
            return this.byEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (!this.byEmail.ContainsKey(email))
        {
            return null;
        }

        return this.byEmail[email];
    }

    public bool DeletePerson(string email)
    {
        if (!this.byEmail.ContainsKey(email))
        {
            return false;
        }

        Person person = this.byEmail[email];
        this.byEmail.Remove(email);
        string domain = email.Split('@')[1];
        this.byDomain[domain].Remove(email);
        string key = person.Name + " " + person.Town;
        this.byNameAndTown[key].Remove(email);
        int age = person.Age;
        this.byAge[age].Remove(email);
        this.byAgeAndTown[person.Town][person.Age].Remove(email);
        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!this.byDomain.ContainsKey(emailDomain))
        {
            return new List<Person>();
        }

        return this.byDomain[emailDomain].Values;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string key = name + " " + town;

        if (!this.byNameAndTown.ContainsKey(key))
        {
            return new List<Person>();
        }

        return this.byNameAndTown[key].Values;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var result = this.byAge.Range(startAge, true, endAge, true);

        foreach (var item in result)
        {
            foreach (var subItem in item.Value)
            {
                yield return subItem.Value;
            }
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        if (!this.byAgeAndTown.ContainsKey(town))
        {
           return new List<Person>();
        }

        var quiery = this.byAgeAndTown[town].Range(startAge, true, endAge, true);
        List<Person> result = new List<Person>();

        foreach (var item in quiery)
        {
            foreach (var subItem in item.Value)
            {
                result.Add(subItem.Value);
            }
        }

        return result;
    }
}

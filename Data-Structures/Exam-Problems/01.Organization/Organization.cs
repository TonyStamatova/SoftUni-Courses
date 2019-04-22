using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Organization : IOrganization
{
    private MultiDictionary<string, Person> byName;
    private MultiDictionary<int, Person> byNameSize;
    private List<Person> byInsertion;
    
    public Organization()
    {
        this.byName = new MultiDictionary<string, Person>(true);
        this.byInsertion = new List<Person>();
        this.byNameSize = new MultiDictionary<int, Person>(true);
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var item in byInsertion)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public int Count
    {
        get
        {
            return this.byInsertion.Count;
        }
    }   

    public bool Contains(Person person)
    {
        return this.byName.ContainsKey(person.Name);
    }

    public bool ContainsByName(string name)
    {
        return this.byName.ContainsKey(name);
    }

    public void Add(Person person)
    {
        this.byInsertion.Add(person);

        if (this.byName.ContainsKey(person.Name))
        {
            this.byName[person.Name].Add(person);
            this.byNameSize[person.Name.Length].Add(person);
            return;
        }

        this.byName.Add(person.Name, person);
        this.byNameSize.Add(person.Name.Length, person);
    }

    public Person GetAtIndex(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new IndexOutOfRangeException();
        }

        return this.byInsertion[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        return this.byName[name];
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        if (count > this.Count)
        {
            return this.byInsertion;
        }

        return this.byInsertion.GetRange(0, count);
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        List<Person> result = new List<Person>();

        foreach (var item in this.byNameSize)
        {
            if (item.Key >= minLength && item.Key <= maxLength)
            {
                result.AddRange(item.Value);
            }
        }

        return result;
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        if (!this.byNameSize.ContainsKey(length))
        {
            throw new ArgumentException();
        }

        return this.byNameSize[length];
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return this.byInsertion;
    }
}
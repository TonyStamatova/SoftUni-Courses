using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class RoyaleArena : IArena
{
    private Dictionary<int, Battlecard> byId;
    private Dictionary<string, OrderedBag<Battlecard>> byName;
    private OrderedBag<Battlecard> bySwag;

    public RoyaleArena()
    {
        this.byId = new Dictionary<int, Battlecard>();
        this.byName = new Dictionary<string, OrderedBag<Battlecard>>();
        this.bySwag = new OrderedBag<Battlecard>((x, y) => x.Swag.CompareTo(y.Swag));
    }

    public int Count => this.byId.Count;

    public void Add(Battlecard card)
    {
        if (!this.Contains(card))
        {
            this.byId.Add(card.Id, card);

            if (!this.byName.ContainsKey(card.Name))
            {
                this.byName.Add(card.Name, new OrderedBag<Battlecard>((x,y) 
                    => y.Swag.CompareTo(x.Swag)));
            }

            this.byName[card.Name].Add(card);
            this.bySwag.Add(card);
        }
    }

    public void ChangeCardType(int id, CardType type)
    {
        if (!this.byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.byId[id].Type = type;
    }

    public bool Contains(Battlecard card)
    {
        int key = card.Id;
        return this.byId.ContainsKey(key);
    }

    public IEnumerable<Battlecard> FindFirstLeastSwag(int n)
    {
        if (n > this.Count)
        {
            throw new InvalidOperationException();
        }

        return this.bySwag.Take(n).OrderBy(x => x.Id);
    }

    public IEnumerable<Battlecard> GetAllByNameAndSwag()
    {
        if (this.byId.Count == 0)
        {
            yield break;
        }

        foreach (var kvp in this.byName)
        {
            yield return kvp.Value.First();
        }
    }

    public IEnumerable<Battlecard> GetAllInSwagRange(double lo, double hi)
    {
        return this.bySwag.Where(x => x.Swag >= lo && x.Swag <= hi);
    }

    public IEnumerable<Battlecard> GetByCardType(CardType type)
    {
        if (!this.byId.Values.Where(x => x.Type == type).Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values.Where(x => x.Type == type).OrderBy(x => x);
    }

    public IEnumerable<Battlecard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
    {
        if (!this.byId.Values.Where(x => x.Type == type).Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values
            .Where(x => x.Type == type && x.Damage <= damage)
            .OrderBy(x => x);
    }

    public Battlecard GetById(int id)
    {
        if (!this.byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        return this.byId[id];
    }

    public IEnumerable<Battlecard> GetByNameAndSwagRange(string name, double lo, double hi)
    {
        if (!this.byId.Values.Where(x => x.Name == name && x.Swag >= lo
        && x.Swag < hi).Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values
            .Where(x => x.Name == name && x.Swag >= lo && x.Swag < hi)
            .OrderByDescending(x => x.Swag)
            .ThenBy(x => x.Id);
    }

    public IEnumerable<Battlecard> GetByNameOrderedBySwagDescending(string name)
    {
        if (!this.byId.Values.Where(x => x.Name == name).Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values.Where(x => x.Name == name).OrderByDescending(x => x.Swag)
            .ThenBy(x => x.Id);
    }

    public IEnumerable<Battlecard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
    {
        if (!this.byId.Values.Where(x => x.Type == type).Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values
            .Where(x => x.Type == type && x.Damage <= hi && x.Damage > lo)
            .OrderBy(x => x);
    }

    public IEnumerator<Battlecard> GetEnumerator()
    {
        foreach (var kvp in this.byId)
        {
            yield return kvp.Value;
        }
    }

    public void RemoveById(int id)
    {
        if (!this.byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        Battlecard cardToRemove = this.GetById(id);
        this.byId.Remove(id);
        this.byName[cardToRemove.Name].Remove(cardToRemove);
        this.bySwag.Remove(cardToRemove);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

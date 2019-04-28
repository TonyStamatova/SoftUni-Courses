using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{
    private Dictionary<int, Transaction> byId;

    public Chainblock()
    {
        this.byId = new Dictionary<int, Transaction>();
    }

    public int Count => this.byId.Count;

    public void Add(Transaction tx)
    {
        if (!this.byId.ContainsKey(tx.Id))
        {
            this.byId.Add(tx.Id, tx);
        }
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!this.byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.byId[id].Status = newStatus;
    }

    public bool Contains(Transaction tx)
    {
        return this.byId.ContainsKey(tx.Id);
    }

    public bool Contains(int id)
    {
        return this.byId.ContainsKey(id);
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        return this.byId.Values.Where(x => x.Amount >= lo && x.Amount <= hi);
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return this.byId.Values.OrderByDescending(x => x.Amount)
            .ThenBy(x => x.Id);
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        return this.GetByTransactionStatus(status).Select(x => x.To);
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        return this.GetByTransactionStatus(status).Select(x => x.From);
    }

    public Transaction GetById(int id)
    {
        if (!this.byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        return this.byId[id];
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        if (!this.byId.Values
            .Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi)
            .Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values
            .Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi)
            .OrderByDescending(x => x.Amount)
            .ThenBy(x => x.Id);
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        if (!this.byId.Values.Where(x => x.To == receiver).Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values.Where(x => x.To == receiver)
            .OrderByDescending(x => x.Amount)
            .ThenBy(x => x.Id);
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        if (!this.byId.Values.Where(x => x.From == sender && x.Amount > amount).Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values.Where(x => x.From == sender && x.Amount > amount)
            .OrderByDescending(x => x.Amount);
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        if (!this.byId.Values.Where(x => x.From == sender).Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values.Where(x => x.From == sender)
            .OrderByDescending(x => x.Amount);
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (!this.byId.Values.Where(x => x.Status == status).Any())
        {
            throw new InvalidOperationException();
        }

        return this.byId.Values.Where(x => x.Status == status)
            .OrderByDescending(x => x.Amount);
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        return this.byId.Values.Where(x => x.Status == status && x.Amount <= amount)
            .OrderByDescending(x => x.Amount);
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var item in byId)
        {
            yield return item.Value;
        }
    }

    public void RemoveTransactionById(int id)
    {
        if (!this.byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.byId.Remove(id);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


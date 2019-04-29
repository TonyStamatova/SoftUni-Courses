using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

/// <summary>
/// The ThreadExecutor is the concrete implementation of the IScheduler.
/// You can send any class to the judge system as long as it implements
/// the IScheduler interface. The Tests do not contain any <e>Reflection</e>!
/// </summary>
public class ThreadExecutor : IScheduler
{
    int IScheduler.Count => this.byInsertion.Count;

    private Dictionary<int, LinkedListNode<Task>> byInsertion;
    private Dictionary<Priority, OrderedDictionary<int, LinkedListNode<Task>>> byPriority;

    public ThreadExecutor()
    {
        this.byInsertion = new Dictionary<int, LinkedListNode<Task>>();
        this.byPriority = new Dictionary<Priority, OrderedDictionary<int, LinkedListNode<Task>>>();

        this.byPriority.Add(Priority.EXTREME,
            new OrderedDictionary<int, LinkedListNode<Task>>((x, y) => y.CompareTo(x)));
        this.byPriority.Add(Priority.HIGH,
            new OrderedDictionary<int, LinkedListNode<Task>>((x, y) => y.CompareTo(x)));
        this.byPriority.Add(Priority.MEDIUM,
            new OrderedDictionary<int, LinkedListNode<Task>>((x, y) => y.CompareTo(x)));
        this.byPriority.Add(Priority.LOW,
            new OrderedDictionary<int, LinkedListNode<Task>>((x, y) => y.CompareTo(x)));
    }

    public int Count()
    {
        return this.byInsertion.Count;
    }


    public void ChangePriority(int id, Priority newPriority)
    {
        if (!this.byInsertion.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        LinkedListNode<Task> node = this.byInsertion[id];
        this.byPriority[node.Value.TaskPriority].Remove(id);
        this.byInsertion[id].Value.TaskPriority = newPriority;
        this.byPriority[newPriority].Add(id, node);
    }

    public bool Contains(Task task)
    {
        return this.byInsertion.ContainsKey(task.Id);
    }

    public int Cycle(int cycles)
    {
        if (this.byInsertion.Count == 0)
        {
            throw new InvalidOperationException();
        }

        List<int> tasksToRemove = new List<int>();

        foreach (var kvp in byInsertion)
        {
            kvp.Value.Value.currentConsumption -= cycles;

            if (kvp.Value.Value.currentConsumption <= 0)
            {
                tasksToRemove.Add(kvp.Key);
            }
        }

        foreach (var task in tasksToRemove)
        {
            var node = this.byInsertion[task];
            this.byPriority[node.Value.TaskPriority].Remove(task);
            this.byInsertion.Remove(task);
        }

        return tasksToRemove.Count;
    }

    public void Execute(Task task)
    {
        if (this.byInsertion.ContainsKey(task.Id))
        {
            throw new ArgumentException();
        }

        LinkedListNode<Task> node = new LinkedListNode<Task>(task);
        this.byInsertion.Add(task.Id, node);
        this.byPriority[task.TaskPriority].Add(task.Id, node);
    }

    public IEnumerable<Task> GetByConsumptionRange(int lo, int hi, bool inclusive)
    {
        List<Task> result = new List<Task>();

        if (inclusive)
        {
            result = this.byInsertion.Where(x => x.Value.Value.currentConsumption >= lo
            && x.Value.Value.currentConsumption <= hi)
            .Select(x => x.Value.Value)
            .OrderBy(x => x.currentConsumption)
            .ThenByDescending(x => x.TaskPriority)
            .ToList();
        }
        else
        {
            result = this.byInsertion.Where(x => x.Value.Value.currentConsumption > lo
            && x.Value.Value.Consumption < hi)
            .Select(x => x.Value.Value)
            .OrderBy(x => x.currentConsumption)
            .ThenByDescending(x => x.TaskPriority)
            .ToList();
        }

        return result;
    }

    public Task GetById(int id)
    {
        if (!this.byInsertion.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        return this.byInsertion[id].Value;
    }

    public Task GetByIndex(int index)
    {
        return this.byInsertion.ElementAt(index).Value.Value;
    }

    public IEnumerable<Task> GetByPriority(Priority type)
    {
        List<Task> result = new List<Task>();
        result = this.byPriority[type].Select((x) => x.Value.Value).ToList();
        return result;
    }

    public IEnumerable<Task> GetByPriorityAndMinimumConsumption
        (Priority priority, int lo)
    {
        List<Task> result = new List<Task>();
        result = this.byPriority[priority]
            .Where(x => x.Value.Value.Consumption >= lo).Select(x => x.Value.Value)
            .ToList();
        return result;
    }


    public IEnumerator<Task> GetEnumerator()
    {
        foreach (var node in byInsertion)
        {
            Task task = node.Value.Value;
            yield return task;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

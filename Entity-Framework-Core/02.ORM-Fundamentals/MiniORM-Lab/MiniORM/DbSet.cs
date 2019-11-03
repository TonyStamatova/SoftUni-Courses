using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{
    public class DbSet<T> : ICollection<T> 
        where T : class, new()
    {
        internal DbSet(IEnumerable<T> entities)
        {
            this.Entities = entities.ToList();

            this.ChangeTracker = new ChangeTracker<T>(entities);
        }

        internal ChangeTracker<T> ChangeTracker { get; set; }

        internal IList<T> Entities { get;set; }

        public int Count => this.Entities.Count;

        public bool IsReadOnly => this.Entities.IsReadOnly;

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            this.Entities.Add(item);
            this.ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while(this.Entities.Any())
            {
                T entity = this.Entities.First();
                this.Remove(entity);
            }
        }

        public bool Contains(T item) => this.Entities.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => this.Entities.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => this.Entities.GetEnumerator();

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            bool removedSuccessfully = this.Entities.Remove(item);

            if (removedSuccessfully)
            {
                this.ChangeTracker.Remove(item);
            }

            return removedSuccessfully;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities.ToArray())
            {
                this.Remove(entity);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
namespace _01.ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int index;

        public ListyIterator(params T[] elements)
        {
            this.collection = elements.ToList();
            this.index = 0;
        }

        public bool Move()
        {
            if (this.collection.Count > this.index + 1)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.collection.Count > this.index + 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.collection[this.index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

namespace _03.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public Stack()
        {
            this.elements = new List<T>();
        }

        public Stack(params T[] elements)
        {
            this.elements = new List<T>(elements);
        }

        public void Push(T[] elements)
        {
            this.elements.AddRange(elements);
        }

        public T Pop()
        {
            if (this.elements.Count == 0)
            {
                throw new Exception("No elements");
            }

            T element = this.elements.LastOrDefault();
            this.elements.RemoveAt(this.elements.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

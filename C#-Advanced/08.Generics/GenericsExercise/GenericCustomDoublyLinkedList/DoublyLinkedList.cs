namespace GenericCustomDoublyLinkedList
{
    using System;
    using System.Collections.Generic;

    public class DoublyLinkedList<T>
    {
        private class LinkNode
        {
            public LinkNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public LinkNode NextNode { get; set; }

            public LinkNode PreviousNode { get; set; }
        }

        private LinkNode head;
        private LinkNode tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            LinkNode newHead = new LinkNode(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                this.head.PreviousNode = newHead;
                newHead.NextNode = this.head;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            LinkNode newTail = new LinkNode(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newTail;
            }
            else
            {
                this.tail.NextNode = newTail;
                newTail.PreviousNode = this.tail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            ThrowExceptionIfListIsEmpty();

            T removedElement = this.head.Value;

            this.head = this.head.NextNode;

            if (this.head == null)
            {
                this.tail = this.head;
            }
            else
            {
                this.head.PreviousNode = null;
            }

            this.Count--;
            return removedElement;
        }

        public T RemoveLast()
        {
            ThrowExceptionIfListIsEmpty();

            T removedElement = this.tail.Value;

            this.tail = this.tail.PreviousNode;

            if (this.tail == null)
            {
                this.head = this.tail;
            }
            else
            {
                this.tail.NextNode = null;
            }

            this.Count--;
            return removedElement;
        }

        public void ForEach(Action<T> action)
        {
            LinkNode currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            LinkNode currentNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>();

            LinkNode currentNode = this.head;

            while (currentNode != null)
            {
                list.Add(currentNode.Value);
                currentNode = currentNode.NextNode;
            }

            return list;
        }

        public bool Contains(T element)
        {
            LinkNode currentNode = this.head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(element))
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        private void ThrowExceptionIfListIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }
    }
}

namespace Workshop
{
    using System;

    public class CustomDoublyLinkedList
    {
        private class LinkNode
        {
            public LinkNode(int value)
            {
                this.Value = value;
            }

            public int Value { get; private set; }

            public LinkNode NextNode { get; set; }

            public LinkNode PreviousNode { get; set; }
        }

        private LinkNode head;
        private LinkNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
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

        public void AddLast(int element)
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

        public int RemoveFirst()
        {
            ThrowExceptionIfListIsEmpty();

            int removedElement = this.head.Value;
            
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

        public int RemoveLast()
        {
            ThrowExceptionIfListIsEmpty();

            int removedElement = this.tail.Value;

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

                public void ForEach(Action<int> action)
        {
            LinkNode currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];

            LinkNode currentNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
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

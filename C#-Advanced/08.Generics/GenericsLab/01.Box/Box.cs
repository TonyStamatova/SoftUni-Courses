namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private Stack<T> content;

        public Box()
        {
            this.Content = new Stack<T>();
        }

        public Stack<T> Content
        {
            get => this.content;
            set => this.content = value;
        }

        public int Count => this.Content.Count;

        public void Add(T element)
        {
            this.Content.Push(element);
        }

        public T Remove()
        {
            if (this.Count > 0)
            {
                return this.Content
                .Pop();
            }
            else
            {
                return default(T);
            }
        }            
    }
}

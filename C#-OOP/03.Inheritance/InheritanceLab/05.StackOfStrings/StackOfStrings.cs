namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(params string[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                this.Push(items[i]);
            }

            return this;
        }
    }
}

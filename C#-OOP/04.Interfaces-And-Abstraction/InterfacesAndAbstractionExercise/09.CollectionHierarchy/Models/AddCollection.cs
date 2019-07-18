namespace _09.CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using _09.CollectionHierarchy.Contracts;

    public class AddCollection : IAddCollection
    {
        protected readonly List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public IReadOnlyList<string> Collection { get; }

        public virtual int Add(string element)
        {
            this.collection.Add(element);
            return this.collection.Count - 1;
        }
    }
}

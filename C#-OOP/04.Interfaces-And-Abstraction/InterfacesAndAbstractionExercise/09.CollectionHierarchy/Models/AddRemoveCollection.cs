namespace _09.CollectionHierarchy.Models
{
    using System.Linq;

    using _09.CollectionHierarchy.Contracts;

    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public AddRemoveCollection()
            : base()
        {
        }

        public override int Add(string element)
        {
            this.collection.Insert(0, element);
            return 0;
        }

        public virtual string Remove()
        {
            string result = this.collection.LastOrDefault();
            this.collection.RemoveAt(this.collection.Count - 1);
            return result;
        }
    }
}

namespace _09.CollectionHierarchy.Models
{
    using System.Linq;

    using _09.CollectionHierarchy.Contracts;

    public class MyList : AddRemoveCollection, IMyList
    {
        public MyList()
            :base()
        {
        }

        public int Used => this.collection.Count;
        
        public override string Remove()
        {
            string result = this.collection.FirstOrDefault();
            this.collection.RemoveAt(0);
            return result;
        }
    }
}

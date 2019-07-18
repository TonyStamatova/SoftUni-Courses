namespace _09.CollectionHierarchy.Contracts
{
    using System.Collections.Generic;

    public interface IAddCollection
    {
        IReadOnlyList<string> Collection { get; }

        int Add(string element);
    }
}

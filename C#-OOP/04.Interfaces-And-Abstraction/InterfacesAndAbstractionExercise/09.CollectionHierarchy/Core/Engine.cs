namespace _09.CollectionHierarchy.Core
{
    using System;
    using System.Text;

    using _09.CollectionHierarchy.Contracts;
    using _09.CollectionHierarchy.Models;

    public static class Engine
    {
        public static void Run()
        {
            var adder = new AddCollection();
            var addedAndRemover = new AddRemoveCollection();
            var myList = new MyList();

            var elementsToAdd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(PrintWhileAddingElements(elementsToAdd, adder));
            Console.WriteLine(PrintWhileAddingElements(elementsToAdd, addedAndRemover));
            Console.WriteLine(PrintWhileAddingElements(elementsToAdd, myList));

            int countToRemove = int.Parse(Console.ReadLine());

            Console.WriteLine(PrintWhileRemovingElements(countToRemove, addedAndRemover));
            Console.WriteLine(PrintWhileRemovingElements(countToRemove, myList));
        }

        private static string PrintWhileRemovingElements(int countToRemove, IAddRemoveCollection collection)
        {
            StringBuilder builder = new StringBuilder();

            for(int i = 0; i < countToRemove; i++)
            {
                builder.Append(collection.Remove());
                builder.Append(" ");
            }

            return builder.ToString().TrimEnd();
        }

        private static string PrintWhileAddingElements(string[] elementsToAdd, IAddCollection collection)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var element in elementsToAdd)
            {
                builder.Append(collection.Add(element));
                builder.Append(" ");
            }

            return builder.ToString().TrimEnd();
        }
    }
}

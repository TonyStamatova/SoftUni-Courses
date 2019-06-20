namespace GenericCustomDoublyLinkedList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            list.AddLast("a");
            list.AddLast("b");
            list.AddLast("c");
            list.AddLast("d");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}

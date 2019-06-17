namespace Workshop
{
    using System;


    public class StartUp
    {
        public static void Main()
        {
            CustomDoublyLinkedList list = new CustomDoublyLinkedList();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            //list.ForEach(Console.WriteLine);

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.ForEach(Console.WriteLine);

            Console.WriteLine();

            list.RemoveLast();

            list.ForEach(Console.WriteLine);

            int[] listAsAnArray = list.ToArray();

            Console.WriteLine(string.Join(" ", listAsAnArray));
        }
    }
}

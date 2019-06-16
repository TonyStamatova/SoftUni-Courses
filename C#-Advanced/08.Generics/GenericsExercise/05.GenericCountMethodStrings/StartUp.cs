namespace _05.GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfElements = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                list.Add(Console.ReadLine());
            }

            Box<string> box = new Box<string>(Console.ReadLine());

            Console.WriteLine(box.GetGreaterElementsCount(list, box.Value));
        }        
    }
}

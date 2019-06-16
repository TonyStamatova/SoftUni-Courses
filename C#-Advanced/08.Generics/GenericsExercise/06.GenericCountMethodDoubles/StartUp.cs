namespace _06.GenericCountMethodDoubles
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfElements = int.Parse(Console.ReadLine());

            List<double> list = new List<double>();

            for (int i = 0; i < numberOfElements; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));

            Console.WriteLine(box.GetGreaterElementsCount(list, box.Value));
        }
    }
}

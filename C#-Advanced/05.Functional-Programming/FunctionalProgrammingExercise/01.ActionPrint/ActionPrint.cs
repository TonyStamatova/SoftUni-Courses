namespace _01.ActionPrint
{
    using System;
    using System.Linq;

    public class ActionPrint
    {
        public static void Main()
        {
            Action<string> print = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);
        }
    }
}

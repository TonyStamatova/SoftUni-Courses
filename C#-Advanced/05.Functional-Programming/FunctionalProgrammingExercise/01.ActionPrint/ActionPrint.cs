namespace _01.ActionPrint
{
    using System;

    public class ActionPrint
    {
        public static void Main()
        {
            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            print(Console.ReadLine()
                .Split());         
        }
    }
}

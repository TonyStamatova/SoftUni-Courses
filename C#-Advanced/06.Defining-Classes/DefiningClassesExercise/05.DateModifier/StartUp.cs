namespace _05.DateModifier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            DateModifier modifier = new DateModifier();
            modifier.GetDifference(firstString, secondString);

            Console.WriteLine(modifier.Difference);
        }
    }
}

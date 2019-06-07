namespace _02.KnightsOfHonor
{
    using System;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            Action<string[]> print = x => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", x));

            string[] names = Console.ReadLine()
                .Split();  

            print(names);
        }
    }
}

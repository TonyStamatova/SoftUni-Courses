namespace _02.GenericBoxOfIntegers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfInts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInts; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}

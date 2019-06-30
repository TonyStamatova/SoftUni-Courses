namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            RandomList rndList = new RandomList { "abc", "def", "ghi", "jkl" };

            Console.WriteLine(rndList.RandomString());
        }
    }
}

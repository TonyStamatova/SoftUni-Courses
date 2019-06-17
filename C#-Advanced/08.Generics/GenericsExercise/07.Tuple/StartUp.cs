namespace _07.Tuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine().Split();
            var names = firstLine[0] + " " + firstLine[1];
            var address = firstLine[2];
            var firstTuple = new Tuple<string, string>(names, address);

            var secondLine = Console.ReadLine().Split();
            var name = secondLine[0];
            var amount = int.Parse(secondLine[1]);
            var secondTuple = new Tuple<string, int>(name, amount);

            var thirdLine = Console.ReadLine().Split();
            var integerNum = int.Parse(thirdLine[0]);
            var doubleNum = double.Parse(thirdLine[1]);
            var thirdTuple = new Tuple<int, double>(integerNum, doubleNum);

            Console.WriteLine(firstTuple.GetItemsInfo());
            Console.WriteLine(secondTuple.GetItemsInfo());
            Console.WriteLine(thirdTuple.GetItemsInfo());
        }
    }
}

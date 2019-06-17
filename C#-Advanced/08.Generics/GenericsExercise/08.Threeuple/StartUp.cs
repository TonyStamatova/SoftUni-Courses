namespace _08.Threeuple
{
    using System;


    public class StartUp
    {
        static void Main()
        {
            string[] firstLine = Console.ReadLine().Split();
            string names = firstLine[0] + " " + firstLine[1];
            string address = firstLine[2];
            string town = string.Empty;

            for (int i = 3; i < firstLine.Length; i++)
            {
                town += firstLine[i] + " ";
            }

            Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(names, address, town);

            string[] secondLine = Console.ReadLine().Split();
            string name = secondLine[0];
            int liters = int.Parse(secondLine[1]);
            bool isDrunk = false;

            if (secondLine[2] == "drunk")
            {
                isDrunk = true;
            }
           
            Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(name, liters, isDrunk);

            string[] thirdLine = Console.ReadLine().Split();
            string clientName = thirdLine[0];
            double balance = double.Parse(thirdLine[1]);
            string bankName = thirdLine[2];
            Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(clientName, balance, bankName);

            Console.WriteLine(firstThreeuple.GetInfo());
            Console.WriteLine(secondThreeuple.GetInfo());
            Console.WriteLine(thirdThreeuple.GetInfo());
        }
    }
}

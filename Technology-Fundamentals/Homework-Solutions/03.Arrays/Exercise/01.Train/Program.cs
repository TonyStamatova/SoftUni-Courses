using System;

namespace _01.train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] train = new int[n];
            int peopleInCurrentWagon = default(int);
            int allPeopleOnTrain = default(int);

            for (int i = 0; i < n; i++)
            {
                peopleInCurrentWagon = int.Parse(Console.ReadLine());
                train[i] = peopleInCurrentWagon;
                allPeopleOnTrain += peopleInCurrentWagon;
            }

            string result = string.Join(" ", train);
            Console.WriteLine(result + Environment.NewLine + allPeopleOnTrain);
        }
    }
}

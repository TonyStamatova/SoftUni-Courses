namespace _03.GenericSwapMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfBoxes = int.Parse(Console.ReadLine());

            List<Box<string>> listOfBoxes = new List<Box<string>>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                Box<string> newBox = new Box<string>(Console.ReadLine());
                listOfBoxes.Add(newBox);
            }

            int[] swapCommand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int firstIndex = swapCommand[0];
            int secondIndex = swapCommand[1];

            Swap<Box<string>>(listOfBoxes, firstIndex, secondIndex);

            Console.WriteLine(string.Join(Environment.NewLine, listOfBoxes));
        }

        public static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            if (IsValid(firstIndex, list.Count) && IsValid(secondIndex, list.Count))
            {
                T temp = list.ElementAt(firstIndex);
                list[firstIndex] = list.ElementAt(secondIndex);
                list[secondIndex] = temp;
            }
        }

        private static bool IsValid(int index, int listCount)
        {
            if (index >= 0 && index < listCount)
            {
                return true;
            }

            return false;
        }
    }
}

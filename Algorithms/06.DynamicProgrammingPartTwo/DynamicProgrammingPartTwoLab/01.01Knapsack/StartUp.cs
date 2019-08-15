namespace _01._01Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int capacity;

        private static int[,] biggestValue;
        private static bool[,] isItemTaken;

        private static List<Item> items;

        public static void Main()
        {
            capacity = int.Parse(Console.ReadLine());

            items = new List<Item>();

            FillItemsList();

            biggestValue = new int[items.Count + 1, capacity + 1];
            isItemTaken = new bool[items.Count + 1, capacity + 1];

            DesideWhichItemsToTake();

            List<Item> result = ReconstructSolution();

            Console.WriteLine(
                $"Total Weight: {result.Select(i => i.Weight).Sum()}");
            Console.WriteLine(
                $"Total Value: {biggestValue[biggestValue.GetLength(0) - 1, biggestValue.GetLength(1) - 1]}");
            Console.WriteLine(
                string.Join(
                    Environment.NewLine, 
                    result
                        .OrderBy(i => i.Name)
                        .Select(i => i.Name)));
        }

        private static List<Item> ReconstructSolution()
        {
            List<Item> result = new List<Item>();

            items.Reverse();

            int currentRow = items.First().Number;
            int currentCol = capacity;

            foreach (var item in items)
            {
                if (isItemTaken[currentRow, currentCol])
                {
                    result.Add(item);

                    currentCol -= item.Weight;
                }

                currentRow--;
            }

            return result;
        }

        private static void DesideWhichItemsToTake()
        {
            foreach (var item in items)
            {
                for (int currentCapacity = 0; currentCapacity <= capacity; currentCapacity++)
                {
                    int valueIfNotTaken = biggestValue[item.Number - 1, currentCapacity];

                    int valueIfTaken = 0;

                    if (currentCapacity >= item.Weight)
                    {
                        valueIfTaken = item.Value + biggestValue[item.Number - 1, currentCapacity - item.Weight];
                    }

                    int maxValue = valueIfNotTaken;

                    if (valueIfTaken > valueIfNotTaken)
                    {
                        isItemTaken[item.Number, currentCapacity] = true;
                        maxValue = valueIfTaken;
                    }

                    biggestValue[item.Number, currentCapacity] = maxValue;
                }
            }
        }

        private static void FillItemsList()
        {
            int itemCounter = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                itemCounter++;

                string[] itemInfo = input.Split();
                string name = itemInfo[0];
                int number = itemCounter;
                int weight = int.Parse(itemInfo[1]);
                int value = int.Parse(itemInfo[2]);

                Item item = new Item(name, number, weight, value);
                items.Add(item);
            }
        }
    }

    class Item
    {
        public Item(string name, int number, int weight, int value)
        {
            this.Name = name;
            this.Number = number;
            this.Weight = weight;
            this.Value = value;
        }

        public string Name { get; set; }

        public int Number { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }
    }
}

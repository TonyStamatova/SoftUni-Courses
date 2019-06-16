namespace _02.MakeASalad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> caloriesPerVeggie = new Dictionary<string, int>
            {
                {"tomato", 80 },
                {"carrot", 136 },
                {"lettuce", 109 },
                {"potato", 215 },
            };

            Queue<string> vegetables = new Queue<string>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> salads = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            List<int> saladsMade = new List<int>();

            while (salads.Count > 0)
            {
                int calories = salads.Peek();
                saladsMade.Add(salads.Pop());

                while (calories > 0)
                {
                    if (vegetables.Count > 0)
                    {
                        string currentVeggie = vegetables.Dequeue().ToLower();

                        if (!caloriesPerVeggie.ContainsKey(currentVeggie))
                        {
                            continue;
                        }

                        int veggieCalories = caloriesPerVeggie[currentVeggie];
                        calories -= veggieCalories;
                    }
                    else
                    {
                        break;
                    }
                }


                if (vegetables.Count <= 0)
                {
                    break;
                }                
            }

            Console.WriteLine(string.Join(" ", saladsMade));

            if (vegetables.Count > 0)
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }

            if (salads.Count > 0)
            {
                Console.WriteLine(string.Join(" ", salads));
            }
        }
    }
}

namespace _01.ClubParty
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static int capacity = default(int);

        public static void Main()
        {
            capacity = int.Parse(Console.ReadLine());

            Stack<string> input = new Stack<string>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Queue<Hall> halls = new Queue<Hall>();
            Queue<int> people = new Queue<int>();

            while (input.Count > 0)
            {
                string element = input.Pop();
                int number = default(int);

                if (int.TryParse(element, out number))
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    people.Enqueue(number);
                }
                else
                {
                    Hall newHall = new Hall(element);
                    halls.Enqueue(newHall);
                }

                while (halls.Count > 0 && people.Count > 0)
                {
                    Hall currentHall = halls.Peek();
                    int hallCapacity = currentHall.Capacity;
                    int reservation = people.Peek();

                    if (hallCapacity < reservation)
                    {
                        halls.Dequeue();
                        Console.WriteLine($"{currentHall.Name} -> {string.Join(", ", currentHall.Reservations)}");
                    }
                    else
                    {
                        currentHall.Reservations.Add(reservation);
                        currentHall.Capacity -= reservation;
                        people.Dequeue();
                    }
                }

                if (halls.Count == 0)
                {
                    people.Clear();
                }
            }
        }
    }

    public class Hall
    {
        public Hall(string name)
        {
            this.Name = name;

            this.Capacity = StartUp.capacity;

            this.Reservations = new List<int>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<int> Reservations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.listOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = string.Empty;
            int index = default(int);
            
            while (true)
            {
                command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] commandArr = command.Split();

                switch (commandArr[0])
                {
                    case "Add":
                        list.Add(int.Parse(commandArr[1]));
                        break;
                    case "Insert":
                        index = int.Parse(commandArr[2]);
                        if (CheckIfIndexIsValid(index, list))
                        {
                            list.Insert(index, int.Parse(commandArr[1]));
                        }
                        break;
                    case "Remove":
                        index = int.Parse(commandArr[1]);
                        if (CheckIfIndexIsValid(index, list))
                        {
                            list.RemoveAt(index);
                        }
                        break;
                    case "Shift":
                        switch (commandArr[1])
                        {
                            case "left":
                                list = Switch(list, int.Parse(commandArr[2]), 0, list.Count - 1);
                                break;
                            case "right":
                                list = Switch(list, int.Parse(commandArr[2]), list.Count - 1, 0);
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static List<int> Switch(List<int> list, int count, int indexToTakeFrom, int indexToInsertOn)
        {
            for (int i = 0; i < count; i++)
            {
                int current = list[indexToTakeFrom];
                list.RemoveAt(indexToTakeFrom);
                list.Insert(indexToInsertOn, current);
            }

            return list;
        }

        private static bool CheckIfIndexIsValid(int index, List<int> list)
        {
            if (index > list.Count || index < 0)
            {
                Console.WriteLine("Invalid index");
                return false;
            }

            return true;
        }
    }
}

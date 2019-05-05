using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] commandData = input.Split();
                string command = commandData[0];
                switch (command)
                {
                    case "exchange":
                        int splitIndex = int.Parse(commandData[1]);

                        if (splitIndex >= 0 && splitIndex < array.Length)
                        {
                            array = ExchangePlaces(array, splitIndex);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;

                    case "max":
                    case "min":
                        string evenOrOdd = commandData[1];
                        int index = -1;

                        switch (command)
                        {
                            case "max":
                                switch (evenOrOdd)
                                {
                                    case "odd":
                                        index = GetMaxEvenOrOddIndex(array, 1);
                                        break;
                                    case "even":
                                        index = GetMaxEvenOrOddIndex(array, 0);
                                        break;
                                }
                                break;
                            case "min":
                                switch (evenOrOdd)
                                {
                                    case "odd":
                                        index = GetMinEvenOrOddIndex(array, 1);
                                        break;
                                    case "even":
                                        index = GetMinEvenOrOddIndex(array, 0);
                                        break;
                                }
                                break;
                        }

                        if (index == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }

                        Console.WriteLine(index);
                        break;

                    case "first":
                    case "last":

                        int count = int.Parse(commandData[1]);

                        if (count > array.Length)
                        {
                            Console.WriteLine("Invalid count");
                            continue;
                        }

                        evenOrOdd = commandData[2];
                        int[] result = new int[0];

                        switch (command)
                        {
                            case "first":
                                switch (evenOrOdd)
                                {
                                    case "odd":
                                        result = GetFirstEvenOrOddElements(array, count, 1);
                                        break;
                                    case "even":
                                        result = GetFirstEvenOrOddElements(array, count, 0);
                                        break;
                                }
                                break;
                            case "last":
                                switch (evenOrOdd)
                                {
                                    case "odd":
                                        result = GetLastEvenOrOddElements(array, count, 1);
                                        break;
                                    case "even":
                                        result = GetLastEvenOrOddElements(array, count, 0);
                                        break;
                                }
                                break;
                        }

                        Console.WriteLine("[" + string.Join(", ", result) + "]");
                        break;
                }
            }

            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }
        
        public static int[] ExchangePlaces(int[] input, int index)
        {
            int[] result = new int[input.Length];
            int newIndex = default(int);

            for (int i = index + 1; i < input.Length; i++)
            {
                result[newIndex] = input[i];
                newIndex++;
            }

            for (int i = 0; i <= index; i++)
            {
                result[newIndex] = input[i];
                newIndex++;
            }

            return result;
        }

        public static int GetMaxEvenOrOddIndex(int[] input, int remainder)
        {
            int maxNum = int.MinValue;
            int index = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= maxNum && input[i] % 2 == remainder)
                {
                    maxNum = input[i];
                    index = i;
                }
            }
            return index;
        }

        public static int GetMinEvenOrOddIndex(int[] input, int remainder)
        {
            int minNum = int.MaxValue;
            int index = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] <= minNum && input[i] % 2 == remainder)
                {
                    minNum = input[i];
                    index = i;
                }
            }

            return index;
        }

        public static int[] GetFirstEvenOrOddElements(int[] input, int count, int remainder)
        {
            int[] result = new int[count];
            int currentCounter = 0;


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == remainder && currentCounter < count)
                {
                    result[currentCounter] = input[i];
                    currentCounter++;
                }
            }

            if (currentCounter >= count)
            {
                return result;
            }
            else
            {
                int[] temp = new int[currentCounter];
                Array.Copy(result, temp, currentCounter);
                return temp;
            }
        }

        private static int[] GetLastEvenOrOddElements(int[] input, int count, int remainder)
        {
            int[] result = new int[count];
            int currentCounter = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] % 2 == remainder && currentCounter < count)
                {
                    result[currentCounter] = input[i];
                    currentCounter++;
                }
            }

            if (currentCounter >= count)
            {
                return result.Reverse().ToArray();
            }
            else
            {
                int[] temp = new int[currentCounter];
                Array.Copy(result, temp, currentCounter);
                return temp.Reverse().ToArray();
            }
        }
    }
}
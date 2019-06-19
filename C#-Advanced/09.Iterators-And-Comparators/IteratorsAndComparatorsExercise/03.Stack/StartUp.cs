namespace _03.Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            Stack<int> stack = new Stack<int>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {

                string[] input = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];

                switch (command)
                {
                    case "Push":
                        int[] parameters = input
                            .Skip(1)
                            .Select(e => e.TrimEnd(','))
                            .Select(int.Parse)
                            .ToArray();
                        stack.Push(parameters);
                        break;

                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                }

            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var element in stack)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}

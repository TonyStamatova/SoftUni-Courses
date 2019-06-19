namespace _01.ListyIterator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            ListyIterator<string> iterator = new ListyIterator<string>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] input = line.Split();
                string command = input[0];

                switch (command)
                {
                    case "Create":
                        string[] parameters = input
                            .Skip(1)
                            .ToArray();
                        iterator = new ListyIterator<string>(parameters);
                        break;

                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;

                    case "Print":
                        iterator.Print();
                        break;

                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;

                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", iterator));
                        break;
                }
            }
        }
    }
}

namespace _09.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            string text = string.Empty;
            Stack<string> history = new Stack<string>();
            history.Push(text);

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] commandData = Console.ReadLine().Split();
                string command = commandData[0];

                switch (command)
                {
                    case "1":
                        string textToAppend = commandData[1];
                        text += textToAppend;
                        history.Push(text);
                        break;
                    case "2":
                        int countToRemove = int.Parse(commandData[1]);
                        text = text.Remove(text.Length - countToRemove);
                        history.Push(text);
                        break;
                    case "3":
                        int index = int.Parse(commandData[1]) - 1;
                        Console.WriteLine(text[index]);
                        continue;
                    case "4":
                        history.Pop();
                        text = history.Peek();
                        break;
                }
            }
        }
    }
}

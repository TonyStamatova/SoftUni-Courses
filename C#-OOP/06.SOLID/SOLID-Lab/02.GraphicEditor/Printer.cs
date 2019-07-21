namespace P02.Graphic_Editor
{
    using System;

    using P02.Graphic_Editor.Contracts;

    public class Printer : IPrinter
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}

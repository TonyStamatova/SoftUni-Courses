namespace P03.Detail_Printer
{
    using System;

    using P03.Detail_Printer.Contracts;

    public class ConsolePrinter : IPrinter
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}

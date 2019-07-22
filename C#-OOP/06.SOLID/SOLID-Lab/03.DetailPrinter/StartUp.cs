namespace P03.DetailPrinter
{
    using System.Collections.Generic;

    using P03.Detail_Printer.Contracts;
    using P03.DetailPrinter.Models;

    public class StartUp
    {
        public static void Main()
        {
            DetailsPrinter detPrinter = new DetailsPrinter(
                new List<IEmployee>()
                {
                    new Employee("gosho"),
                    new Manager("pesho", new List<string>() { "ala bala", "doklad" })
                });

            detPrinter.PrintDetails();
        }
    }
}

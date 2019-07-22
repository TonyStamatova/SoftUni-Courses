namespace P03.DetailPrinter
{
    using System.Collections.Generic;

    using P03.Detail_Printer;
    using P03.Detail_Printer.Contracts;

    public class DetailsPrinter
    {
        private IList<IEmployee> employees;
        private IPrinter consolePrinter = new ConsolePrinter();

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                this.consolePrinter.Print(employee.PrintInfo());
            }
        }
    }
}

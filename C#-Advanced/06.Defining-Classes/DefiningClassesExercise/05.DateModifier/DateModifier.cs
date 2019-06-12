namespace _05.DateModifier
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class DateModifier
    {
        private int difference;

        public int Difference
        {
            get => this.difference;
            set => this.difference = value;
        }

        public void GetDifference(string firstString, string secondString)
        {
            DateTime firstDate = DateTime.ParseExact(firstString, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime seconDate = DateTime.ParseExact(secondString, "yyyy MM dd", CultureInfo.InvariantCulture);

            TimeSpan span = firstDate.Subtract(seconDate);
            this.difference = Math.Abs((int)Math.Truncate(span.TotalDays));           
        }
    }
}

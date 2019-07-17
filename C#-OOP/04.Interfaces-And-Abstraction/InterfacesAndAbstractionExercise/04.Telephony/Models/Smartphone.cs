namespace _04.Telephony.Models
{
    using System;
    using System.Text;

    using _04.Telephony.Contracts;
    using _04.Telephony.Exceptions;

    public class Smartphone : ICaller, IBrowser
    {
        private string[] phoneNumbers;
        private string[] sites;

        public Smartphone(string[] phoneNumbers, string[] sites)
        {
            this.phoneNumbers = phoneNumbers;
            this.sites = sites;
        }

        public string Browse()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var site in this.sites)
            {
                try
                {
                    ValidateURL(site);
                    builder.AppendLine($"Browsing: {site}!");
                }
                catch (ArgumentException ae)
                {
                    builder.AppendLine(ae.Message);
                }                
            }

            return builder.ToString().TrimEnd();
        }
        
        public string Call()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var number in this.phoneNumbers)
            {
                try
                {
                    ValidateNumber(number);
                    builder.AppendLine($"Calling... {number}");
                }
                catch (ArgumentException ae)
                {
                    builder.AppendLine(ae.Message);
                }                
            }

            return builder.ToString();
        }

        public override string ToString()
        {
            return $"{this.Call()}" + $"{this.Browse()}";
        }

        private static void ValidateNumber(string number)
        {
            foreach (char character in number)
            {
                if (!char.IsDigit(character))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberExceptionMessage);
                }
            }
        }

        private static void ValidateURL(string site)
        {
            foreach (char character in site)
            {
                if (char.IsDigit(character))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidURLExceptionMessage);
                }
            }
        }
    }
}

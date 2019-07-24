namespace _01.Logger.Factories
{
    using System;
    using System.Globalization;

    using _01.Logger.Contracts;
    using _01.Logger.Exceptions;
    using _01.Logger.FormatsUsed;
    using _01.Logger.Models;
    using _01.Logger.Models.Enumerations;

    public class LogFactory
    {
        public ILog CreateLog(string dateAsString, string levelAsString, string message)
        {
            DateTime dateTime = default(DateTime);

            try
            {
                dateTime = DateTime.ParseExact(
                    dateAsString, 
                    DateTimeFormats.customFormat, 
                    CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidDateTimeMessage);
            }

            Enum.TryParse(levelAsString, out ReportLevel level);

            return new Log(dateTime, message, level);
        }
    }
}

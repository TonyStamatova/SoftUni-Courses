namespace _01.Logger.Models
{
    using System;

    using _01.Logger.Contracts;
    using _01.Logger.Models.Enumerations;

    public class Log : ILog
    {
        public Log(DateTime dateTime, string message, ReportLevel reportlevel)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.ReportLevel = reportlevel;
        }

        public DateTime DateTime { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public string Message { get; private set; }
    }
}

namespace _01.Logger.Models.Appenders
{
    using System;

    using _01.Logger.Contracts;
    using _01.Logger.Models.Enumerations;

    public class ConsoleAppender : Appender
    {        
        public ConsoleAppender(ILayout layout, ReportLevel level)
            : base (layout, level)
        {            
        }

        protected override void AppendLogText(string logText)
        {
            Console.WriteLine(logText);
        }
    }
}

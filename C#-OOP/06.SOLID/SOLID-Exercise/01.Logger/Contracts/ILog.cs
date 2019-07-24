namespace _01.Logger.Contracts
{
    using System;

    using _01.Logger.Models.Enumerations;
    
    public interface ILog
    {
        DateTime DateTime { get; }

        ReportLevel ReportLevel { get; }

        string Message { get; }
    }
}

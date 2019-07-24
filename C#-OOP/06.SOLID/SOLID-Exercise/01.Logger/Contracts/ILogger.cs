namespace _01.Logger.Contracts
{
    using System.Collections.Generic;

    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void LogToAllAppenders(ILog log);
    }
}

namespace _01.Logger.Models
{
    using System.Collections.Generic;
    using System.Text;

    using _01.Logger.Contracts;

    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders
            => (IReadOnlyCollection<IAppender>)this.appenders;

        public void LogToAllAppenders(ILog log)
        {
            foreach (IAppender appender in this.Appenders)
            {
                if (appender.Level <= log.ReportLevel)
                {
                    appender.Append(log);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Logger info");

            foreach (IAppender appender in this.Appenders)
            {
                builder.AppendLine(appender.ToString());
            }

            return builder
                .ToString()
                .TrimEnd();
        }
    }
}

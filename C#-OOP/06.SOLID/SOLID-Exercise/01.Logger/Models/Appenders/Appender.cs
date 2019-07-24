namespace _01.Logger.Models.Appenders
{
    using System.Globalization;
    using System.Text;

    using _01.Logger.Contracts;
    using _01.Logger.FormatsUsed;
    using _01.Logger.Models.Enumerations;

    public abstract class Appender : IAppender
    {
        private int messagesAppended;

        public Appender(ILayout layout, ReportLevel level)
        {
            this.Layout = layout;
            this.Level = level;

            this.messagesAppended = 0;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel Level { get; private set; }

        public void Append(ILog log)
        {
            string logText = string.Format(
                this.Layout.Format,
                log.DateTime.ToString(DateTimeFormats.customFormat, CultureInfo.InvariantCulture),
                log.ReportLevel,
                log.Message);

            this.AppendLogText(logText);

            this.messagesAppended++;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"Appender type: {this.GetType().Name}, ")
                .Append($"Layout type: {this.Layout.GetType().Name}, ")
                .Append($"Report level: {this.Level}, ")
                .Append($"Messages appended: {this.messagesAppended}");

            return builder.ToString();
        }

        protected abstract void AppendLogText(string logText);
    }
}

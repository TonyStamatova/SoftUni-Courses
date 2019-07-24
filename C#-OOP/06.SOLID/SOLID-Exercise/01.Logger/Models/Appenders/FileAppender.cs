namespace _01.Logger.Models.Appenders
{
    using _01.Logger.Contracts;
    using _01.Logger.Models.Enumerations;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ReportLevel level, IFile file)
            : base(layout, level)
        {
            this.LogFile = file;
        }

        public IFile LogFile { get; private set; }
        
        public override string ToString()
        {
            return base.ToString() + $", File size: {this.LogFile.Size}";
        }

        protected override void AppendLogText(string logText)
        {
            this.LogFile.Write(logText);
        }
    }
}

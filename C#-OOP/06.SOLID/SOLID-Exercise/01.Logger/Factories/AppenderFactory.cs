namespace _01.Logger.Factories
{
    using System;

    using _01.Logger.Contracts;
    using _01.Logger.Exceptions;
    using _01.Logger.Models;
    using _01.Logger.Models.Appenders;
    using _01.Logger.Models.Enumerations;

    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelAsString)
        {
            Enum.TryParse(levelAsString, out ReportLevel level);

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, level);
                case "FileAppender":
                    IFile file = new LogFile();
                    return new FileAppender(layout, level, file);
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidAppenderTypeMessage);
            }
        }
    }
}

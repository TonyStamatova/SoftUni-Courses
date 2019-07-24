namespace _01.Logger
{
    using System;
    using System.Collections.Generic;

    using _01.Logger.Contracts;
    using _01.Logger.Core;
    using _01.Logger.Factories;
    using _01.Logger.Models;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();
            
            ReadAppendersData(numberOfAppenders, appenders);

            ILogger logger = new Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppendersData(int numberOfAppenders, ICollection<IAppender> appenders)
        {
            AppenderFactory appenderFactory = new AppenderFactory();

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appenderInfo = Console.ReadLine().Split();

                string appenderType = appenderInfo[0];
                string layoutType = appenderInfo[1];

                string reportLevel = string.Empty;

                if (appenderInfo.Length == 3)
                {
                    reportLevel = appenderInfo[2];
                }

                try
                {
                    IAppender newAppender = appenderFactory.GetAppender(
                        appenderType, 
                        layoutType, 
                        reportLevel);
                    appenders.Add(newAppender);
                }
                catch (ArgumentException)
                {
                }                
            }
        }
    }
}

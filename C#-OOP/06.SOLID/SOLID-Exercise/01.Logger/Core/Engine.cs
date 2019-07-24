namespace _01.Logger.Core
{
    using System;

    using _01.Logger.Contracts;
    using _01.Logger.Factories;

    public class Engine
    {
        private ILogger logger;

        public Engine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            string input = string.Empty;

            LogFactory logFactory = new LogFactory();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] logInfo = input.Split("|");

                string level = logInfo[0];
                string dateTime = logInfo[1];
                string message = logInfo[2];

                try
                {
                    ILog newLog = logFactory.CreateLog(dateTime, level, message);
                    this.logger.LogToAllAppenders(newLog);
                }
                catch (ArgumentException)
                {
                }
            }

            Console.WriteLine(this.logger);
        }
    }
}

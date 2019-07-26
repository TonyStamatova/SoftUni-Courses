namespace CommandPattern.Core
{
    using System;

    using CommandPattern.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();

                try
                {
                    string result = this.commandInterpreter.Read(input);
                    Console.WriteLine(result);
                }
                catch (ArgumentException)
                {
                }
            }
        }
    }
}

namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandInfo = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandTypeName = commandInfo[0] + "Command";
            string[] commandArgs = commandInfo
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] allTypes = assembly.GetTypes();

            Type commandType = allTypes.FirstOrDefault(t => t.Name == commandTypeName);

            if (commandType == null)
            {
                throw new ArgumentException();
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType);

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}

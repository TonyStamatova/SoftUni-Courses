using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IManagerController manager = new ManagerController();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Exit")
            {
                string[] commandInfo = input.Split();
                string command = commandInfo[0];
                string firstParam = string.Empty;
                string secondParam = string.Empty;

                if (commandInfo.Length == 3)
                {
                    firstParam = commandInfo[1];
                    secondParam = commandInfo[2];
                }

                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            Console.WriteLine(manager.AddPlayer(firstParam, secondParam));
                            break;
                        case "AddCard":
                            Console.WriteLine(manager.AddCard(firstParam, secondParam));
                            break;
                        case "AddPlayerCard":
                            Console.WriteLine(manager.AddPlayerCard(firstParam, secondParam));
                            break;
                        case "Fight":
                            Console.WriteLine(manager.Fight(firstParam, secondParam));
                            break;
                        case "Report":
                            Console.WriteLine(manager.Report());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;
    using MXGP.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IChampionshipController controller = new ChampionshipController();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandInfo[0];
                string firstParam = commandInfo[1];
                string secondParam = string.Empty;
                string thirdParam = string.Empty;

                if (commandInfo.Length > 2)
                {
                    secondParam = commandInfo[2];
                }

                if (commandInfo.Length > 3)
                {
                    thirdParam = commandInfo[3];
                }

                try
                {
                    switch (command)
                    {
                        case "CreateRider":
                            Console.WriteLine(controller.CreateRider(firstParam));
                            break;
                        case "CreateMotorcycle":
                            Console.WriteLine(controller.CreateMotorcycle(
                                firstParam,
                                secondParam,
                                int.Parse(thirdParam)));
                            break;
                        case "AddMotorcycleToRider":
                            Console.WriteLine(controller.AddMotorcycleToRider(firstParam, secondParam));
                            break;
                        case "AddRiderToRace":
                            Console.WriteLine(controller.AddRiderToRace(firstParam, secondParam));
                            break;
                        case "CreateRace":
                            Console.WriteLine(controller.CreateRace(firstParam, int.Parse(secondParam)));
                            break;
                        case "StartRace":
                            Console.WriteLine(controller.StartRace(firstParam));
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

using MortalEngines.Core;
using System;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            //MachinesManager manager = new MachinesManager();

            //string commandInput = string.Empty;

            //while ((commandInput = Console.ReadLine()) != "Quit")
            //{
            //    string[] commandInfo = commandInput.Split();
            //    string command = commandInfo[0];
            //    string firstParam = commandInfo[1];
            //    string secondParam = string.Empty;
            //    string thirdParam = string.Empty;

            //    if (commandInfo.Length >= 3)
            //    {
            //        secondParam = commandInfo[2];
            //    }

            //    if (commandInfo.Length == 4)
            //    {
            //        thirdParam = commandInfo[3];
            //    }

            //    try
            //    {
            //        switch (command)
            //        {
            //            case "HirePilot":
            //                Console.WriteLine(manager.HirePilot(firstParam));
            //                break;
            //            case "PilotReport":
            //                Console.WriteLine(manager.PilotReport(firstParam));
            //                break;
            //            case "ManufactureTank":
            //                Console.WriteLine(manager.ManufactureTank(
            //                    firstParam,
            //                    double.Parse(secondParam),
            //                    double.Parse(thirdParam)));
            //                break;
            //            case "ManufactureFighter":
            //                Console.WriteLine(manager.ManufactureFighter(
            //                    firstParam,
            //                    double.Parse(secondParam),
            //                    double.Parse(thirdParam)));
            //                break;
            //            case "MachineReport":
            //                Console.WriteLine(manager.MachineReport(firstParam));
            //                break;
            //            case "AggressiveMode":
            //                Console.WriteLine(manager.ToggleFighterAggressiveMode(firstParam));
            //                break;
            //            case "DefenseMode":
            //                Console.WriteLine(manager.ToggleTankDefenseMode(firstParam));
            //                break;
            //            case "Engage":
            //                Console.WriteLine(manager.EngageMachine(firstParam, secondParam));
            //                break;
            //            case "Attack":
            //                Console.WriteLine(manager.AttackMachines(firstParam, secondParam));
            //                break;
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Error:" + e.Message);
            //    }
            //}
        }
    }
}
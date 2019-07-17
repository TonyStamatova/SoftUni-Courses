namespace _05.BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using _05.BorderControl.Contracts;
    using _05.BorderControl.Models;

    public static class Engine
    {
        private static Dictionary<string, IIdentifiable> borderPassers = new Dictionary<string, IIdentifiable>();
        public static void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] passerInfo = input.Split();

                if (passerInfo.Length == 3)
                {
                    Citizen citizen = CreateCitizen(passerInfo);
                    Register(citizen);
                }
                else
                {
                    Robot robot = CreateRobot(passerInfo);
                    Register(robot);
                }
            }

            string fakeIdTell = Console.ReadLine();

            Console.WriteLine(
                string.Join(                
                Environment.NewLine, 
                borderPassers.Keys.Where(p => p.EndsWith(fakeIdTell))));
        }

        private static void Register(IIdentifiable passer)
        {
            borderPassers.Add(passer.Id, passer);
        }

        private static Robot CreateRobot(string[] passerInfo)
        {
            string model = passerInfo[0];
            string id = passerInfo[1];
            return new Robot(model, id);
        }

        private static Citizen CreateCitizen(string[] passerInfo)
        {
            string name = passerInfo[0];
            int age = int.Parse(passerInfo[1]);
            string id = passerInfo[2];
            return new Citizen(name, age, id);
        }
    }
}

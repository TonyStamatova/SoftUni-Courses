using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Band> bandsByName = new Dictionary<string, Band>();

            while (input != "start of concert")
            {
                string[] data = input.Split("; ");
                string band = data[1];

                if (!bandsByName.ContainsKey(band))
                {
                    bandsByName.Add(band, new Band(band));
                }
                
                string command = data[0];

                switch (command)
                {
                    case "Add":
                        string[] members = data[2].Split(", ");
                        foreach (var member in members)
                        {
                            if (!bandsByName[band].Members.Any(x => x == member))
                            {
                                bandsByName[band].Members.Add(member);
                            }                            
                        }
                        break;

                    case "Play":
                        int time = int.Parse(data[2]);
                        bandsByName[band].Time += time;
                        break;
                }

                input = Console.ReadLine();
            }

            int totTime = default(int);

            foreach (var band in bandsByName.Values)
            {
                totTime += band.Time;
            }

            Console.WriteLine($"Total time: {totTime}");

            foreach (var band in bandsByName.Values.OrderByDescending(x => x.Time)
                .ThenBy(x => x.Name))
            {
                Console.WriteLine($"{band.Name} -> {band.Time}");
            }

            string bandName = Console.ReadLine();

            Console.Write(bandName + Environment.NewLine + "=> ");
            Console.WriteLine(string.Join(Environment.NewLine + "=> ", bandsByName[bandName].Members));
        }
    }

    class Band
    {
        public Band(string name)
        {
            this.Name = name;
            this.Time = 0;
            this.Members = new List<string>();
        }

        public string Name { get; set; }

        public int Time { get; set; }

        public List<string> Members { get; set; }
    }
}

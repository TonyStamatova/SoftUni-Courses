namespace _01.ParkingZones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static HashSet<Zone> zones;
        private static Dictionary<string, List<int>> spotsByZoneName;
        private static Spot[] spots;

        public static void Main()
        {
            int zoneCount = int.Parse(Console.ReadLine());
            zones = new HashSet<Zone>();
            spotsByZoneName = new Dictionary<string, List<int>>();
            ReadZonesInput(zoneCount);
            ReadSpotInfo();

            int[] targetCoordinates = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int targetX = targetCoordinates[0];
            int targetY = targetCoordinates[1];
            int secondsPerSquare = int.Parse(Console.ReadLine());

            int distance = -1;
            decimal bestPrice = decimal.MaxValue;
            int shortestDistance = int.MaxValue;
            int winnerSpot = -1;
            string winnerZone = string.Empty;

            foreach (var zone in spotsByZoneName)
            {
                int spot = FindBestSpot(targetX, targetY, zone.Key, ref distance);
                Zone currentZone = zones.First(z => z.Name == zone.Key);
                decimal currentPrice = currentZone.PricePerMinute * Math.Ceiling((distance * 2 * secondsPerSquare) / 60m);

                if (currentPrice < bestPrice || (currentPrice == bestPrice && distance < shortestDistance))
                {
                    winnerZone = zone.Key;
                    winnerSpot = spot;
                    shortestDistance = distance;
                    bestPrice = currentPrice;
                }
            }
            
            PrintResult(winnerZone, winnerSpot, bestPrice);
        }

        private static void PrintResult(string zone, int spot, decimal price)
        {
            Console.WriteLine(
                $"Zone Type: {zone}; X: {spots[spot].X}; Y: {spots[spot].Y}; Price: {price:f2}");
        }

        private static int FindBestSpot(int targetX, int targetY, string zoneName, ref int distance)
        {
            int minDistance = int.MaxValue;
            int bestSpot = -1;

            foreach (var spot in spotsByZoneName[zoneName])
            {
                Spot current = spots[spot];
                int xDifference = Math.Abs(targetX - current.X);
                int yDifference = Math.Abs(targetY - current.Y);
                int currentDistance = xDifference + yDifference - 1;

                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    bestSpot = spot;
                }
            }

            distance = minDistance;
            return bestSpot;
        }

        private static void ReadSpotInfo()
        {
            string[] spotsInfo = Console.ReadLine().Split(';');
            spots = new Spot[spotsInfo.Length];

            for (int i = 0; i < spotsInfo.Length; i++)
            {
                int[] coordinates = spotsInfo[i]
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Spot newSpot = new Spot(coordinates[0], coordinates[1]);
                spots[i] = newSpot;

                foreach (var zone in zones)
                {
                    Zone current = zones.First(
                        z => newSpot.X >= z.Ax && newSpot.X <= z.Bx && newSpot.Y >= z.Ay && newSpot.Y <= z.By);
                    spotsByZoneName[current.Name].Add(i);
                }
            }
        }

        private static void ReadZonesInput(int zoneCount)
        {
            for (int i = 0; i < zoneCount; i++)
            {
                string[] zoneInfo = Console.ReadLine()
                    .Split(new char[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
                string name = zoneInfo[0];
                int x = int.Parse(zoneInfo[1]);
                int y = int.Parse(zoneInfo[2]);
                int width = int.Parse(zoneInfo[3]);
                int height = int.Parse(zoneInfo[4]);
                decimal pricePerMin = decimal.Parse(zoneInfo[5]);

                int bx = x + width;
                int by = y + height;

                Zone newZone = new Zone(name, x, y, bx, by, pricePerMin);
                zones.Add(newZone);
                spotsByZoneName.Add(name, new List<int>());
            }
        }
    }

    public class Spot
    {
        public Spot(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }
    }

    public class Zone
    {
        public Zone(string name, int ax, int ay, int bx, int by, decimal pricePerMin)
        {
            this.Name = name;
            this.Ax = ax;
            this.Ay = ay;
            this.Bx = bx;
            this.By = by;
            this.PricePerMinute = pricePerMin;
        }

        public string Name { get; private set; }

        public int Ax { get; private set; }

        public int Ay { get; private set; }

        public int Bx { get; private set; }

        public int By { get; private set; }

        public decimal PricePerMinute { get; private set; }
    }
}

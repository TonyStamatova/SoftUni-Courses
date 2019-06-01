namespace _06.ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        public static void Main()
        {
            var parkingLot = new HashSet<string>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var carInfo = input.Split(", ");
                var direction = carInfo[0];
                var plate = carInfo[1];

                switch (direction)
                {
                    case "IN":
                        parkingLot.Add(plate);
                        break;
                    case "OUT":
                        parkingLot.Remove(plate);
                        break;
                }
            }

            foreach (var car in parkingLot)
            {
                Console.WriteLine(car);
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

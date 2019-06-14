namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;

    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new Dictionary<string, Car>();
            this.Capacity = capacity;
        }

        public Dictionary<string, Car> Cars
        {
            get => this.cars;
            set => this.cars = value;
        }

        private int Capacity
        {
            get => this.capacity;
            set => this.capacity = value;
        }

        public int Count => this.Cars.Count;

        public string AddCar(Car car)
        {
            if (this.Cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.Cars.Count == this.Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                this.Cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.Cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                this.Cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = this.Cars[registrationNumber];
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                if (this.Cars.ContainsKey(number))
                {
                    this.Cars.Remove(number);
                }
            }
        }
    }
}

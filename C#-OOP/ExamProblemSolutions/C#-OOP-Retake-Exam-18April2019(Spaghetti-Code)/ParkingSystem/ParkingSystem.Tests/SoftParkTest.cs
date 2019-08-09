namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark park;

        private string make = "default make";
        private string registration = "default reg";

        private Car car;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CarCtorCreatesCar()
        {
            this.car = new Car(this.make, this.registration);

            Assert.AreEqual(this.make, this.car.Make);
            Assert.AreEqual(this.registration, this.car.RegistrationNumber);
        }

        [Test]
        public void SoftParkCtorCreatesPark()
        {
            this.park = new SoftPark();

            Assert.IsNotNull(this.park.Parking);
        }

        [Test]
        public void SoftParkCount()
        {
            this.park = new SoftPark();
        
            Assert.AreEqual(12, this.park.Parking.Count);
        }

        [Test]
        public void Park()
        {
            string spot = "A2";
            this.park = new SoftPark();
            this.car = new Car(this.make, this.registration);

            this.park.ParkCar(spot, car);

            Assert.AreEqual(this.park.Parking[spot], car);
        }

        [Test]
        public void ParkThrowsWithInvalidSpot()
        {
            string spot = "sdvsvd";
            this.park = new SoftPark();
            this.car = new Car(this.make, this.registration);

            Assert.Throws< ArgumentException>(
                () => this.park.ParkCar(spot, car));
        }

        [Test]
        public void ParkThrowsWithFullSpot()
        {
            string spot = "A2";
            this.park = new SoftPark();
            this.car = new Car(this.make, this.registration);
            this.park.ParkCar(spot, car);

            Car newCar = new Car("make", "1234");

            Assert.Throws<ArgumentException>(
                () => this.park.ParkCar(spot, newCar));
        }

        [Test]
        public void ParkThrowsWithExistingCar()
        {
            string spot = "A2";
            this.park = new SoftPark();
            this.car = new Car(this.make, this.registration);
            this.park.ParkCar(spot, car);
            
            Assert.Throws<InvalidOperationException>(
                () => this.park.ParkCar("B3", car));
        }

        [Test]
        public void Remove()
        {
            string spot = "A2";
            this.park = new SoftPark();
            this.car = new Car(this.make, this.registration);

            this.park.ParkCar(spot, car);
            this.park.RemoveCar(spot, car);

            Assert.IsNull(this.park.Parking[spot]);
        }
    }
}
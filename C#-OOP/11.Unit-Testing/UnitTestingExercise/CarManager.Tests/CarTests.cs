using System;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using CarManager;

namespace Tests
{
    public class CarTests
    {
        private string make = "test make";
        private string model = "test model";
        private double fuelConsumption = 1.0;
        private double fuelCapacity = 2.0;

        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car(
                this.make,
                this.model,
                this.fuelConsumption,
                this.fuelCapacity);
        }

        [Test]
        public void ConstructorCheck()
        {
            string expectedMake = "test make";
            string expectedModel = "test model";
            double expectedFuelConsumption = 1.0;
            double expectedFuelCapacity = 2.0;
            double expectedFuelAmount = 0.0;

            Assert.AreEqual(expectedMake, this.car.Make);
            Assert.AreEqual(expectedModel, this.car.Model);
            Assert.AreEqual(expectedFuelConsumption, this.car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, this.car.FuelCapacity);
            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void CarHasNoPublicFields()
        {
            int expectedCount = 0;

            Type type = this.car.GetType();
            FieldInfo[] publicFields = type
                .GetFields()
                .Where(f => f.IsPublic)
                .ToArray();

            Assert.AreEqual(expectedCount, publicFields.Length);
        }

        [Test]
        public void ConstructorShouldCreateCarCorrectly()
        {
            Assert.IsNotNull(this.car);
        }

        [Test]
        public void CreatingWithEmptyMakeShouldThrow()
        {
            string emptyMakeString = "";

            Assert.Throws<ArgumentException>(
                () => this.car = new Car(
                    emptyMakeString,
                    this.model,
                    this.fuelConsumption,
                    this.fuelCapacity));
        }

        [Test]
        public void CreatingWithNullMakeShouldThrow()
        {
            string nullMakeString = null;

            Assert.Throws<ArgumentException>(
                () => this.car = new Car(
                    nullMakeString,
                    this.model,
                    this.fuelConsumption,
                    this.fuelCapacity));
        }        

        [Test]
        public void CreatingWithEmptyModelShouldThrow()
        {
            string emptyModelString = "";

            Assert.Throws<ArgumentException>(
                () => this.car = new Car(
                    this.make,
                    emptyModelString,
                    this.fuelConsumption,
                    this.fuelCapacity));
        }

        [Test]
        public void CreatingWithNullModelShouldThrow()
        {
            string nullModelString = null;

            Assert.Throws<ArgumentException>(
                () => this.car = new Car(
                    this.make,
                    nullModelString,
                    this.fuelConsumption,
                    this.fuelCapacity));
        }

        [Test]
        public void CreatingWithZeroFuelConsumtionShouldThrow()
        {
            double zeroFuelConsumtion = 0.0;

            Assert.Throws<ArgumentException>(
                () => this.car = new Car(
                    this.make,
                    this.model,
                    zeroFuelConsumtion,
                    this.fuelCapacity));
        }

        [Test]
        public void CreatingWithNegativeFuelConsumtionShouldThrow()
        {
            double negativeFuelConsumtion = -10;

            Assert.Throws<ArgumentException>(
                () => this.car = new Car(
                    this.make,
                    this.model,
                    negativeFuelConsumtion,
                    this.fuelCapacity));
        }

        [Test]
        public void SettingNegativeFuelAmmountShouldThrow()
        {
            double newgativeFuelAmount = -10;

            PropertyInfo fuelAmount = this.car.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(p => p.Name == "FuelAmount");

            Assert.Throws<TargetInvocationException>(
                () => fuelAmount.SetValue(car, newgativeFuelAmount));
        }

        [Test]
        public void SettingNegativeFuelCapacityShouldThrow()
        {
            double negativeFuelCapacity = -10;

            Assert.Throws<ArgumentException>(
                () => this.car = new Car(
                    this.make,
                    this.model,
                    this.fuelConsumption,
                    negativeFuelCapacity));
        }

        [Test]
        public void SettingZeroFuelCapacityShouldThrow()
        {
            double zeroFuelCapacity = 0;

            Assert.Throws<ArgumentException>(
                () => this.car = new Car(
                    this.make,
                    this.model,
                    this.fuelConsumption,
                    zeroFuelCapacity));
        }

        [Test]
        public void RefuelNegativeAmmountShouldThrow()
        {
            double negativeFuelAmount = -1.2;
        
            Assert.Throws<ArgumentException>(
                () => this.car.Refuel(negativeFuelAmount));
        }

        [Test]
        public void RefuelZeroAmmountShouldThrow()
        {
            double zeroFuelAmount = 0;

            Assert.Throws<ArgumentException>(
                () => this.car.Refuel(zeroFuelAmount));
        }

        [Test]
        public void RefuelSetsFuelAmountCorrectly()
        {
            double fuelAmount = 1.0;

            this.car.Refuel(fuelAmount);

            Assert.AreEqual(fuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void RefuelShouldNotSetFuelAmountAboveCapacity()
        {
            double fuelAmount = 3.0;

            this.car.Refuel(fuelAmount);

            Assert.AreEqual(this.fuelCapacity, this.car.FuelAmount);
        }

        [Test]
        public void DriveWithMoreFuelThanAvailableShouldThrow()
        {
            double distance = 1.0;

            Assert.Throws<InvalidOperationException>(
                () => this.car.Drive(distance));
        }

        [Test]
        public void DriveShouldDecreaseFuelAmount()
        {
            this.car.Refuel(2.0);
            double distance = 100.0;
            this.car.Drive(distance);

            double expectedAmount = 1.0;

            Assert.AreEqual(expectedAmount, this.car.FuelAmount);
        }

        [Test]
        public void DriveNegativeDistanceShouldIncreaseFuelAmount()
        {
            this.car.Refuel(2.0);
            double distance = -100.0;
            this.car.Drive(distance);

            double expectedAmount = 3.0;
            
            Assert.AreEqual(expectedAmount, this.car.FuelAmount);
        }
    }
}

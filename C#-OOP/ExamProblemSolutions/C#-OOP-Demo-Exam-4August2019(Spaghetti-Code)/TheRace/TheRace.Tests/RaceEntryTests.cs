using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry entry;
        private UnitRider rider;
        private UnitMotorcycle motor;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorCreatesDictionary()
        {
            entry = new RaceEntry();

            Assert.AreEqual(0, entry.Counter);
        }

        [Test]
        public void AddRider()
        {
            entry = new RaceEntry();
            motor = new UnitMotorcycle("model", 5, 5);
            rider = new UnitRider("name", motor);


            string expected = $"Rider {rider.Name} added in race.";

            Assert.AreEqual(expected, entry.AddRider(rider));
        }

        [Test]
        public void AddRiderNull()
        {
            entry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(
                () => entry.AddRider(null));
        }

        [Test]
        public void AddRiderExisting()
        {
            entry = new RaceEntry();
            motor = new UnitMotorcycle("model", 5, 5);
            rider = new UnitRider("name", motor);
            entry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(
                () => entry.AddRider(rider));
        }

        [Test]
        public void Avg()
        {
            entry = new RaceEntry();
            motor = new UnitMotorcycle("model", 5, 5);
            rider = new UnitRider("name", motor);
            entry.AddRider(rider);

            UnitMotorcycle newMotor = new UnitMotorcycle("model2", 15, 5);
            UnitRider newRider = new UnitRider("name2", newMotor);
            entry.AddRider(newRider);


            Assert.AreEqual(10, entry.CalculateAverageHorsePower());
        }

        [Test]
        public void AvgThrows()
        {
            entry = new RaceEntry();
            motor = new UnitMotorcycle("model", 5, 5);
            rider = new UnitRider("name", motor);
            entry.AddRider(rider);
                       
            Assert.Throws<InvalidOperationException>(() => entry.CalculateAverageHorsePower());
        }
    }
}
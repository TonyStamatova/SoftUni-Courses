namespace Service.Tests
{
    using System;

    using NUnit.Framework;

    using Service.Models.Contracts;
    using Service.Models.Devices;
    using Service.Models.Parts;

    public class DeviceTests
    {
        private string defaultMake = "make";

        private IRepairable device;

        private IPart part;

        [SetUp]
        public void Setup()
        {
        }

        [Test]              
        public void CtorCreatesListOfParts()
        {
            this.device = new Laptop(this.defaultMake);

            Assert.IsNotNull(this.device.Parts);
        }

        [Test]
        public void MakeIsSetCorrectly()
        {
            this.device = new Laptop(this.defaultMake);
        
            Assert.AreEqual(this.defaultMake, this.device.Make);
        }

        [Test]              
        public void MakeIsEmptyStringShouldThrow()
        {
            Assert.Throws<ArgumentException>(
                () => this.device = new Laptop(string.Empty));
        }

        [Test]
        public void MakeIsNullShouldThrow()
        {
            Assert.Throws<ArgumentException>(
                () => this.device = new Laptop(null));
        }       

        [Test]               
        public void AddPartShouldIncreaseCount()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost);
            this.device.AddPart(this.part);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.device.Parts.Count);
        }

        [Test]             
        public void AddingExistingPartShouldThrow()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost);

            this.device.AddPart(this.part);

            Assert.Throws<InvalidOperationException>(
                () => this.device.AddPart(this.part));
        }

        [Test]                 
        public void PcAddWrongTypeOfPartShouldThrow()
        {
            this.device = new PC(this.defaultMake);

            string partName = "pc part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost);

            Assert.Throws<InvalidOperationException>(
                () => this.device.AddPart(this.part));
        }

        [Test]               
        public void LaptopAddWrongTypeOfPartShouldThrow()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "pc part name";
            decimal cost = 10m;
            this.part = new PCPart(partName, cost);
            
            Assert.Throws<InvalidOperationException>(
                () => this.device.AddPart(this.part));
        }

        [Test]                  
        public void PhoneAddWrongTypeOfPartShouldThrow()
        {
            this.device = new Phone(this.defaultMake);

            string partName = "pc part name";
            decimal cost = 10m;
            this.part = new PCPart(partName, cost);

            Assert.Throws<InvalidOperationException>(
                () => this.device.AddPart(this.part));
        }

        [Test]                 
        public void RemovePartShouldDecreaseCount()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost);

            this.device.AddPart(this.part);
            this.device.RemovePart(partName);

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.device.Parts.Count);
        }

        [Test]             
        public void RemovePartWithNullNameShouldThrow()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost);

            this.device.AddPart(this.part);

            Assert.Throws<ArgumentException>(
                () => this.device.RemovePart(null));
        }

        [Test]                 
        public void RemoveNonExistingPartShouldThrow()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost);

            this.device.AddPart(this.part);

            Assert.Throws<InvalidOperationException>(
                () => this.device.RemovePart("non-existing part"));
        }

        [Test]                 
        public void RepairPartShouldRepair()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost, true);

            this.device.AddPart(this.part);
            this.device.RepairPart(partName);

            Assert.IsFalse(this.part.IsBroken);
        }

        [Test]                
        public void RepairWithEmptyNameShouldThrow()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost, true);
            this.device.AddPart(this.part);

            Assert.Throws<ArgumentException>(
                () => this.device.RepairPart(string.Empty));
        }

        [Test]                 
        public void RepairNonExistingPartShouldThrow()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost);

            this.device.AddPart(this.part);

            Assert.Throws<InvalidOperationException>(
                () => this.device.RepairPart("non-existing part"));
        }

        [Test]
        public void RepairNotBrokenPartShouldThrow()
        {
            this.device = new Laptop(this.defaultMake);

            string partName = "part name";
            decimal cost = 10m;
            this.part = new LaptopPart(partName, cost);

            this.device.AddPart(this.part);

            Assert.Throws<InvalidOperationException>(
                () => this.device.RepairPart(partName));
        }
    }
}

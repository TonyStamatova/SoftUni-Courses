namespace Tests
{
    using System;

    using NUnit.Framework;

    using Service.Models.Contracts;
    using Service.Models.Parts;

    public class PartTests
    {
        private string defaultName = "name";
        private decimal defaultCost = 10m;
        private bool defaultIsBroken = true;

        private IPart laptopPart;
        private IPart pcPart;
        private IPart phonePart;

        [SetUp]
        public void Setup()
        {
        }

        [Test]               
        public void BaseConstructorCreatesLaptopPartCorrectly()
        {
            this.laptopPart = new LaptopPart(
                this.defaultName,
                this.defaultCost,
                this.defaultIsBroken);

            decimal expectedCost = 1.5m * defaultCost;

            Assert.AreEqual(this.defaultName, this.laptopPart.Name);
            Assert.AreEqual(expectedCost, this.laptopPart.Cost);
            Assert.AreEqual(this.defaultIsBroken, this.laptopPart.IsBroken);
        }

        [Test]                
        public void BaseConstructorCreatesPcPartCorrectly()
        {
            this.pcPart = new PCPart(
                this.defaultName,
                this.defaultCost,
                this.defaultIsBroken);
        
            decimal expectedCost = 1.2m * defaultCost;
        
            Assert.AreEqual(this.defaultName, this.pcPart.Name);
            Assert.AreEqual(expectedCost, this.pcPart.Cost);
            Assert.AreEqual(this.defaultIsBroken, this.pcPart.IsBroken);
        }

        [Test]             
        public void BaseConstructorCreatesPhonePartCorrectly()
        {
            this.phonePart = new PhonePart(
                this.defaultName,
                this.defaultCost,
                this.defaultIsBroken);

            decimal expectedCost = 1.3m * defaultCost;

            Assert.AreEqual(this.defaultName, this.phonePart.Name);
            Assert.AreEqual(expectedCost, this.phonePart.Cost);
            Assert.AreEqual(this.defaultIsBroken, this.phonePart.IsBroken);
        }

        [Test]
        public void LaptopPartCtorWithOnlyNameAndCostSetsIsBrokenToFalse()
        {
            this.laptopPart = new LaptopPart(
                this.defaultName,
                this.defaultCost);
        
            Assert.IsFalse(this.laptopPart.IsBroken);
        }

        [Test]
        public void PcPartCtorWithOnlyNameAndCostSetsIsBrokenToFalse()
        {
            this.pcPart = new PCPart(
                this.defaultName,
                this.defaultCost);

            Assert.IsFalse(this.pcPart.IsBroken);
        }

        [Test]               
        public void SettingNameToEmptyStringShouldThrow()
        {
            string name = string.Empty;

            Assert.Throws<ArgumentException>(
                () => this.laptopPart = new LaptopPart(
                    name, 
                    this.defaultCost, 
                    this.defaultIsBroken));
        }

        [Test]              
        public void SettingNameToNullStringShouldThrow()
        {
            string name = null;

            Assert.Throws<ArgumentException>(
                () => this.laptopPart = new LaptopPart(
                    name,
                    this.defaultCost,
                    this.defaultIsBroken));
        }

        [Test]              
        public void SettingZeroCostShouldThrow()
        {
            decimal zeroCost = 0m;

            Assert.Throws<ArgumentException>(
                () => this.laptopPart = new LaptopPart(
                    this.defaultName,
                    zeroCost,
                    this.defaultIsBroken));
        }

        [Test]
        public void SettingNegativeCostShouldThrow()
        {
            decimal negativeCost = -10m;
        
            Assert.Throws<ArgumentException>(
                () => this.laptopPart = new LaptopPart(
                    this.defaultName,
                    negativeCost,
                    this.defaultIsBroken));
        }

        [Test]             
        public void RepairSetsIsBrokenToFalse()
        {
            this.laptopPart = new LaptopPart(
                this.defaultName,
                this.defaultCost,
                this.defaultIsBroken);

            this.laptopPart.Repair();

            Assert.IsFalse(this.laptopPart.IsBroken);
        }

        [Test]              
        public void ReportReturnsCorrectString()
        {
            this.laptopPart = new LaptopPart(
                this.defaultName,
                this.defaultCost,
                this.defaultIsBroken);

            string expectedString = $"{this.laptopPart.Name} - {this.laptopPart.Cost:f2}$"
                + Environment.NewLine
                + $"Broken: {this.laptopPart.IsBroken}";

            Assert.AreEqual(expectedString, this.laptopPart.Report());
        }
    }
}


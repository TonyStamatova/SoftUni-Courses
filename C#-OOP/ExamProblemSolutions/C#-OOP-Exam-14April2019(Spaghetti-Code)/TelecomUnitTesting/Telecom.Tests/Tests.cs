namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Tests
    {
        private string make = "make";
        private string model = "model";
        private Phone phone;

        [Test]
        public void Constructor()
        {
            this.phone = new Phone(this.make, this.model);

            Assert.AreEqual("make", phone.Make);
            Assert.AreEqual("model", phone.Model);
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        public void NullStringMakeShouldThrow()
        {
            Assert.Throws<ArgumentException>(
                () => phone = new Phone(null, model));
        }

        [Test]
        public void ModelIsNullShouldThrow()
        {
            Assert.Throws<ArgumentException>(
                () => phone = new Phone(make, null));
        }

        [Test]
        public void ModelIsEmptyStringShouldThrow()
        {
            Assert.Throws<ArgumentException>(
                () => phone = new Phone(make, string.Empty));
        }

        [Test]
        public void AddContact()
        {
            this.phone = new Phone(this.make, this.model);
            this.phone.AddContact("contact", "6516513");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void AddShouldThrow()
        {
            this.phone = new Phone(this.make, this.model);
            this.phone.AddContact("contact", "6516513");

            Assert.Throws<InvalidOperationException>(
                () => phone.AddContact("contact", "123"));
        }

        [Test]
        public void Call()
        {
            this.phone = new Phone(this.make, this.model);
            this.phone.AddContact("contact", "6516513");
            

            string expected = $"Calling contact - 6516513...";

            Assert.AreEqual(expected, phone.Call("contact"));
        }

        [Test]
        public void CallThrows()
        {
            this.phone = new Phone(this.make, this.model);

            Assert.Throws<InvalidOperationException>(
                () => phone.Call("contact"));
        }
    }
}
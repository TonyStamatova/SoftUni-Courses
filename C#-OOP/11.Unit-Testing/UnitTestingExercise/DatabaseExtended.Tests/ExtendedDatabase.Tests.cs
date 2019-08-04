using System;

using NUnit.Framework;

using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase.ExtendedDatabase db;

        [SetUp]
        public void Setup()
        {
            long id = 123;
            string username = "user123";

            this.person = new Person(id, username);

            this.db = new ExtendedDatabase.ExtendedDatabase(person);
        }

        [Test]
        public void CreatingDbWithCorrectCount()
        {
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.db.Count);
        }

        [Test]                
        public void CreatingDbWithCapacityLargerThan16Throws()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, i.ToString());
            }

            Assert.That(
                () => this.db = new ExtendedDatabase.ExtendedDatabase(people),
                Throws.ArgumentException.With.Message
                    .EqualTo("Provided data length should be in range [0..16]!"));
        }

        //Add Method Tests
        [Test]
        public void CountIncreasesWhenAdding()
        {
            long id = 456;
            string username = "username456";
            Person newUser = new Person(id, username);
            this.db.Add(newUser);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.db.Count);
        }

        [Test]
        public void AddingUserWithExistingUsersUsernameShouldThrow()
        {
            long id = 456;
            Person newUser = new Person(id, this.person.UserName);

            Assert.That(
                () => this.db.Add(newUser),
                Throws.InvalidOperationException.With.Message
                    .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddingUserWithExistingUsersIdShouldThrow()
        {
            Person newUser = new Person(this.person.Id, "user456");

            Assert.That(
                () => this.db.Add(newUser),
                Throws.InvalidOperationException.With.Message
                    .EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void AddingElementWhenFullCapacityReachedThrows()
        {
            Person[] people = new Person[15];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, i.ToString());

                this.db.Add(people[i]);
            }

            long id = 456;
            string username = "username456";
            Person newUser = new Person(id, username);

            Assert.That(
                () => this.db.Add(newUser),
                Throws.InvalidOperationException.With.Message
                    .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        //Remove Method Tests
        [Test]
        public void RemoveElementRemovesLastElement()
        {
            this.db.Remove();

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.db.Count);
        }

        [Test]
        public void RemoveElementFromEmptyDbThrows()
        {
            this.db.Remove();

            Assert.That(
                () => this.db.Remove(),
                Throws.InvalidOperationException.With.Message
                    .EqualTo("Operation is not valid due to the current state of the object."));
        }

        //FindByUsername Method Tests
        [Test]
        public void FindByUsernameWithInvalidUsernameShouldThrow()
        {
            string invalidUsername = "user456";

            Assert.That(
                () => this.db.FindByUsername(invalidUsername),
                Throws.InvalidOperationException.With.Message
                    .EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsernameWithNullShouldThrow()
        {
            string nullUsername = null;

            Assert.That(
                () => this.db.FindByUsername(nullUsername),
                Throws.ArgumentNullException.With.Message
                    .EqualTo("Value cannot be null."
                    + Environment.NewLine
                    + "Parameter name: Username parameter is null!"));
        }

        [Test]
        public void FindByUsernameIsCaseSensitive()
        {
            string invalidUsername = this.person.UserName.ToUpper();

            Assert.That(
                () => this.db.FindByUsername(invalidUsername),
                Throws.InvalidOperationException.With.Message
                    .EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUserNameFindsCorrectPerson()
        {
            long id = 456;
            string username = "username456";
            Person newUser = new Person(id, username);
            this.db.Add(newUser);

            Person person = this.db.FindByUsername(username);

            Assert.AreEqual(newUser, person);
        }

        //FindById Method Tests
        [Test]
        public void FindByIdNoUserPresentShouldThrow()
        {
            long invalidId = 456;

            Assert.That(
                () => this.db.FindById(invalidId),
                Throws.InvalidOperationException.With.Message
                    .EqualTo("No user is present by this ID!"));
        }


        [Test]
        public void FindByIdNegativeIdShouldThrow()
        {
            long invalidId = -456;

            Assert.Throws<ArgumentOutOfRangeException>(
                () => this.db.FindById(invalidId),
                "Specified argument was out of the range of valid values."
                + Environment.NewLine
                + "Parameter name: Id should be a positive number!");
        }

        [Test]
        public void FindByIdFindsCorrectPerson()
        {
            long id = 456;
            string username = "username456";
            Person newUser = new Person(id, username);
            this.db.Add(newUser);

            Person person = this.db.FindById(id);

            Assert.AreEqual(newUser, person);
        }
    }
}

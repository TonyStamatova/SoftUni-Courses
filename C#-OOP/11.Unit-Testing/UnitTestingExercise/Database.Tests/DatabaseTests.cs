namespace Tests
{
    using System;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    public class DatabaseTests
    {
        private const int NEW_ELEMENT = 3;

        private const string CAPACITY_OVERFLOW_EXCEPTION_MESSAGE
            = "Array's capacity must be exactly 16 integers!";
        private const string EMPTY_COLLECTION_EXCEPTION_MESSAGE
            = "The collection is empty!";

        private int[] initialArray;
        private Database.Database db;

        [SetUp]
        public void Setup()
        {
            this.initialArray = new int[3] { 0, 1, 2 };
            this.db = new Database.Database(initialArray);
        }

        [Test]
        public void CapacityIs16()
        {
            FieldInfo dataFieldInfo = this.db
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == "data");

            int[] dataField = (int[])dataFieldInfo?.GetValue(db);

            Assert.That(dataField.Length, Is.EqualTo(16));
        }

        [Test]
        public void CreatingDbWithCorrectCount()
        {
            int expectedCount = 3;

            Assert.AreEqual(expectedCount, this.db.Count);
        }

        [Test]
        public void CountIncreasesWhenAdding()
        {
            this.db.Add(NEW_ELEMENT);
            int expectedCount = 4;

            Assert.AreEqual(expectedCount, this.db.Count);
        }

        [Test]
        public void CreatingDbWithCapacityLargerThan16Throws()
        {
            this.initialArray = new int[17];

            Assert.That(
                () => this.db = new Database.Database(initialArray),
                Throws.InvalidOperationException.With.Message
                    .EqualTo(CAPACITY_OVERFLOW_EXCEPTION_MESSAGE));
        }

        [Test]
        public void AddAddsElementOnNextFreeIndex()
        {
            this.db.Add(NEW_ELEMENT);

            int[] elements = db.Fetch();

            Assert.That(elements[3], Is.EqualTo(NEW_ELEMENT));
        }

        [Test]
        public void AddingElementWhenFullCapacityReachedThrows()
        {
            this.initialArray = new int[16];
            this.db = new Database.Database(initialArray);

            Assert.That(
                () => this.db.Add(NEW_ELEMENT),
                Throws.InvalidOperationException.With.Message
                    .EqualTo(CAPACITY_OVERFLOW_EXCEPTION_MESSAGE));
        }

        [Test]
        public void RemoveElementRemovesLastElement()
        {
            this.db.Remove();

            int[] elements = this.db.Fetch();
            int[] expected = new int[] { 0, 1 };

            Assert.AreEqual(expected, elements);
        }

        [Test]
        public void RemoveElementFromEmptyDbThrows()
        {
            for (int i = 0; i < 3; i++)
            {
                this.db.Remove();
            }

            Assert.That(
                () => this.db.Remove(),
                Throws.InvalidOperationException.With.Message
                    .EqualTo(EMPTY_COLLECTION_EXCEPTION_MESSAGE));
        }

        [Test]
        public void ConstructorShouldTakeOnlyInt()
        {
            ConstructorInfo constructor = this.db
                .GetType()
                .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault();

            ParameterInfo[] parameters = constructor.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                Assert.That(
                    parameter.ParameterType,
                    Is.EqualTo(typeof(Int32[])));
            }
        }

        [Test]
        public void FetchShouldReturnArray()
        {
            Assert.That(
                () => this.db.Fetch(),
                Is.InstanceOf(typeof(Int32[])));
        }
    }
}
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database data;//Database.Database and it works or remove Database so judge pass

        [SetUp]
        public void Setup()
        {
            data = new Database.Database();

        }

        [Test]
        public void When_CapacityReached_ShouldThrowException()
        {
            for (int i = 0; i < 16; i++)
            {
                data.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => data.Add(18));
            //Assert.That(count, Is.EqualTo(16), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void When_AddElementInDatabase_ShouldSeeAddedElement()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                this.data.Add(132);
            }

            Assert.That(this.data.Count, Is.EqualTo(n));
        }

        [Test]
        public void When_AddElementInDatabase()
        {
            int element = 100;

            this.data.Add(element);

            int[] elements = this.data.Fetch();

            Assert.IsTrue(elements.Contains(element));
        }
        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()//check for exception
        {
            Assert.Throws<InvalidOperationException>(() => this.data.Remove());
        }
        [Test]
        public void Remove_DecreaseDatabaseCount()
        {
            this.data.Add(1);
            this.data.Add(2);
            this.data.Add(3);

            this.data.Remove();

            Assert.That(this.data.Count, Is.EqualTo(2));
        }
        [Test]
        public void Remove_DecreaseElementFromDatabase()
        {
            this.data.Add(1);
            this.data.Add(2);
            this.data.Add(3);

            this.data.Remove();

            int[] elements = this.data.Fetch();


            Assert.IsFalse(elements.Contains(3));
        }
        [Test]
        public void Fetch_ReturnsDatabaseCopyInsteadOfRefference()
        {
            this.data.Add(1);
            this.data.Add(2);

            int[] firstCopy = this.data.Fetch();

            this.data.Add(3);

            int[] secondCopy = this.data.Fetch();

            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }
        [Test]
        public void Count_ReturnsZeroWhenDatabaseEmpty()
        {
            Assert.That(this.data.Count, Is.EqualTo(0));
        }
        [Test]
        public void Ctor_ThrowsException_WhenDatabaseCapacityIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => this.data = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }
        [Test]
        public void Ctor_AddsElementsToDatabase()
        {
            int[] arr = new[] { 1, 2, 3 };

            this.data = new Database.Database(arr);

            Assert.That(this.data.Count, Is.EqualTo(arr.Length));
            Assert.That(this.data.Fetch(), Is.EquivalentTo(arr));
        }
    }
}
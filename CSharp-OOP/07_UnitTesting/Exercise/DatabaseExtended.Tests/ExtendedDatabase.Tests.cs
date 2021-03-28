using ExtendedDatabase;

using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsNeeded()
        {

            for (int i = 0; i < 16; i++)
            {
                this.database.Add(new Person(i, $"Username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(16, "Invalid Username")));
        }
        [Test]
        public void Add_ThrowsException_TheUsernameIsUsed()
        {
            string username = "Kris";
            this.database.Add(new Person(1, username));

            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(2, username)));
        }

        [Test]
        public void Add_ThrowsException_RandomIdIsUsed()
        {
            long id = 1;
            this.database.Add(new Person(id, "RandomUser"));

            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(id, "RandomUser2")));
        }

        [Test]
        public void Add_IncreasesCounter_WhenUserIsValid()
        {
            this.database.Add(new Person(1, "Kris"));
            this.database.Add(new Person(2, "Gosho"));

            int expectedCount = 2;

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void Remove_ElementFromDatabase()
        {
            int n = 5;
            for (int i = 0; i < 5; i++)
            {
                this.database.Add(new Person(i, $"Username{i}"));
            }
            this.database.Remove();

            Assert.That(this.database.Count, Is.EqualTo(n - 1));
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsException_WhenArgumentNotValid(string username)//username parameter comes from TestCase
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ThrowsException_WhenUsernameNotExist()//username parameter comes from TestCase
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Username"));
        }

        [Test]
        public void FindByUsername_ReturnExpectedUser_WhenUserExissts()
        {

            Person person = new Person(1, "Kristian");

            this.database.Add(person);

            Person dbPerson = database.FindByUsername(person.UserName);

            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-25)]
        public void FindUserByID_IdShouldBePositiveNumber(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(id));
        }

        [Test]
        public void FindUser_IfExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(100));
        }

        [Test]
        public void FindById_ReturnsExpectedPersonById()
        {
            Person person = new Person(15, "Kristian");

            database.Add(person);

            Person dbPerson = database.FindById(person.Id);

            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityExceeded()
        {
            Person[] arguments = new Person[17];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }
            Assert.Throws<ArgumentException>(() => this.database = new ExtendedDatabase.ExtendedDatabase(arguments));
        }


        [Test]
        public void Ctor_AddInitialPeopleToDatabase()
        {
            Person[] arguments = new Person[5];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }

            this.database = new ExtendedDatabase.ExtendedDatabase(arguments);

            Assert.That(this.database.Count, Is.EqualTo(arguments.Length));


            foreach (var person in arguments)
            {
                Person dbPerson = this.database.FindById(person.Id);
                Assert.That(person, Is.EqualTo(dbPerson));
            }
            
        }

    }
}
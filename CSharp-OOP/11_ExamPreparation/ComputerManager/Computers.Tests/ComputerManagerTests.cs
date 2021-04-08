using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {

        private ComputerManager computerManager;
        
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            computer = new Computer("Lenovo", "T430s", 550);
        }

        [Test]
        public void Test_Computer()
        {
            Assert.IsNotNull(computer);
        }

        [Test]//not
        public void ComputerMenager()
        {
            var anotherMenager = new ComputerManager();

            Assert.IsNotNull(anotherMenager);
        }

        [Test]//not
        public void Test_Computers()
        {
            Assert.IsNotNull(this.computerManager.Computers);
        }

        [Test]
        public void AddComputer_WhenInvalidComputer()
        {
            Computer invalidComputer = null;

            Assert.That(() => this.computerManager.AddComputer(invalidComputer),
                Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'computer')"));
        }

        [Test]
        public void AddComputer_WhenComputerNameNull()
        {
            
            var manager = new ComputerManager();
            Assert.IsNotNull(manager);
            
        }

        [Test]
        public void AddComputer_WhenComputerAlreadyExist()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                computerManager.AddComputer(computer);
                computerManager.AddComputer(computer);
            });

            Assert.AreEqual(ex.Message, "This computer already exists.");
        }

        [Test]
        public void AddComputer_WhenAddedSuccesfully()
        {
            computerManager.AddComputer(computer);
            Assert.AreEqual(1, computerManager.Computers.Count);
        }

        [Test]
        public void RemoveComputer_WhenRemoveNotExistingComputer()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.RemoveComputer("Panasonic", "380");
            });
        }


        [Test]
        public void RemoveComputer_WhenShouldThrowNull()
        {
            computerManager.AddComputer(computer);

            Assert.That(() => computerManager.RemoveComputer(null, null), Throws.ArgumentNullException);
        }

        [Test]//check
        public void Test_RemoveComputerDecreaseCount()
        {
            computerManager.AddComputer(computer);

            computerManager.RemoveComputer("Lenovo", "T430s");
            Assert.AreEqual(0, computerManager.Computers.Count);
        }
        [Test]
        public void RemoveComputer_WhenSuccesfulRemoved()
        {
            computerManager.AddComputer(computer);

            var targetComputer = computerManager.RemoveComputer("Lenovo", "T430s");

            Assert.AreEqual(targetComputer, computer);
        }

        [Test]
        public void GetComputer_WithInvalidArguments()
        {
            computerManager.AddComputer(computer);

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                computerManager.GetComputer("HP", "something");

            });

            Assert.AreEqual(ex.Message, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputer_Working()
        {
            computerManager.AddComputer(computer);

            var targetComputer = computerManager.GetComputer("Lenovo", "T430s");

            Assert.AreEqual(computer, targetComputer);
        }

        [TestCase(null, "Gosho")]
        [TestCase("Test", null)]
        public void GetComputer_CheckForNullFields(string manufacturer, string model)
        {
            computerManager.AddComputer(computer);

            Assert.That(() =>
                computerManager.GetComputer(manufacturer, model),
                Throws.ArgumentNullException);
        }

        [Test]
        public void GetComputerByManufacturer_Working()
        {
            var anotherComputer = new Computer("Lenovo", "T530s", 2400M);

            this.computerManager.AddComputer(computer);
            this.computerManager.AddComputer(anotherComputer);

            var expectedList = new List<Computer>() { computer, anotherComputer };
            var result = this.computerManager.GetComputersByManufacturer("Lenovo");

            CollectionAssert.AreEqual(expectedList, result);
        }

        [Test]
        public void GetComputerByManufacturer_EmptyColletion()
        {

            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("Hp", "SomeOtherModel", 550));

            var emptyColletion = new List<Computer>();

            CollectionAssert.AreEqual(emptyColletion, computerManager.GetComputersByManufacturer("Assus"));
        }

        [Test]
        public void Validate_NullValue()
        {
            Computer pc = null;

            Assert.That(() => computerManager.AddComputer(pc), Throws.ArgumentNullException);
        }

        [Test]
        public void TestCounter_ShouldWork()
        {
            computerManager.AddComputer(computer);

            Assert.AreEqual(1, computerManager.Computers.Count);
        }
    }
}
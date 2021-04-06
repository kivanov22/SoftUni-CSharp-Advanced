using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private Dictionary<string, UnitDriver> drivers;
        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            drivers = new Dictionary<string, UnitDriver>();
        }

        [Test]
        public void AddDriver_ShouldThrowInvalid()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });

            Assert.AreEqual(ex.Message, "Driver cannot be null.");
        }

        [Test]
        public void AddDriver_ShouldThrowDriverAlreadyExist()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var driver = new UnitDriver("Pesho", new UnitCar("bmw", 350, 520));

                race.AddDriver(driver);
                race.AddDriver(driver);
            });

            Assert.AreEqual(ex.Message, $"Driver {"Pesho"} is already added.");
        }

        [Test]
        public void AddDriver_ShouldAddDriver()
        {
            var driver = new UnitDriver("Pesho", new UnitCar("bmw", 350, 520));
            string result = race.AddDriver(driver);

            Assert.AreEqual(result, $"Driver {"Pesho"} added in race.");
        }

        [Test]
        public void AddDriver_counter()
        {

            var driver1 = new UnitDriver("Pesho", new UnitCar("bmw", 350, 520));

            var result = race.AddDriver(driver1);
            Assert.AreEqual($"Driver {"Pesho"} added in race.", result);
            Assert.AreEqual(1, race.Counter);
            
        }
        [Test]
        public void CalculateAverageHorsePower_ShouldThrowWhenNotEnoughtPeople()
        {

            var driver1 = new UnitDriver("Pesho", new UnitCar("bmw", 350, 520));

            var result = race.AddDriver(driver1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldFindAverageWhenEnoughPeople()
        {

            var driver1 = new UnitDriver("Pesho", new UnitCar("bmw", 100, 520));
            var driver2 = new UnitDriver("Gosho", new UnitCar("mercedes", 100, 520));
            var driver3 = new UnitDriver("Tosho", new UnitCar("golf", 100, 520));

            var result1 = race.AddDriver(driver1);
            var result2 = race.AddDriver(driver2);
            var result3 = race.AddDriver(driver3);

            var result = race.CalculateAverageHorsePower();
            Assert.AreEqual(100, result);
        }
    }
}
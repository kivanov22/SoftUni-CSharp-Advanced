using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {

        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");//ExceptionMessages.InvalidName
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");//ExceptionMessages.InvalidNumberOfLaps
                }
                this.laps = value;
            }

        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers;
        //{ get; private set; }
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException("Driver cannot be null.");
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");
            }

            if (Drivers.Contains(driver))
            {
                throw new ArgumentException($"Driver {driver.Name} is already added in {Name} race.");
            }

            drivers.Add(driver);
        }
    }
}

//if (driver == null)
//            {
//                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
//            }
//            if (!driver.CanParticipate)
//            {
//                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");//ExceptionMessages.DriverNotParticipate
//            }
//            if (drivers.Contains(driver))
//            {
//                throw new ArgumentNullException($"Driver {driver.Name} is already added in {this.name} race.");//ExceptionMessages.DriverAlreadyAdded
//            }
//            this.drivers.Add(driver);
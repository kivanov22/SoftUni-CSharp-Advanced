using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {

        private string name;
        private int laps;
        private List<IDriver> drivers;//ICollection maybe

        public Race(string name,int laps)
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
                if (string.IsNullOrEmpty(value) || value.Length<5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfLaps);
                }
                this.laps = value;
            }

        }

        public IReadOnlyCollection<IDriver> Drivers { get; private set; }// get => this.drivers.ToList().AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(ExceptionMessages.DriverNotParticipate);
            }
            if (drivers.Contains(driver))
            {
                throw new ArgumentException(ExceptionMessages.DriverAlreadyAdded);
            }
            this.drivers.Add(driver);
        }
    }
}

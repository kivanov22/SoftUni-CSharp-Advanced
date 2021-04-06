using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private bool canParticipate;
        private ICar car;
        private int numberOfWins;
        public Driver(string name)
        {
            Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length<5)//Todo maybe fix message
                {
                    throw new ArgumentException($"Name {name} cannot be less than 5 symbols.");//ExceptionMessages.InvalidName
                }
                this.name = value;
            }
        }

        public ICar Car// { get; private set; }
        {
            get => car;
            private set
            {
                car = value;
            }
        }
        public int NumberOfWins //{ get; private set; }
        {
            get => numberOfWins;
            private set
            {
                numberOfWins = value;
            }
        }
        public bool CanParticipate
        {
            get => canParticipate;
            private set
            {
                if (Car == null)
                {
                    canParticipate = false;
                }
                else
                {
                    canParticipate = true;
                }
            }
        }

        public void AddCar(ICar car)
        {
            if (car ==null)
            {
                throw new ArgumentNullException(nameof(ICar),"Car cannot be null.");//addded nameof
            }

            Car = car;
            canParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}

﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private bool canParticipate = false;
        public Driver(string name)
        {

        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length<5)//Todo maybe fix message
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get => this.canParticipate;
            private set
            {
                if (this.Car != null)
                {
                    this.canParticipate = value;
                }
            }
        }

        public void AddCar(ICar car)
        {
            if (car ==null)
            {
                throw new ArgumentNullException("Car cannot be null.");
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

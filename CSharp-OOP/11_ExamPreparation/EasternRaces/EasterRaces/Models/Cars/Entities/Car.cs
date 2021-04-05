﻿using EasterRaces.Models.Cars.Contracts;
using System;

namespace EasterRaces.Models.Cars.Entities
{

    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
        }
        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)//TODo maybe change message
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");//ExceptionMessages.InvalidModel
                }
                this.model = value;
            }
        }

        public int HorsePower { get; private set; }


        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            //cubic centimeters / horsepower * laps

            return CubicCentimeters / HorsePower * laps;
        }
    }
}


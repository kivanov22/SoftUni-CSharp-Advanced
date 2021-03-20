using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;//only for car
        public Car(int horsePower, double fuel) : base(horsePower,fuel)
        {
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}

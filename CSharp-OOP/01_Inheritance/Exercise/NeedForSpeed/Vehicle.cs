using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        // private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;

        }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }



        public virtual double FuelConsumption => 1.25;//when only getter
                                                      //here can be DefaultFuelConsumption if we use private field
        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
    }
}

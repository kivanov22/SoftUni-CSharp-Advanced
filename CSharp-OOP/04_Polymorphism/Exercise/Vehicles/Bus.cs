using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirConditioner = 1.4;
        
        public Bus(double fuel, double fuelConsumption, double tankCapacity) 
            : base(fuel, fuelConsumption, tankCapacity, BusAirConditioner)
        {
        }

        public void TurnOnAirCondition()
        {
            this.AirConditioner = BusAirConditioner;
        }
        public void TurnOffAirCondition()
        {
            this.AirConditioner = 0;
        }
    }
}

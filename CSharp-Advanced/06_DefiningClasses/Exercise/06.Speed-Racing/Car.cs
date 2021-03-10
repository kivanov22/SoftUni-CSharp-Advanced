using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Speed_Racing
{
    public class Car
    {

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public bool Drive(double distanceTravelled)
        {
            double fuelNeeded = distanceTravelled * this.FuelConsumptionPerKilometer;

            if (fuelNeeded>this.FuelAmount)
            {
                return false;
            }
            this.TravelledDistance += distanceTravelled;
            this.FuelAmount -= fuelNeeded;
            return true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Raw_Data
{
    public class Cargo
    {

        public Cargo(int cargoWeigth, string cargoType)
        {

            this.CargoWeight = cargoWeigth;
            this.CargoType = cargoType;
        }


        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
    }
}

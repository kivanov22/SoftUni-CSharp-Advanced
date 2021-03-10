using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Raw_Data
{
    public class Car
    {

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tires;
        }



        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tire { get; set; }






    }
}

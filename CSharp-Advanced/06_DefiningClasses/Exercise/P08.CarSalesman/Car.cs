using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CarSalesman
{
    public class Car
    {
        public Car(string model, int engine)
        {
            Model = model;
            Engine = engine;
        }
        public string Model { get; set; }

        public int Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }
    }
}

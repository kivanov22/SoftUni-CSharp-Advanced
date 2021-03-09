using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new List<Tire[]>();
            string command = Console.ReadLine();

            while (command != "No more tires")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var currentTires = new Tire[4]
                {
                    new Tire(int.Parse(input[0]), double.Parse(input[1])),
                    new Tire(int.Parse(input[2]), double.Parse(input[3])),
                    new Tire(int.Parse(input[4]), double.Parse(input[5])),
                    new Tire(int.Parse(input[6]), double.Parse(input[7]))
                };

                tires.Add(currentTires);


                command = Console.ReadLine();
            }

            var engines = new List<Engine>();
            command = Console.ReadLine();

            while (command != "Engines done")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var engine = new Engine(int.Parse(input[0]), double.Parse(input[1]));

                engines.Add(engine);

                command = Console.ReadLine();
            }

            var cars = new List<Car>();

             command = Console.ReadLine();

            while (command != "Show special")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var make = input[0];
                var model = input[1];
                var year = int.Parse(input[2]);
                var fuelQuantity = double.Parse(input[3]);
                var fuelCapacity = double.Parse(input[4]);
                var engineIndex = int.Parse(input[5]);
                var tireIndex = int.Parse(input[6]);

                if ((engineIndex >= 0 && engineIndex < engines.Count) && (tireIndex >= 0 && tireIndex < tires.Count))//check if valid index
                {
                    var car = new Car(make, model, year, fuelQuantity, fuelCapacity, engines[engineIndex], tires[tireIndex]);
                    cars.Add(car);
                }

                command = Console.ReadLine();
            }
            cars = cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10).ToList();

            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            
            var tires = new List<Tire[]>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                
                var current = new Tire[4]
                {
                    new Tire(double.Parse(tokens[5]), int.Parse(tokens[6])),
                    new Tire(double.Parse(tokens[7]), int.Parse(tokens[8])),
                    new Tire(double.Parse(tokens[9]), int.Parse(tokens[10])),
                    new Tire(double.Parse(tokens[11]), int.Parse(tokens[12]))
                };
                tires.Add(current);

                var cargos = new List<Cargo>();
                var cargo = new Cargo(cargoWeight, cargoType);
                cargos.Add(cargo);


                var engines = new List<Engine>();
                var engine = new Engine(engineSpeed, enginePower);
                engines.Add(engine);
                
                var car = new Car(model,engine,cargo ,current);
                cars.Add(car);

                
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {

                cars
                    .Where(x => x.Cargo.CargoType == command)
                    .Where(x => x.Tire.Any(t => t.TirePressure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
                //foreach (var car in cars)
                //{
                //    if (car.Tire[].TirePressure<1 && )
                //    {
                //        Console.WriteLine(car.Model);
                //    }
                //}
            }
            else if (command == "flamable")
            {
                foreach (var car in cars)
                {
                    if (car.Engine.EnginePower > 250 && car.Cargo.CargoType == command)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}

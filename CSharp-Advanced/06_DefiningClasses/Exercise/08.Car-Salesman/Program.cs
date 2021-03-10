using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = tokens[0];
                int power = int.Parse(tokens[1]);
                Engine engine = new Engine(engineModel, power);

                if (tokens.Length == 3)
                {
                    
                    string parameter = tokens[2];
                    
                    if (Char.IsDigit(parameter, 0))
                    {
                        string displacement = parameter;
                        engine.Displacement = displacement;

                    }

                    else
                    {
                        string efficiency = parameter;
                        engine.Efficiency = efficiency;
                    }

                }
                else if (tokens.Length == 4)
                {
                    string displacement = tokens[2];
                    string efficiency = tokens[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = tokens[0];
                string engineModel = tokens[1];
                Engine engine = engines.FirstOrDefault(e => e.EngineModel == engineModel);
                Car car = new Car(carModel, engine);

                if (tokens.Length == 3)
                {
                    string parameter = tokens[2];
                    if (Char.IsDigit(parameter, 0))
                    {
                        string weigth = parameter;
                        car.Weight = weigth;
                    }
                    else
                    {
                        string color = parameter;
                        car.Color = color;
                    }
                }
                else if (tokens.Length == 4)
                {
                    string weight = tokens[2];
                    string color = tokens[3];
                    car.Weight = weight;
                    car.Color = color;
                }
                cars.Add(car);
            }
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

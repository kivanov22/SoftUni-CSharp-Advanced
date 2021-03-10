using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Speed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();


            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ");
                string model = info[0];
                double fuelAmount = double.Parse(info[1]);
                double fuelConsumptionFor1km = double.Parse(info[2]);

                Car currentCar = new Car//inline inicialization
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumptionFor1km
                };
                cars.Add(currentCar);
            }
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split(" ");
                string model = cmdArgs[1];
                double distanceTravelled = double.Parse(cmdArgs[2]);

                Car car = cars.FirstOrDefault(c => c.Model == model);

                bool canDrive = car.Drive(distanceTravelled);

                if (!canDrive)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                command = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}

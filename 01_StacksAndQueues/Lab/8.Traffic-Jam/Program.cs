using System;
using System.Collections.Generic;

namespace _8.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsGreen = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();

            int countCars = 0;

            while (command!="end")
            {
                if (command=="green")
                {
                    for (int i = 0; i < carsGreen; i++)
                    {
                        if (cars.Count>0)
                        {
                            Console.WriteLine(cars.Dequeue() + " passed!");
                            countCars++;
                        }
                    }
                }
                else 
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"{countCars} cars passed the crossroads.");
        }
    }
}

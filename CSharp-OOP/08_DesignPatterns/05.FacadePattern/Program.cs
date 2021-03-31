using System;

namespace _05.FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                .WithType("BMW")
                .WithColor("Black")
                .WithNumberOfDoors(5)
                .Built
                .InCity("Bulgaria")
                .AtAdress("Some adress 254")
                .Build();

            Console.WriteLine(car);


        }
    }
}


using DependencyInjectionWorkShop.Contracts;
using DependencyInjectionWorkShop.Contracts.Loggers;
using System;

namespace DependencyInjectionWorkShop
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            Engine engine = new Engine(logger);

            engine.Start();
            engine.End();
        }
    }
}

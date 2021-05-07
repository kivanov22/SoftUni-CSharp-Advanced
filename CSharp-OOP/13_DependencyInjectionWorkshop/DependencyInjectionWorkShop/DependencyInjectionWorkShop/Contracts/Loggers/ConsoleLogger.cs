using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionWorkShop.Contracts.Loggers
{
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}

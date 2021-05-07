using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DependencyInjectionWorkShop.Contracts.Loggers
{
    class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using(StreamWriter writer = new StreamWriter("../../../logs.txt",true))
            {
                writer.WriteLine(message);
            }
        }
    }
}

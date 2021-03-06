using System;
using System.IO;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
           using(StreamReader reader = new StreamReader("input.txt"))
            {
                string readRow = reader.ReadLine();
                int counter = 1;

                using(StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    while (readRow!=null)
                    {
                        writer.WriteLine($"{counter}. {readRow}");
                        readRow = reader.ReadLine();
                        counter++;
                    }
                }

            }
        }
    }
}

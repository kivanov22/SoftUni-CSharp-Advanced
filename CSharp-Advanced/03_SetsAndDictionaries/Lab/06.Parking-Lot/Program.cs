using System;
using System.Collections.Generic;

namespace _06.Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> record = new HashSet<string>();

            while (input!="END")
            {
                string[] cmdArgs = input.Split(", ");
                string command = cmdArgs[0];
                string plate = cmdArgs[1];

                if (command=="IN")
                {
                    record.Add(plate);
                }
                else if (command=="OUT")
                {
                    record.Remove(plate);
                }

                input = Console.ReadLine();
            }

            if (record.Count>0)
            {
                foreach (var car in record)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
 
        }
    }
}

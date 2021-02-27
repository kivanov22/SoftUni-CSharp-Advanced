using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Super_Martket
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Queue<string> queue = new Queue<string>();
            //List<string> names = new List<string>();

           // int count = 0;
            while ((command = Console.ReadLine()) != "End")
            {
               // count++;

                if (command == "Paid")
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    //queue.Clear();
                    //count = 0;
                }
                else
                {
                    //names.Add(command);
                    queue.Enqueue(command);
                }

                


            }
            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}

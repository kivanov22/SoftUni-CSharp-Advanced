using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
            Queue<string> carsQueue = new Queue<string>();

            string command = Console.ReadLine();

            int count = 0;

            while (command!="END")
            {

                int greenLight = greenLightSeconds;
                int freeWindow = freeWindowSeconds;

                if (command=="green")
                {
                    while (greenLight>0 && carsQueue.Count!=0)
                    {
                        string firstQue = carsQueue.Dequeue();
                        greenLight -= firstQue.Count();

                        if (greenLight>=0)
                        {
                            count++;    
                        }
                        else
                        {
                            freeWindow += greenLight;
                            if (freeWindow<0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firstQue} was hit at {firstQue[firstQue.Length+freeWindow]}.");
                                return;
                            }
                            count++;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
                
                   
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");
        }
    }
}

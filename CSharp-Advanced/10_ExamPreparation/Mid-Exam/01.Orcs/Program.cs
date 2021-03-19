using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Orcs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberWaves = int.Parse(Console.ReadLine());
            Queue<int> plate = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> orc = new Stack<int>();
            int count = 0;

            for (int i = 0; i < numberWaves; i++)
            {
                //int[] 
                count++;
                if (plate.Count == 0)
                {
                    break;
                }
                orc = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
                int currentPlate = plate.Peek();

                if (count % 3 == 0)
                {
                    int plateToAdd = int.Parse(Console.ReadLine());
                    plate.Enqueue(plateToAdd);
                }

                while (orc.Count > 0 && plate.Count > 0)
                {


                    int currentOrc = orc.Peek();
                    if (orc.Count==0 && plate.Count==0)
                    {
                        break;
                    }
                    if (currentOrc > currentPlate)
                    {
                        plate.Dequeue();
                        orc.Pop();
                        currentOrc -= currentPlate;
                        orc.Push(currentOrc);
                        if (currentOrc == 0)
                        {
                            orc.Pop();
                        }
                        if (plate.Count == 0)
                        {
                            break;
                        }

                    }
                    if (currentPlate > currentOrc)
                    {
                        orc.Pop();

                        currentPlate -= currentOrc;
                        if (currentPlate == 0)
                        {
                            plate.Dequeue();
                        }
                        if (orc.Count==0)
                        {
                            break;
                        }
                        plate.Prepend(currentPlate);
                    }
                    if (currentOrc == currentPlate)
                    {
                        plate.Dequeue();
                        orc.Pop();
                    }
                }

            }
            if (!orc.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plate)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orc)}");
            }
        }
    }
}
//for (int j = 0; j < orcWaves.Length; j++)
//{
//    int currentWaveOrc = orcWaves[j];
//    orc.Push(currentWaveOrc);
//}
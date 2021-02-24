using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> pumpData = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                pumpData.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)//we go through the petrol pumps,tries for which we will start from begining to end, count circles
            {
                int currentPetrolAmount = 0;
                bool isSuccessful = true;//inside not outside the for because it will never become true

                for (int k = 0; k < n; k++)//going throgh the pumps and swapping them, moving the data swaping its places
                {
                    int[] petrolPumps = pumpData.Dequeue().Split(" ").Select(int.Parse).ToArray();//we remove the first petrol pump 1 | 5
                    //and we parse the numbers from string to int
                    pumpData.Enqueue(string.Join(" ", petrolPumps));// we swap here the data

                    currentPetrolAmount += petrolPumps[0];//we add the petrol

                    currentPetrolAmount -= petrolPumps[1];//we remove the km

                    if (currentPetrolAmount < 0)//if less then 0 , we didn't make it
                    {
                        isSuccessful = false;
                    }
                }

                if (isSuccessful)
                {
                    Console.WriteLine(i);
                    break;
                }
                string tempData = pumpData.Dequeue();//we remove the last pump
                pumpData.Enqueue(tempData);//we enque the last pump
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfFood = int.Parse(Console.ReadLine());
            int[] quantityOrders = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(quantityOrders);

            Console.WriteLine(quantityOrders.Max());
            bool noFood = false;
            while (orders.Any())
            {
                if (noFood)
                {
                    break;
                }
                for (int i = 0; i < quantityOrders.Length; i++)
                {
                    int currentOrder = quantityOrders[i];

                    if (currentOrder<=amountOfFood)
                    {
                        amountOfFood -= currentOrder;
                        orders.Dequeue();
                    }
                    else
                    {
                        noFood = true;
                        break;
                    }
                }
                

                    
                
            }
            if (orders.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {(string.Join(" ",orders))}");//orders.Peek()
            }
        }
    }
}

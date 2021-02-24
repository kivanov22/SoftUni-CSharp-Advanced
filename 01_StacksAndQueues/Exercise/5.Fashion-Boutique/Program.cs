using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxClothes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> allClothes = new Stack<int>(boxClothes);

            int currentCapacity = capacity;
            int countRafts = 1;

            while (allClothes.Any())
            {

                int clothes = allClothes.Pop();

                currentCapacity -= clothes;//we take the cloth from the stack

                if (currentCapacity < 0)
                {


                    countRafts++;
                    currentCapacity = capacity-clothes;
                }
            }
            Console.WriteLine(countRafts);

        }
    }
}

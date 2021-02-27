using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sezeGunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());


            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);
            int countBullets = 0;
            int currentBarrelSize = sezeGunBarrel;
            while (bullets.Any() && locks.Any())
            {

                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();
                countBullets++;
                currentBarrelSize--;
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();

                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (currentBarrelSize == 0 && bullets.Any())
                {
                    currentBarrelSize = sezeGunBarrel;
                    Console.WriteLine("Reloading!");
                }
            }
            if (!locks.Any())
            {
                int moneyEarned = intelligence - (countBullets * priceBullet);

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                
            }
            else 
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}

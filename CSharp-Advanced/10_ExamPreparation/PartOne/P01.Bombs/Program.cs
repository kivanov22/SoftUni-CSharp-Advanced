using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int sum = 0;
            Dictionary<string, int> bombMakings = new Dictionary<string, int>
            {
                { "Datura Bombs:",0 },
                {"Cherry Bombs:" ,0},
                { "Smoke Decoy Bombs:",0}
            };

            while (bombEffects.Count > 0 && bombCasing.Count > 0)
            {
                if (bombEffects.Count == 0 || bombCasing.Count == 0)
                {

                    break;
                }
                int currentBombEffect = bombEffects.Peek();
                int currentBombCasing = bombCasing.Peek();

                sum = currentBombCasing + currentBombEffect;

                if (bombMakings.All(b => b.Value >= 3))
                {
                    break;
                }
                if (sum == 40)
                { 
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                    bombMakings["Datura Bombs:"]++;
                   
                }
                else if (sum == 60)
                {
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                    bombMakings["Cherry Bombs:"]++;
                }
                else if (sum == 120)
                {
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                    bombMakings["Smoke Decoy Bombs:"]++;
                }
                else
                {
                    bombCasing.Pop();
                    currentBombCasing -= 5;
                    bombCasing.Push(currentBombCasing);
                }
            }
            if (bombMakings.All(b => b.Value >= 3))
            {

                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Any())
            {
                Console.WriteLine($"Bomb Effects: { string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            foreach (var item in bombMakings.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int sum = 0;
            int claimedItems = 0;
            while (firstBox.Count>0 || secondBox.Count>0)
            {
                if (firstBox.Count==0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                if (secondBox.Count==0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
                int currentFirst = firstBox.Peek();
                int currentSecond = secondBox.Peek();

                sum = currentFirst + currentSecond;
                
                if (sum%2==0)
                {
                    firstBox.Dequeue();
                    secondBox.Pop();
                    claimedItems += sum;

                }
                else
                {
                    firstBox.Enqueue(currentSecond);
                    secondBox.Pop();
                }
            }
            if (sum>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}

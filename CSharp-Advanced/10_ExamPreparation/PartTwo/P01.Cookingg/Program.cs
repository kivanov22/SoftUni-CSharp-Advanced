﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Cookingg
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int sum = 0;
            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Peek();
                int currentIngredient = ingredients.Peek();

                sum = currentLiquid + currentIngredient;

                if (liquids.Count == 0 || ingredients.Count == 0)
                {
                    break;
                }
                switch (sum)
                {
                    case 25:
                        bread++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 50:
                        cake++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 75:
                        pastry++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 100:
                        fruitPie++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    default:
                        liquids.Dequeue();
                        currentIngredient += 3;
                        ingredients.Pop();
                        ingredients.Push(currentIngredient);
                        break;

                }
            }
            if (bread !=0 && cake !=0 && pastry!=0 && fruitPie!=0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (!liquids.Any())
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }
            if (!ingredients.Any())
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: { string.Join(", ", ingredients)}");
            }
            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
        }
    }
}
//Bread 25
//Cake 50
//Pastry 75
//Fruit Pie	100

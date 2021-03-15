using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] ingredientsData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>(liquidsData);
            Stack<int> ingredients = new Stack<int>(ingredientsData);

            Dictionary<string, int> products = new Dictionary<string, int>
            {
                { "Bread",0 },
                {"Cake",0 },
                { "Fruit Pie",0},
                { "Pastry",0}
            };

            int sum = 0;


            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                if (liquids.Count == 0 || ingredients.Count == 0)
                {
                    break;
                }
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Peek();

                sum = currentIngredient + currentLiquid;


                if (sum == 25)
                {
                    ingredients.Pop();
                    products["Bread"]++;
                }
                else if (sum == 50)
                {
                    ingredients.Pop();
                    products["Cake"]++;
                }
                else if (sum == 75)
                {
                    ingredients.Pop();
                    products["Pastry"]++;
                }
                else if (sum == 100)
                {
                    ingredients.Pop();
                    products["Fruit Pie"]++;
                }
                else
                {
                    ingredients.Pop();
                    currentIngredient += 3;
                    ingredients.Push(currentIngredient);
                }
            }
            if (!products.ContainsValue(0))//!ingredients.Any() && !liquids.Any()
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Any())//.Count!=0
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            foreach (var item in products.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
//Bread 25
//Cake 50
//Pastry 75
//Fruit Pie	100

using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {

                string[] clothes = Console.ReadLine().Split(new[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);//only space is -> for both sides of this 

                string colour = clothes[0];
                string[] allClothing = clothes.Skip(1).ToArray();//this method takes all after colour

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                Dictionary<string, int> currentWardrobe = wardrobe[colour];//because we set the colour in the above dictionary

                foreach (string item in allClothing)
                {

                    if (!currentWardrobe.ContainsKey(item))
                    {
                        currentWardrobe.Add(item, 0);
                    }
                    currentWardrobe[item]++;

                }
            }

            string[] searchClothing = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            foreach ((string color, Dictionary<string, int> colorData) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach ((string clothing, int count) in colorData)
                {
                    if (searchClothing[0] == color && searchClothing[1] == clothing)
                    {
                        Console.WriteLine($"* {clothing} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing} - {count}");

                    }
                }
            }
        }
    }
}

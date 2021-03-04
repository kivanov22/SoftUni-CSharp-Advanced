using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            string command = Console.ReadLine();

            while (command!="Revision")
            {
                string[] products = command.Split(", ");

                string shop = products[0];
                string fruit = products[1];
                double price = double.Parse(products[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                if (!shops[shop].ContainsKey(fruit))
                {
                    shops[shop].Add(fruit, price);
                }

                command = Console.ReadLine();
            }
           // shops = shops.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}

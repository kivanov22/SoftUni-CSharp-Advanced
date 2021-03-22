using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();
            try
            {
                 people = ReadPeople();
                products = ReadProducts();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
                
            }
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {
                    break;

                }

                var parts = line.Split();
                var personName = parts[0];
                var prodcutName = parts[1];

                var person = people[personName];
                var product = products[prodcutName];

                try
                {
                    person.AddProduct(product);
                    Console.WriteLine($"{personName} bought {prodcutName}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);

                }



            }

            foreach (var item in people.Values)
            {
                Console.WriteLine(item);
            }
        }

        private static Dictionary<string, Product> ReadProducts()
        {
            var result = new Dictionary<string, Product>();
            var parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in parts)
            {
                var productData = item.Split("=", StringSplitOptions.RemoveEmptyEntries);

                var productName = productData[0];
                var cost = decimal.Parse(productData[1]);

                result[productName] = new Product(productName, cost);


            }

            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            var result = new Dictionary<string, Person>();
            var parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in parts)
            {
                var personData = item.Split("=", StringSplitOptions.RemoveEmptyEntries);

                var name = personData[0];
                var money = decimal.Parse(personData[1]);

                result[name] = new Person(name, money);
            }
            return result;
        }
    }
}

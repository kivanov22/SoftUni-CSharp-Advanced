using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> BagOfProducts;


        public Person(string name ,decimal money)
        {
            Name = name;
            Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "Name cannot be empty");
                this.name = value;
            }
        }

        public decimal Money 
        {
            get => this.money;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            } 
        }

        public void AddProduct(Product product)
        {
            if (product.Cost>this.Money)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }
            this.BagOfProducts.Add(product);
            this.Money -= product.Cost;
        }


        public override string ToString()
        {
            if (this.BagOfProducts.Count==0)
            {
                return $"{this.Name} - Nothing bought";
            }
            return $"{this.Name} - {string.Join(", ", this.BagOfProducts.Select(p => p.Name))}";
        }
    }
}

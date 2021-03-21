using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
  public class Pizza
    {
        private const int minNumberToppings = 0;
        private const int maxNumberToppings = 10;
        private const int NameMinLength =1;
        private const int NameMaxLength =15;
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length<NameMinLength || value.Length > NameMaxLength) 
                {
                    throw new ArgumentException($"Pizza name should be between {NameMinLength} and {NameMaxLength} symbols.");
                }
                this.name = value;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count==10)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [{minNumberToppings}..{maxNumberToppings}].");
            }
            this.toppings.Add(topping);
        }
        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
        }
    }
}

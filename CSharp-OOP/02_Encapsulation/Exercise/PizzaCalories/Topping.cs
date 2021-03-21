using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public class Topping
    {
        private const int min = 1;
        private const int max = 50;
        private string name;
        private int weight;

        public Topping(string name , int weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                var valueAsLower = value.ToLower();

                if (valueAsLower!="meat" && valueAsLower!="veggies"&& valueAsLower!="cheese"&& valueAsLower!="sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.name = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(1, 50, value, $"{this.Name} weight should be in the range [{min}..{max}].");
                this.weight = value;
            }
            
        }
        public double GetCalories()
        {
            var modifier = GetModifier();

            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameToLower = this.Name.ToLower();

            if (nameToLower=="meat")
            {
                return 1.2;

            }
            if (nameToLower == "veggies")
            {
                return 0.8;

            }
            if (nameToLower == "cheese")
            {
                return 1.1;

            }
            return 0.9;
        }
    }
}

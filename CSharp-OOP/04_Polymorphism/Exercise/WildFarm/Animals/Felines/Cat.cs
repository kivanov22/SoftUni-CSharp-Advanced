using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Felines
{
    public class Cat : Feline
    {
        private const double BaseWeightModifier = 0.30;
        private static HashSet<string> AllowedFood = new HashSet<string>
        {
            nameof(Meat),nameof(Vegetable)
        };
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, AllowedFood, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}

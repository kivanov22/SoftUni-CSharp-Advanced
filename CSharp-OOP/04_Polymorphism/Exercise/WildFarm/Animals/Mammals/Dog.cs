using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Birds;

namespace WildFarm.Animals.Mammals
{
    public class Dog:Mammal
    {
        private const double BaseWeightModifier = 0.40;
        private static HashSet<string> AllowedFood = new HashSet<string>
        {
            nameof(Meat)
        };
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, AllowedFood, BaseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}

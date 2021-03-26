using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double BaseWeightModifier = 0.35;
        private static HashSet<string> AllowedFood = new HashSet<string>
        {
            nameof(Meat),nameof(Fruit),nameof(Vegetable),nameof(Seeds)
        };
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, AllowedFood, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}

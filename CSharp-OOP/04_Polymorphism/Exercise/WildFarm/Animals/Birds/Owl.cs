using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double BaseWeightModifier = 0.25;
        private static HashSet<string> AllowedFood = new HashSet<string>
        {
            nameof(Meat)
        };
        public Owl(string name, double weight,double wingSize)
            : base(name, weight, AllowedFood, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        
    }
}

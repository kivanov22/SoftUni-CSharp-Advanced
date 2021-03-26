using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Felines
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifier = 1.00;
        private static HashSet<string> AllowedFood = new HashSet<string>
        {
            nameof(Meat)
        };
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight,  AllowedFood, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
           return "ROAR!!!";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Birds;

namespace WildFarm.Animals.Felines
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, HashSet<string> allowedFoods, double weightModifier, string livingRegion,string breed) 
            : base(name, weight, allowedFoods, weightModifier, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get;private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}

using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly List<IAquarium> aquariums;
        
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
           
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType=="FreshwaterAquarium")
            {
                aquarium =new FreshwaterAquarium(aquariumName);
            }
           else  if (aquariumType=="SaltwaterAquarium")
            {
                aquarium =new SaltwaterAquarium(aquariumName);
            }

            if(aquarium==null)
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            this.aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType=="Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType=="Plant")
            {
                decoration = new Plant();
            }

            if (decoration == null)
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            this.decorations.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            if (fishType== "FreshwaterFish")
            {
                fish =new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType== "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            if (fish == null)
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            var fishWaterType = fish.GetType().Name.Contains("Fresh") ? "Fresh" : "Salt";

            if (!aquarium.GetType().Name.StartsWith(fishWaterType))
            {
                return "Water not suitable.";
            }
            aquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            var sum = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return $"The value of Aquarium {aquariumName} is {sum}.";

        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.Feed();

            var fishCount = aquarium.Fish.Count;

            return $"Fish fed: {fishCount}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration is null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

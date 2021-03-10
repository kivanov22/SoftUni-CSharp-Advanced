using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
   public class Trainer
    {

        private string nameOfTrainer;
        private int numberOfBadges;
        private List<Pokemon> pokemons;
        public Trainer(string nameTrainer)
        {
            this.NameTrainer = nameTrainer;
            this.NumberOfBadges = 0;
            this.Pokemons = new List<Pokemon>();
           
        }
        public string NameTrainer { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

       //public void IncreaseNumberBadges()
       // {
       //     this.numberOfBadges++;
       // }
    }
}

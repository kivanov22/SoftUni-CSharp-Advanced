using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
   public class Pokemon
    {
        private string nameofPokemon;
        private string element;
        private int health;

        public Pokemon(string namePokemon,string element,int health)
        {
            this.NamePokemon = namePokemon;
            this.Element = element;
            this.Health = health;
        }

        public string NamePokemon { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }
    }
}

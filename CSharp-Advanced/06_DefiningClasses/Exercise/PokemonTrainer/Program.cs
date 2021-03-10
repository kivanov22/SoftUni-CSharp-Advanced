using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
           
            string command = Console.ReadLine();
            
            while (command!="Tournament")
            {
                string[] tokens = command.Split(" ");
                string nameTrainer = tokens[0];
                string namePokemon = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(namePokemon, element, health);

                var trainer = trainers.FirstOrDefault(t => t.NameTrainer == nameTrainer);

                if (trainer!=null)
                {
                    trainer.Pokemons.Add(pokemon);
                }
                else
                {
                    var newTrainer = new Trainer(nameTrainer);
                    newTrainer.Pokemons.Add(pokemon);
                    trainers.Add(newTrainer);
                }


                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command!="End")
            {
                switch (command)
                {
                    case "Fire":
                        CheckTrainer(trainers, command);
                        break;
                    case "Water":
                        CheckTrainer(trainers, command);
                        break;
                    case "Electricity":
                        CheckTrainer(trainers, command);
                        break;
                    
                }

                command = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.NameTrainer} {trainer.NumberOfBadges} {trainer.Pokemons.Count}  ");
            }
        }

        private static void CheckTrainer(List<Trainer> trainers, string command)
        {
            foreach (Trainer item in trainers)
            {
                if (item.Pokemons.Any(p => p.Element == command))
                {
                    item.NumberOfBadges++;
                }
                else
                {
                    foreach (Pokemon pokemon in item.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }
                }
            }

            foreach (Trainer trainer in trainers)
            {
                for (int i = 0; i < trainer.Pokemons.Count; i++)
                {
                    if (trainer.Pokemons[i].Health <= 0)
                    {
                        trainer.Pokemons.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }

}

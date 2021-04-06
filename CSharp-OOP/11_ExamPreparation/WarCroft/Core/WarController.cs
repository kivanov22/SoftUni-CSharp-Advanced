using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private List<Item> itemPool;
        public WarController()
        {
            party = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            var characterType = args[0];
            var name = args[1];

            if (characterType != "Priest" && characterType != "Warrior")
            {
                throw new ArgumentException($"Invalid character type {characterType}!");
            }

            Character character = null;

            if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            party.Add(character);

            return $"{name} joined the party!";

        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            if (itemName != "FirePotion" && itemName != "HealthPotion")
            {
                throw new ArgumentException($"Invalid item {itemName}!");
            }

            Item item = null;

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }

            itemPool.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            if (!party.Any(n => n.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Character character = party.FirstOrDefault(c => c.Name == characterName);
            Item lastItem = itemPool[itemPool.Count - 1];

            character.Bag.AddItem(lastItem);
            itemPool.RemoveAt(itemPool.Count - 1);

            return $"{character.Name} picked up {lastItem.GetType().Name}!";//characterName
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            if (!party.Any(c => c.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            var character = party.FirstOrDefault(n => n.Name == characterName);
            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{characterName} used {item.GetType().Name}.";

        }

        public string GetStats()
        {
            var orderedParty = party.OrderByDescending(d => d.IsAlive).ThenByDescending(d => d.Health);

            StringBuilder sb = new StringBuilder();

            foreach (var character in orderedParty)
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var atackerName = args[0];
            var receiverName = args[1];

            if (!party.Any(p => p.Name == atackerName))
            {
                throw new ArgumentException($"Character {atackerName} not found!");
            }

            if (!party.Any(p => p.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var atacker = party.FirstOrDefault(a => a.Name == atackerName);
            var receiver = party.FirstOrDefault(r => r.Name == receiverName);

            if (atacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{atackerName} cannot attack!");
            }
            Warrior warrior = (Warrior)atacker;

            warrior.Attack(receiver);

            var sb = new StringBuilder();

            sb.AppendLine($"{atackerName} attacks {receiverName} for {atacker.AbilityPoints} hit points!" +
                $" {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.Health == 0)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            if (!party.Any(p => p.Name == healerName))
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            if (!party.Any(p => p.Name == healingReceiverName))
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            var healer = party.FirstOrDefault(h => h.Name == healerName);
            var receiver = party.FirstOrDefault(r => r.Name == healingReceiverName);

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            Priest priest = (Priest)healer;

            priest.Heal(receiver);

           
            return ($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            
        }
    }
}

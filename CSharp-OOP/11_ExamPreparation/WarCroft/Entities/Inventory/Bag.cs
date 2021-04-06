using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private List<Item> items;
        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }
        public int Capacity//maybe fix
        {
            get => this.capacity;
            set
            {
                this.capacity = value;
            }
        }

        public int Load => items.Select(i => i.Weight).Sum();//maybe fix

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (Load+item.Weight>Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!items.Any(i => i.GetType().Name == name)) //maybe fix
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            var item = items.FirstOrDefault(i => i.GetType().Name == name);

            items.Remove(item);

            return item;
        }
    }
}

﻿using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities.Messages;
using System;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        protected Drink(string name, int portion, decimal price,string brand)
        {
            Name = name;
            Portion = portion;
            Price = price;
            Brand = brand;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                this.name = value;
            }
        }

        public int Portion
        {
            get { return this.portion; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }
                this.portion = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.price = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBrand);
                }
                this.brand = value;
            }
        }

        public override string ToString()
        {
            return $"{name} {brand} - {portion}ml - {price:f2}lv";
        }
    }
}

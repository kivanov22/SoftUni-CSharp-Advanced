using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
       
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)//mayybe public
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }
        public int TableNumber { get; private set; }
        

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }


        public bool IsReserved { get; private set; }


        public decimal Price => foodOrders.Select(f => f.Price).Sum()
                             + drinkOrders.Select(d => d.Price).Sum()
                             + this.NumberOfPeople * this.PricePerPerson;





        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;

        }

        public decimal GetBill()
        {
            //decimal totalSum = foodOrders.Sum(f => f.Price) + drinkOrders.Sum(d => d.Price) + Price;

            return this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Table: {TableNumber}");
            result.AppendLine($"Type: {GetType().Name}");
            result.AppendLine($"Capacity: {Capacity}");
            result.AppendLine($"Price per Person: {PricePerPerson}");
            return result.ToString().TrimEnd();

        }

        public void OrderDrink(IDrink drink)
        {
            if (IsReserved == true)
            {
                drinkOrders.Add(drink);
            }
        }

        public void OrderFood(IBakedFood food)//TODO Maybe reserved check
        {
            if (IsReserved == true)
            {
                foodOrders.Add(food);
            }
        }

        public void Reserve(int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException("Cannot place zero or less people!");
            }
            IsReserved = true;

            NumberOfPeople = numberOfPeople;


        }
    }
}

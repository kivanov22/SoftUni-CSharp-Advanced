using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)//mayybe public
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
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }


        public bool IsReserved { get; private set; }


        //public decimal Price => foodOrders.Select(f => f.Price).Sum()
        //                     + drinkOrders.Select(d => d.Price).Sum()
        //                     + this.NumberOfPeople * this.PricePerPerson;
        public decimal Price
        {
            get; set;
        }




        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            //decimal totalSum = foodOrders.Sum(f => f.Price) + drinkOrders.Sum(d => d.Price) + Price;
            decimal bill = 0;

            foreach (var food in foodOrders)
            {
                bill += food.Price;
            }

            foreach (var drink in drinkOrders)
            {
                bill += drink.Price;
            }

            // bill += Price;

            return bill;
            // return this.Price;
        }

        public string GetFreeTableInfo()
        {
            //StringBuilder result = new StringBuilder();

            //result.AppendLine($"Table: {TableNumber}");
            //result.AppendLine($"Type: {GetType().Name}");
            //result.AppendLine($"Capacity: {Capacity}");
            //result.AppendLine($"Price per Person: {PricePerPerson}");
            //return result.ToString().TrimEnd();

            return $"Table: {TableNumber}\r\n" +
           $"Type: {this.GetType().Name}\r\n" +
           $"Capacity: {Capacity}\r\n" +
           $"Price per Person: {PricePerPerson}";

        }

        public void OrderDrink(IDrink drink)
        {

           this.drinkOrders.Add(drink);

        }

        public void OrderFood(IBakedFood food)//TODO Maybe reserved check
        {

            this.foodOrders.Add(food);

        }

        public void Reserve(int numberOfPeople)
        {

            IsReserved = true;

            NumberOfPeople = numberOfPeople;


        }
    }
}

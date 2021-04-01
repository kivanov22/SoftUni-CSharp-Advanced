using Bakery.Core.Contracts;
using Bakery.Models;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> restaurantFoodOffer;
        private readonly ICollection<IDrink> restaurantDrinkOffer;
        private readonly ICollection<ITable> restaurantTables;
        private decimal restaurantTotalIncome;
        public Controller()
        {
            this.restaurantFoodOffer = new List<IBakedFood>();
            this.restaurantDrinkOffer = new List<IDrink>();
            this.restaurantTables = new List<ITable>();
            this.restaurantTotalIncome = 0;
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion,brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion,brand);
            }
            restaurantDrinkOffer.Add(drink);

            return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type=="Bread")
            {
                food = new Bread(name, price);
            }
            else if (type=="Cake")
            {
                food = new Cake(name, price);
            }
            restaurantFoodOffer.Add(food);

            return $"Added {food.Name} ({food.GetType().Name}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            restaurantTables.Add(table);

            return $"Added table number {table.TableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            var sortedTables = restaurantTables.Where(t => t.IsReserved == false).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in sortedTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {restaurantTotalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = restaurantTables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                throw new ArgumentException(OutputMessages.WrongTableNumber);

            }

            var totalTableSum = table.GetBill();

            this.restaurantTotalIncome += totalTableSum;

            table.Clear();

            var sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {totalTableSum:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = restaurantTables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = restaurantDrinkOffer.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                throw new ArgumentException(OutputMessages.WrongTableNumber);
            }

            if (drink == null)
            {
               return $"There is no {drinkName} {drinkBrand} available";
                //throw new ArgumentException(OutputMessages.NonExistentDrink);
            }

            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = restaurantTables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = restaurantFoodOffer.FirstOrDefault(d => d.Name == foodName);

            if (table == null)
            {
                throw new ArgumentException(OutputMessages.WrongTableNumber);
            }

            if (food == null)
            {
                throw new ArgumentException(OutputMessages.NonExistentFood);
            }

            table.OrderFood(food);

            return $"Table {table.TableNumber} ordered {food.Name}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = restaurantTables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                throw new ArgumentException(OutputMessages.ReservationNotPossible);
            }
            else
            {
                table.Reserve(numberOfPeople);

                return $"Table {table.TableNumber} has been reserved for {table.NumberOfPeople} people";
            }

        }
    }
}

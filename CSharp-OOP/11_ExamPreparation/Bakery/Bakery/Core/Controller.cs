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
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal restaurantTotalIncome = 0;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            //IDrink drink = null;

            if (type == "Tea")
            {
                //drink = new Tea(name, portion,brand);
                this.drinks.Add(new Tea(name, portion, brand));
            }
           if (type == "Water")
            {
                //drink = new Water(name, portion,brand);
                this.drinks.Add(new Water(name, portion, brand));
            }
            //drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink menu";
            //var message = string.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);

            //return message;
        }

        public string AddFood(string type, string name, decimal price)
        {
            

            if (type == "Bread")
            {
                this.bakedFoods.Add(new Bread(name, price));
                
            }
            if (type == "Cake")
            {
                this.bakedFoods.Add(new Cake(name, price));
              
            }
           

            return $"Added {name} ({type}) to the menu";
           
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
           

            if (type == "InsideTable")
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
                
            }
            if (type == "OutsideTable")
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
               
            }
           

            return $"Added table number {tableNumber} in the bakery";
            
        }

        public string GetFreeTablesInfo()//maybe fix
        {
            var sortedTables = tables.Where(t => t.IsReserved == false).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in sortedTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();

            //string result = "";
            //List<ITable> freeTables = tables.Where(table => !table.IsReserved).ToList();

            //for (int i = 0; i < freeTables.Count; i++)
            //{
            //    if (i != freeTables.Count - 1)
            //    {
            //        result += freeTables[i].GetFreeTableInfo() + Environment.NewLine;
            //    }
            //    else
            //    {
            //        result += freeTables[i].GetFreeTableInfo();
            //    }
            //}
            //foreach (var freeTable in freeTables)
            //{
            //    result += freeTable.GetFreeTableInfo() + Environment.NewLine;
            //}

            //return result;

        }

        public string GetTotalIncome()
        {
            // return string.Format(OutputMessages.TotalIncome, restaurantTotalIncome);
            return $"Total income: {restaurantTotalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            

            var bill = table.GetBill() + table.Price;

            this.restaurantTotalIncome += bill;

            table.Clear();

            //var sb = new StringBuilder();
            //sb.AppendLine($"Table: {tableNumber}");
            //sb.AppendLine($"Bill: {totalTableSum:f2}");

            //return sb.ToString().TrimEnd();
            return $"Table: {tableNumber}\r\n" +
                        $"Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);


            if (table == null)
            {
                //return string.Format(OutputMessages.WrongTableNumber, tableNumber);
                return $"Could not find table {tableNumber}";
            }
            else
            {

                IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

                if (drink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";

                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }





        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);


            if (table == null)
            {
                return $"Could not find table {tableNumber}";

            }
            else
            {
                IBakedFood food = bakedFoods.FirstOrDefault(d => d.Name == foodName);
                if (food == null)
                {
                    return $"No {foodName} in the menu";

                }
                else
                {
                    table.OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                    //return string.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, food.Name);

                }
            }



        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";

            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";

            }

        }
    }
}

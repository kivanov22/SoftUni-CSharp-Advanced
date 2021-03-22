using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IPerson, IBirthable, Identifiable
    {
        public Citizen(string name,int age , string birthdate,string id)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
            ID = id;
            
        }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Birthdate { get; private set; }
        public string ID { get; private set; }
        public int Food { get; private set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}

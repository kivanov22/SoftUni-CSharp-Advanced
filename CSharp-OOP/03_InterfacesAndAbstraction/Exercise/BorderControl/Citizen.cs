using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IPerson,Identifiable,IBirthable
    {
        public Citizen(string name, int age , string id,string birthdate)
        {
            Name = name;
            Age = age;
            ID = id;
            Birthdate = birthdate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        
        public string ID { get; set; }
        public string Birthdate { get; set; }
    }
}

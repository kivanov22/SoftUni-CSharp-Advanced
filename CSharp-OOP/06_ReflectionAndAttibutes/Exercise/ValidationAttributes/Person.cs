using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
   public class Person
    {
        private const int minAge = 12;
        private const int maxAge = 90;

        public Person(string name , int age)
        {
            this.Name = name;
            this.Age = age;
        }
        [MyRequired]
        public string Name { get;private set; }

        [MyRange(minAge,maxAge)]//if add false for inclusive age has to be above 12 to give true
        public int Age { get;private set; }
    }
}

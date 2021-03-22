using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthable = new List<IBirthable>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line=="End")
                {
                    break;
                }
                
                string[] parts = line.Split();

                if (parts[0]=="Citizen")
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthdate = parts[4];
                    //string[] end = birthdate.Split("/");
                    //string year = end[2];
                    birthable.Add(new Citizen(name, age, id,birthdate));
                }
                else if (parts[0]=="Robot")
                {
                    continue;
                    //string model = parts[0];
                    //string id = parts[1];
                    
                }
                else if (parts[0]=="Pet")
                {
                    string name = parts[1];
                    string birthdate = parts[2];
                    //string[] end = birthdate.Split("/");
                    //string year = end[2];
                    birthable.Add(new Pet(name, birthdate));
                }
            }
            string detained = Console.ReadLine();
            var filtered = birthable.Where(x => x.Birthdate.EndsWith(detained)).ToList();

            foreach (var item in filtered)
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}

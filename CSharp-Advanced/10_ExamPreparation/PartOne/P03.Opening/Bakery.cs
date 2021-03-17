using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
   public class Bakery
    {
        private List<Employee> data;
        public Bakery(string name,int capacity)
        {
            this.data = new List<Employee>();
            this.Name = name;
            this.Capacity = capacity;
        }
       
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }
        public void Add(Employee employee)
        {
            
            if (data.Count<Capacity)
            {
                data.Add(employee);
            }
            
        }
        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(c => c.Name == name);
            if (employee==null)
            {
                return false;
            }
            data.Remove(employee);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(p => p.Age).FirstOrDefault();
        }
        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(p => p.Name == name);
            return employee;
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var item in data)
            {
                result.AppendLine($"{item}");
            }
            return result.ToString();
        }

    }
}

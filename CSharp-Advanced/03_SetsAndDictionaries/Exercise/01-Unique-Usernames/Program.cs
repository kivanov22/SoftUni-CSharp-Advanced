using System;
using System.Collections.Generic;

namespace _01_Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> record = new HashSet<string>();


            for (int i = 0; i < n; i++)
            {
                string names = Console.ReadLine();


                record.Add(names);
            }

            foreach (var name in record)
            {
                Console.WriteLine(name);
            }
        }
    }
}

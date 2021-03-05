using System;
using System.Collections.Generic;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> compound = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                for (int j = 0; j < tokens.Length; j++)
                {
                    string current = tokens[j];
                    if (!compound.Contains(current))
                    {
                        compound.Add(current);
                    }
                }
            }
            foreach (var item in compound)
            {
                Console.Write(item + " ");
            }
        }
    }
}

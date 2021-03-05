using System;
using System.Collections.Generic;

namespace _05.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

           // char[] sort = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (!symbols.ContainsKey(current))
                {
                    symbols.Add(current, 1);

                }
                else
                {
                    symbols[current]++;
                }
            }

            foreach (var item in symbols)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}

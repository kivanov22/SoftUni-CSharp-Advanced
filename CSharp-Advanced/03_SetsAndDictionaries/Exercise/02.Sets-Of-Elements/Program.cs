using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();


            int n = elements[0];
            int m = elements[1];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                firstSet.Add(num);

            }

            for (int i = 0; i < m; i++)
            {
                int num2 = int.Parse(Console.ReadLine());

                secondSet.Add(num2);
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}

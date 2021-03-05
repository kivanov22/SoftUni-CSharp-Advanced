using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> evenNumbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!evenNumbers.ContainsKey(num))
                {
                    evenNumbers.Add(num, 1);//or we can set num,0 default and remove else and leave it only evenNumbers[num]++
                }
                else
                {
                    evenNumbers[num]++;
                }

            }

           Dictionary<int,int> sortedEven= evenNumbers.Where(x => x.Value % 2 == 0).ToDictionary(k=>k.Key,v=>v.Value); //find even Numbers


            foreach (var item in sortedEven)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}

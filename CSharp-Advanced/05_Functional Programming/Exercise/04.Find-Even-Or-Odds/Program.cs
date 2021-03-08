using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Find_Even_Or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int start = numbers[0];
            int end = numbers[1];
            string criteria = Console.ReadLine();

            Func<int, int, List<int>> generateRange = (s, e) =>
              {
                  List<int> nums = new List<int>();

                  for (int i = s; i <= e; i++)
                  {
                      nums.Add(i);
                  }
                  return nums;
              };
            List<int> num = generateRange(start, end);

            Predicate<int> predicate = n => true;

            if (criteria=="odd")
            {
                predicate = n => n % 2 != 0;
            }
            else if (criteria=="even")
            {
                predicate = n => n % 2 == 0;
            }
            //numbers.Where(n => n % 2 == 0);
            Console.WriteLine(string.Join(" ",MyWhere(num,predicate)));
            
        }

        static List<int>MyWhere(List<int>numbers, Predicate<int> predicate)
        {
            List<int> newNumbers = new List<int>();
            foreach  (int currNum in numbers)
            {
                if (predicate(currNum))
                {
                    newNumbers.Add(currNum);
                }
            }
            return newNumbers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Count_Same_Values_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> checkNumbers = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!checkNumbers.ContainsKey(numbers[i]))
                {
                    checkNumbers.Add(numbers[i], 0);
                }
                checkNumbers[numbers[i]]++;
            }

            foreach (var time in checkNumbers)
            {
                Console.WriteLine($"{time.Key} - {time.Value} times");
            }
        }
    }
}

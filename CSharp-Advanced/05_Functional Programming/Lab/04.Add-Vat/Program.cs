using System;
using System.Linq;

namespace _04.Add_Vat
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine().Split(", ")
                .Select(Decimal.Parse)
                .Select(numbers => numbers +(numbers* 0.2m))
                .ToArray();

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}

using System;
using System.Linq;

namespace _01.Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(",")
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(p => p)
                .ToArray();

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}

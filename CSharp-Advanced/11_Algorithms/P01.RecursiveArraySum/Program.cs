using System;
using System.Linq;

namespace P01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            long sum = Sum(numbers,startIndex:0);

            Console.WriteLine(sum);
        }
        public static long Sum(int[] arr ,int startIndex)
        {
            if (startIndex==arr.Length-1)
            {
                //last element
                //arr->{4}
               return arr[startIndex];
            }
            return arr[startIndex] + Sum(arr, startIndex: startIndex + 1);
        }
    }
}

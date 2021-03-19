using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int key = int.Parse(Console.ReadLine());

            int binary = BinarySearch(numbers, key);

            Console.WriteLine(string.Join(" ",binary));

        }

        public static int BinarySearch(int[] arr , int key)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (right>=left)
            {
                int mid = (left + right) / 2;
                    //left + (right - left) / 2;

                if (key > arr[mid])
                {
                    left = mid + 1;
                }
                else if (key<arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}

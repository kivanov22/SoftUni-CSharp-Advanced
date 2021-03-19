using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = Partition(args, left, right);
            Sort(a,left,right)
        }
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort<T>(T[] a, int left, int right) where T : IComparable<T>
        {
            if (left>=right)
            {
                return;
            }
        }

    }
}

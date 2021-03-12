using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //List<string> boxes = new List<string>(); valid soltion

            List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {

                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            SwapIndex(boxes, indexes[0], indexes[1]);

            foreach (Box<int> box in boxes)
            {
                Console.WriteLine(box);
            }

        }

        private static void SwapIndex<T>(List<Box<T>>boxes,int firstIndex,int secondIndex)
        {
            Box<T> temp = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }

    }
}

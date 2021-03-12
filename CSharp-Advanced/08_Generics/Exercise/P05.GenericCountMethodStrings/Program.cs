﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.GenericCountMethodStrings
{
   public class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>(); //valid soltion

            //  List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {

                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.Add(box);
            }
            double value = double.Parse(Console.ReadLine());
            Box<double> comparableBox = new Box<double>(value);
            int count = GetGreaterThanCount(boxes, comparableBox);
            Console.WriteLine(count);
        }
        private static int GetGreaterThanCount<T>(List<Box<T>> boxes, Box<T> box)
            where T: IComparable
        {
            int count = 0;

            foreach (Box<T> item in boxes)
            {
                if (item.Value.CompareTo(box.Value)>0)
                {
                    count++;
                }
            }
            return count;
        }

        //private static void SwapIndex<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        //{
        //    Box<T> temp = boxes[firstIndex];
        //    boxes[firstIndex] = boxes[secondIndex];
        //    boxes[secondIndex] = temp;
        //}

    }
}


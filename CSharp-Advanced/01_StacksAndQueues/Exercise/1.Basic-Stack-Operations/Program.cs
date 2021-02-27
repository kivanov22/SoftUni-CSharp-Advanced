using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = elements[0];
            int s = elements[1];
            int x = elements[2];

            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int j = 0; j < s; j++)
            {
                stack.Pop();
            }
            bool isFound = stack.Contains(x);

          
            if(isFound)
            {
                Console.WriteLine("true");
            }
            else if(!stack.Any())
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}

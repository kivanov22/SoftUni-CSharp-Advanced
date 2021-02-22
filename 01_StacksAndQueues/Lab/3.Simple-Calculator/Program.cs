using System;
using System.Collections.Generic;

namespace _3.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            while (stack.Count>1)
            {
                int leftNum = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int rightNum = int.Parse(stack.Pop());

                if (sign =="+")
                {
                    stack.Push((leftNum + rightNum).ToString());
                }
                else if (sign=="-")
                {
                    stack.Push((leftNum - rightNum).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}

using System;
using System.Collections.Generic;

namespace _1.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reversedString = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reversedString.Push(input[i]);
            }

            while (reversedString.Count>0)
            {
                Console.Write(reversedString.Pop());
            }
            Console.WriteLine();
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace CustomStack
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            
           // Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new List<string>()
            {
                "Goshe",
                "TOni",
                "Martin",
                "Kukaracha"
            });

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

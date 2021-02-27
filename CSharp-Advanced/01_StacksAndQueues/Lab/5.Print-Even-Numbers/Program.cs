using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> evenNumbers = new Queue<int>(numbers);


            
                for (int i = 0; i < evenNumbers.Count; i++)
                {
                int currentNumber = evenNumbers[i];

                    if (evenNumbers.Peek() % 2!=0)
                    {
                        evenNumbers.Dequeue();
                    }
                    else
                    {
                        evenNumbers.Enqueue(evenNumbers.Dequeue());
                    }
                }
            

            //foreach (var num in numbers)
            //{
            //    if (num%2==0)
            //    {
            //        evenNumbers.Enqueue(num);
            //    }
            //    else
            //    {

            //    }
            //}
           Console.Write(string.Join(", ",evenNumbers));
        }
    }
}

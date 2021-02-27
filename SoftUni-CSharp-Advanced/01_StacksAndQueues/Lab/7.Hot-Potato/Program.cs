using System;
using System.Collections.Generic;

namespace _7.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> potatoQue = new Queue<string>(children);

            int potatoTosses = 0;
            while (potatoQue.Count>1)
            {
                potatoTosses++;
                string kid = potatoQue.Dequeue();//remove kid 

                if (potatoTosses==n)
                {
                    potatoTosses = 0;//we set toss to 0 
                    Console.WriteLine("Removed " + kid);
                }
                else
                {
                    potatoQue.Enqueue(kid);//add kid to first
                }
            }
            Console.WriteLine("Last is " + potatoQue.Dequeue());
        }
    }
}

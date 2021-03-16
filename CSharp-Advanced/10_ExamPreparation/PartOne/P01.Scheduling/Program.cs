using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int killTask = int.Parse(Console.ReadLine());

            while (true)
            {
                int currentThread = threads.Peek();
                int currentTask = tasks.Peek();

                if (killTask == currentTask)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                    break;
                }
                if (currentThread>=currentTask)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else//if (currentThread<currentTask)
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ",threads));
        }
    }
}

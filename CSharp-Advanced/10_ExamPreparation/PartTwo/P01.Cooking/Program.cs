using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> rosses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int sum = 0;
            int wreaths = 0;
            int stored = 0;
            while (lilies.Count > 0 && rosses.Count > 0)
            {
                int currentLily = lilies.Peek();
                int currentRose = rosses.Peek();

                if (lilies.Count == 0 || rosses.Count == 0)
                {
                    break;
                }
                sum = currentLily + currentRose;
                if (wreaths == 5)
                {
                    break;
                }
                if (sum == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    rosses.Dequeue();
                }
                if (sum > 15)
                {
                    currentLily -= 2;
                    lilies.Pop();
                    lilies.Push(currentLily);
                }
                if (sum < 15)
                {
                    stored += sum;
                    lilies.Pop();
                    rosses.Dequeue();
                }

            }
            wreaths += stored / 15;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}

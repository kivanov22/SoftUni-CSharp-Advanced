using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(",").Select(int.Parse).ToArray());

            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(",").Select(int.Parse).ToArray());

            int sum = 0;
            int wreath = 0;
            int flowers = 0;
            while (lilies.Count>0 && roses.Count>0)
            {
                int currentLily = lilies.Pop();
                int currentRoses = roses.Dequeue();

                sum = currentLily + currentRoses;

                if (sum==15)
                {
                    wreath++;
                }
                else if (sum >15)
                {
                    currentLily -= 2;
                    wreath++;
                }
                else if (sum<15)
                {
                    flowers += sum;//we save the excess

                }
            }
            wreath += flowers / 15;

            if (wreath>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreath} wreaths more!");
            }
        }
    }
}

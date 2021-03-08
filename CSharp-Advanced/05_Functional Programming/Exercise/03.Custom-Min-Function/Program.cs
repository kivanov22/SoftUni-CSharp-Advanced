using System;
using System.Linq;

namespace _03.Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minNumber = numbers =>
            {
                int minNum = int.MaxValue;

                foreach (var num in numbers)
                {
                    if (num<minNum)
                    {
                        minNum = num;
                    }
                }

                return minNum;
            };
            

            int number = numbers.Min();
            Console.WriteLine(number);
           
        }
        
    }
}

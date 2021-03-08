using System;
using System.Linq;

namespace _02.Knights_Of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> print = x => Console.WriteLine("Sir " + x);

            names.ToList().ForEach(x => print(x));
        }
    }
}

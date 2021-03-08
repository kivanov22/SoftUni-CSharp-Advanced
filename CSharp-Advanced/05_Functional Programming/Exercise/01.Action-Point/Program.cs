using System;
using System.Linq;

namespace _01.Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> print = x => Console.WriteLine(x);

            names.ToList().ForEach(x => print(x));
        }


    }
}

using System;

namespace GenericArrayCreator
{
   public class Program
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "pesho");
            Console.WriteLine(string.Join(" ",strings));
        }
    }
}

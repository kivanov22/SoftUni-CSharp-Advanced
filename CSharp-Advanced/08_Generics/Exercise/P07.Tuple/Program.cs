using System;

namespace P07.Tuple
{
   public class Program
    {
        static void Main(string[] args)
        {
            string[] firstTupleData = Console.ReadLine().Split(" ");
            string fullName = $"{firstTupleData[0]} {firstTupleData[1]}";
            CustomTuple<string, string> firstTuple = new CustomTuple<string,string>(fullName, firstTupleData[2]);

            string[] secondTupleData = Console.ReadLine().Split(" ");
            CustomTuple<string, int> secondTuple = new CustomTuple<string, int>(secondTupleData[0], int.Parse(secondTupleData[1]));

            string[] thirdTupleData = Console.ReadLine().Split(" ");
            CustomTuple<int, double> thirdTuple = new CustomTuple<int, double>(int.Parse(thirdTupleData[0]), double.Parse(thirdTupleData[1]));

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}

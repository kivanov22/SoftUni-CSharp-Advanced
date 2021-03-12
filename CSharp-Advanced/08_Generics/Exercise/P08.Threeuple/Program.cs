using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.Threeuple
{
   public class Program
    {
        static void Main(string[] args)
        {
            //Adam Smith Wallstreet New York
            string[] firstTupleData = Console.ReadLine().Split(" ");
            string fullName = $"{firstTupleData[0]} {firstTupleData[1]}";
            List<string> townRowData = firstTupleData.ToList().Skip(3).ToList();//so we can take New York, not only New
            string town = string.Join(" ", townRowData);

            Threeuple<string, string, string> firstThreeuoke = new Threeuple<string, string, string>(fullName, firstTupleData[2],town);

            string[] secondTupleData = Console.ReadLine().Split(" ");
            bool drunk = secondTupleData[2] == "drunk" ? true : false;


            Threeuple<string, int, bool> secondThreeuoke = new Threeuple<string, int, bool>(secondTupleData[0],int.Parse(secondTupleData[1])
                , drunk);

            string[] thirdTupleData = Console.ReadLine().Split(" ");
            Threeuple<string, double, string> thirdThreeuoke = new Threeuple<string, double, string>(thirdTupleData[0], double.Parse(thirdTupleData[1])
                , thirdTupleData[2]);


            Console.WriteLine(firstThreeuoke);
            Console.WriteLine(secondThreeuoke);
            Console.WriteLine(thirdThreeuoke);
        }
    }
}

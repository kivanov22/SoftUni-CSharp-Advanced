using System;
using System.Linq;

namespace _12.Tri_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetCharactersSum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split();

            Func<string, int, bool> isValidWord = (str, num) => str.ToCharArray()
               .Select(ch => (int)ch).Sum() >= num;


            //   names[]   targetCharacter Func <name ,sum,yes or no> theName that matches
            Func<string[], int, Func<string, int, bool>, string> firstValidName = (arr, num, func) => arr
                 .FirstOrDefault(str => func(str, num));

            var result = firstValidName(names, targetCharactersSum, isValidWord);
            Console.WriteLine(result);
        }
    }
}

using System;
using System.Linq;

namespace _10.Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                var splitted = command.Split().ToList();
                var predicate = GetPredicate(splitted[1], splitted[2]);

                switch (splitted[0])
                {

                    case "Remove":
                        names.RemoveAll(predicate);
                        break;
                    case "Double":
                        var matches = names.FindAll(predicate);
                        if (matches.Count>0)
                        {
                            var index = names.FindIndex(predicate);
                            names.InsertRange(index, matches);
                        }
                        break;
                }

                command = Console.ReadLine();
            }
            if (names.Count!=0)
            {
                Console.WriteLine(string.Join(", ",names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        private static Predicate<string> GetPredicate(string commandType, string arg)
        {
            switch (commandType)
            {
                case "StartsWith":
                    return (name) => name.StartsWith(arg);
                case "EndsWith":
                    return (name) => name.EndsWith(arg);
                case "Length":
                    return (name) => name.Length==int.Parse(arg);
                default:
                    throw new ArgumentException("Invalid command type: " + commandType);
            }
        }
    }
}

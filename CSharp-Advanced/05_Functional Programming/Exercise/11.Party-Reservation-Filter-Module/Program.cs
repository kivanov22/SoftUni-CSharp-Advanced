using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var filterNames = new List<string>();

            string commmand = Console.ReadLine();

            while (commmand != "Print")
            {
                var tokens = commmand.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
                
                switch (tokens[0])
                {
                    case "Add filter":
                        filterNames.Add($"{tokens[1]};{tokens[2]}");

                        break;
                    case "Remove filter":
                        // names.RemoveAll(predicate);
                        // names.Remove(tokens[1] + " " + tokens[2]);
                        if (filterNames.Contains($"{tokens[1]};{tokens[2]}"))
                        {
                            filterNames.Remove($"{tokens[1]};{tokens[2]}");
                        }

                        break;
                }

                commmand = Console.ReadLine();
            }
            Func<string, int, bool> lengthFilter = (name, length)

                => name.Length == length;

            Func<string, string, bool> startsFilter = (name, letter)

                => name.StartsWith(letter);

            Func<string, string, bool> endsFilter = (name, letter)

                => name.EndsWith(letter);

            Func<string, string, bool> containsFilter = (name, letter)

                => name.Contains(letter);



            foreach (var currentFilter in filterNames)

            {

                string[] currentFilterInfo = currentFilter

                    .Split(";", StringSplitOptions.RemoveEmptyEntries);



                string action = currentFilterInfo[0];

                string parameter = currentFilterInfo[1];



                if (action == "Starts with")

                {

                    names = names

                        .Where(name => !startsFilter(name, parameter))

                        .ToArray();

                }

                else if (action == "Ends with")

                {

                    names = names

                        .Where(name => !endsFilter(name, parameter))

                        .ToArray();

                }

                else if (action == "Length")

                {

                    names = names

                        .Where(name => !lengthFilter(name, int.Parse(parameter)))

                        .ToArray();

                }

                else if (action == "Contains")

                {

                    names = names

                        .Where(name => !containsFilter(name, parameter))

                        .ToArray();

                }



            }

            if (filterNames.Count != 0)
            {
                Console.WriteLine(string.Join(" ", names));
            }
        }



    }
}
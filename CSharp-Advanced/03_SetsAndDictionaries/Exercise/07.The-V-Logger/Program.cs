using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> application = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] cmdArgs = input.Split(" ");
                string vloggerName = cmdArgs[0];
                string command = cmdArgs[1];

                if (command == "joined")
                {
                    if (!application.ContainsKey(vloggerName))
                    {
                        application.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        application[vloggerName].Add("following", new SortedSet<string>());
                        application[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {

                    string vloggerTwoName = cmdArgs[2];

                    if (application.ContainsKey(vloggerName) && application.ContainsKey(vloggerTwoName) && vloggerName != vloggerTwoName)
                    {
                        application[vloggerName]["following"].Add(vloggerTwoName);
                        application[vloggerTwoName]["followers"].Add(vloggerName);
                    }
                }

                input = Console.ReadLine();
            }
            //sort by descending then by ascending 
            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedData =
              application.OrderByDescending(x => x.Value["followers"].Count)
              .ThenBy(x => x.Value["following"].Count)
              .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {application.Count} vloggers in its logs.");

            int counter = 0;
            foreach (KeyValuePair<string, Dictionary<string, SortedSet<string>>> item in sortedData)//instead of var
            {
                Console.WriteLine($"{++counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (string followers in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {followers}");
                    }


                }
            }
        }
    }
}

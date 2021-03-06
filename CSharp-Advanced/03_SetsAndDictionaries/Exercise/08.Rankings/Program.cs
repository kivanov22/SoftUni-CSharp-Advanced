using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Rankings
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
                   // contest  pass
            string input = Console.ReadLine();

            while (input!= "end of contests")
            {
                var splitted = input.Split(":");
                contests.Add(splitted[0], splitted[1]);

                

                input = Console.ReadLine();
            }


            string secondInput = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, int>> submissions = new SortedDictionary<string, Dictionary<string, int>>();
            //     username         contest   points

            while (secondInput != "end of submissions")
            {
                var splitted = secondInput.Split("=>");
                string contest = splitted[0];
                string pass = splitted[1];
                string username = splitted[2];
                int points = int.Parse(splitted[3]);

                if (contests.ContainsKey(contest) && contests.ContainsValue(pass))
                {

                    if (!submissions.ContainsKey(username))
                    {
                        submissions.Add(username, new Dictionary<string, int>());
                    }

                    if (!submissions[username].ContainsKey(contest))
                    {
                        submissions[username].Add(contest, points);
                    }
                    else
                    {
                        int oldPoints = submissions[username][contest];

                        if (points>oldPoints)
                        {
                            submissions[username][contest] = points;
                        }
                    }
                }
                else
                {
                    secondInput = Console.ReadLine();
                    continue;
                }




                secondInput = Console.ReadLine();
            }
            KeyValuePair<string, Dictionary<string, int>> bestCandidate = submissions.OrderByDescending(x => x.Value.Values.Sum()).First();
            //sorts them first Tanya then Nikola

            int totalPoints = bestCandidate.Value.Values.Sum();//finds the best candiate with most points

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in submissions)
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _07.Softuni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> vipRecord = new HashSet<string>();
            HashSet<string> regularRecord = new HashSet<string>();
            int countVips = 0;
            int countRegulars = 0;
            while (true)
            {
                if (input == "PARTY")
                {
                    while (true)
                    {
                        input = Console.ReadLine();

                        if (input == "END")
                        {
                            break;
                        }

                        if (vipRecord.Contains(input))
                        {
                            vipRecord.Remove(input);
                        }

                        if (regularRecord.Contains(input))
                        {
                            regularRecord.Remove(input);
                        }



                    }

                }
                if (input=="END")
                {
                    break;
                }
                for (int i = 0; i < input.Length; i++)
                {
                    char check = input[i];

                    if (char.IsDigit(check))
                    {
                        vipRecord.Add(input);
                        break;
                    }
                    else
                    {
                        regularRecord.Add(input);
                        break;
                    }
                }

                input = Console.ReadLine();
            }
            countVips = vipRecord.Count;
            countRegulars = regularRecord.Count;
            //sum both counters

            Console.WriteLine(countVips + countRegulars);
            foreach (var vip in vipRecord)
            {
                Console.WriteLine(vip);
            }
            foreach (var regular in regularRecord)
            {
                Console.WriteLine(regular);
            }
        }
    }
}

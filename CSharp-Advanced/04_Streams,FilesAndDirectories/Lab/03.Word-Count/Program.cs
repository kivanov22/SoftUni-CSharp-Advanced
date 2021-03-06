using System;
using System.Collections.Generic;
using System.IO;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWord = "";
            string secondWord = "";
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("words.txt"))
            {

                string row = reader.ReadLine();

                using (StreamReader reader2 = new StreamReader("text.txt"))
                {
                    string second = reader2.ReadLine();

                    using (StreamWriter writer = new StreamWriter("third.txt"))
                    {
                        while (reader !=null)
                        {
                            if (row==second)
                            {
                                wordsCount.Add(row, 1);
                            }

                            row = reader.ReadLine();
                        }
                        writer.Write(string.Join(" ", wordsCount));
                    }
                }

            }
        }
    }
}

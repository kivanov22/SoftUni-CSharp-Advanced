using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                int counter = 0;
                string pattern = @"[-,.!?]";



                while (line != null)
                {
                    string replaced = Regex.Replace(line, pattern, "@");
                    if (counter++ % 2 == 0)
                    {

                        string[] words = replaced.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                        Console.WriteLine(string.Join(" ", words.Reverse()));
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}

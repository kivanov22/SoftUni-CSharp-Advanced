using System;
using System.IO;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int countLetters = 0;
                int countMarks = 0;

                foreach (char c in line)
                {
                    if (char.IsLetter(c))
                    {
                        countLetters++;
                    }
                    else if (char.IsPunctuation(c))
                    {
                        countMarks++;
                    }
                }
                string newLine = $"Line{i+1}:{line}({countLetters})({countMarks})";
                Console.WriteLine(newLine);

                File.AppendAllText("output.txt", newLine + Environment.NewLine);
            }
        }
    }
}

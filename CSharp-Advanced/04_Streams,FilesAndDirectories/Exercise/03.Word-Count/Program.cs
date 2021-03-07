using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string expectedPath = Path.Combine("../../../expectedResult.txt");
            string[] words = File.ReadAllLines("words.txt");
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                wordCount.Add(word.ToLower(), 0);
            }


            string text = File.ReadAllText("text.txt").ToLower();

            string[] textWords = text.Split(new string[] { " ", ",", ".", "-", "!", "?", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in textWords)
            {
                if (wordCount.ContainsKey(item))
                {
                    wordCount[item]++;
                }
            }
            Dictionary<string, int> sortedWords = wordCount.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
            

            List<string> output = sortedWords.Select(kvp => $"{kvp.Key} - {kvp.Value}").ToList();

            File.WriteAllLines(expectedPath,output);
        }
    }
}

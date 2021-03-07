using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string dicretoryPath = Directory.GetCurrentDirectory();
            string[] filesNames = Directory.GetFiles(dicretoryPath);
            Dictionary<string, Dictionary<string, double>> filesData = new Dictionary<string, Dictionary<string, double>>();

            foreach (var fileFullName in filesNames)
            {
                FileInfo fileInfo = new FileInfo(fileFullName);
                string extenstion = fileInfo.Extension;
                long size = fileInfo.Length;
                double kbSize = Math.Round(size / 1024.0,3);

                if (!filesData.ContainsKey(extenstion))
                {
                    filesData.Add(extenstion, new Dictionary<string, double>());
                }
                
                    filesData[extenstion].Add(fileInfo.Name, kbSize);
                
            }
            Dictionary<string, Dictionary<string, double>> sortedDic = filesData.OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<string> res = new List<string>();

            foreach (var item in sortedDic)
            {
                res.Add(item.Key);

                foreach (var fileData in item.Value.OrderBy(kvp=>kvp.Value))
                {
                    res.Add($"--{fileData.Key} - {fileData.Value}kb");
                }
            }
          string filePath= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"output.txt");
            File.WriteAllLines(filePath, res);
        }
    }
}

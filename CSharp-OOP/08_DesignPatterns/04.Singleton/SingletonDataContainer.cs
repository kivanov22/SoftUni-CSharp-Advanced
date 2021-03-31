using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _04.Singleton
{
    public class SingletonDataContainer : ISingltonContainer
    {
        private static SingletonDataContainer instance = new SingletonDataContainer();
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();
        

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("capitals.txt");

            for (int i = 0; i < elements.Length; i++)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance => instance;
        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");

            
            Queue<string> playlist = new Queue<string>(songs);

            while (playlist.Any())
            {
                var commands = Console.ReadLine();
                
                if (commands=="Play")
                {
                    playlist.Dequeue();
                }
                else if (commands.StartsWith("Add"))
                {
                    var songName = commands.Substring(4);

                    if (!playlist.Contains(songName))
                    {
                        playlist.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else if (commands=="Show")
                {
                    Console.WriteLine(string.Join(", ",playlist));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}

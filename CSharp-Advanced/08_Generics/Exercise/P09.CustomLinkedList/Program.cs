﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MusicLinkedList<string> playList = new MusicLinkedList<string>();
            while (true)
            {
                Console.WriteLine("Add music to playlist src: ");
                string src = Console.ReadLine();
                if (src == "end")
                {
                    break;
                }

                playList.AddLast(new NodeMusic<string>(src));
            }
            playList.ForeachFromHead(s => Console.WriteLine(s.Value));















            playList.ForeachFromHead((node)=>
            {
                Console.WriteLine($"Now playing: {node.Value}");
                Thread.Sleep(1500);
            });


            return;


























            SoftuniLinkedListFastReverse list = new SoftuniLinkedListFastReverse();

            for (int i = 0; i < 10; i++)
            {
                list.AddLast(new Node(i + 1));
            }
            list.Reverse();
            list.Reverse();
            list.Reverse(); 
            list.Reverse();

            list.Foreach((node) =>
            {
                Console.WriteLine(node.Value);
            });

            SoftuniLinkedList linkedList = new SoftuniLinkedList();

            Console.WriteLine("Remove empty head: " + linkedList.RemoveHead());

            for (int i = 0; i < 3; i++)
            {
                linkedList.AddHead(new Node(i));
            }
            for (int i = 0; i < 3; i++)
            {
                linkedList.AddLast(new Node(i));
            }

            Console.WriteLine("Remove head: " + linkedList.RemoveHead().Value);

            Console.WriteLine("Remove Tail: " + linkedList.RemoveTail().Value);

            var currentNode = linkedList.Tail;


            Console.WriteLine("Foreach from head:");
            linkedList.ForeachFromHead((node) =>
            {
                Console.WriteLine($"From action: {node.Value}");
            });

            Console.WriteLine("Foreach from Tail:");
            linkedList.ForeachFromTail((node) =>
            {
                Console.WriteLine($"From action: {node.Value}");
            });

            int[] linkedListAsArray = linkedList.ToArray();
        }
    }
}

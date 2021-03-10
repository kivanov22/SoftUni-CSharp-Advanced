using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniLinkedList linkedList = new SoftUniLinkedList();

            Console.WriteLine("Remove empty head: " + linkedList.RemoveHead());

            for (int i = 0; i < 3; i++)
            {
                linkedList.AddHead(new Node(i));
            }
            for (int i = 0; i < 3; i++)
            {
                linkedList.AddTail(new Node(i));
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

            Console.WriteLine($"Return LinkedList to Array: {string.Join(" ",linkedListAsArray)}");
        }
    }
}

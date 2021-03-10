using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class SoftUniLinkedList
    {
        private int count =0;
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int[] ToArray()
        {
            int index = 0;
            int[] array = new int[count];

            ForeachFromHead((node) =>
            {
                array[index] = node.Value;
                index++;
            });

            return array;
        }
        public void ForeachFromTail(Action<Node> action)
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.PreviousNode;
            }
        }

        public void ForeachFromHead(Action<Node> action)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.NextNode;
            }
        }

        public void AddHead(Node node)
        {
            count++;

            if (Head==null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.NextNode = Head;
            Head.PreviousNode = node;
            Head = node;
        }

        public void AddTail(Node node)
        {
            count++;
            if (Tail==null)
            {
                Head = null;
                Tail = null;
                return;

            }
            node.PreviousNode = Tail;
            Tail.NextNode = node;
            Tail = node;
        }

        public Node RemoveHead()
        {
            if (Head==null)
            {
                return null;
            }
            count--;

            var nodeToReturn = Head;

            if (Head.NextNode!=null)
            {
                Head = Head.NextNode;
                Head.PreviousNode = null;
            }
            else
            {
                Head = null;
                Tail = null;

            }
            return nodeToReturn;
        }

        public Node RemoveTail()
        {
            if (Tail == null)
            {
                return null;
            }

            count--;
            var nodeToReturn = Tail;
            if (Tail.PreviousNode != null)
            {
                Tail = Tail.PreviousNode;
                Tail.NextNode = null;
            }
            else
            {
                Tail = null;
                Head = null;
            }

            return nodeToReturn;
        }
    }
}

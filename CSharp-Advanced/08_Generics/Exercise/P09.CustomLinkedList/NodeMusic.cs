namespace CustomDoublyLinkedList
{
    public class NodeMusic<T>
    {
        public NodeMusic(T src)
        {
            Value = src;
        }

        public T Value { get; set; }

        public NodeMusic<T> Next { get; set; }

        public NodeMusic<T> Previous { get; set; }
    }
}

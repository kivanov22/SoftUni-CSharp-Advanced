using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Custom_Data_Structures
{
    public class CustomStack
    {
        private int[] array;
        private const int InitialCapacity = 4;
        public CustomStack()
        {
            this.array = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            if (this.Count == this.array.Length)
            {
                this.Resize();
            }
            this.array[this.Count] = element;
            this.Count++;
        }
        public int Pop()
        {
            this.HasValues();

            int element = this.array[this.Count - 1];
            this.array[this.Count - 1] = default;
            this.Count--;

            if (this.Count == this.array.Length / 4)
            {
                this.Shrink();
            }
            return element;
        }

        

        public int Peek()
        {
            this.HasValues();
            return this.array[this.Count - 1];
        }

        public void ForEach(Action<int>action)
        {
            foreach (int item in this.array)
            {
                action(item);
            }
        }
        public void MySelect(Func<int, int> func)
        {
            for (int i = 0; i < this.Count; i++)
            {
                int element = this.array[i];
                int a = func(element);
                this.array[i] = a;
            }
        }
        private void HasValues()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
        private void Shrink()
        {
            int[] copy = new int[this.array.Length / 2];
            Array.Copy(this.array, copy, this.Count);
            this.array = copy;
        }

        private void Resize()
        {
            int[] copy = new int[this.array.Length * 2];
            Array.Copy(this.array, copy, this.Count);
            this.array = copy;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Custom_Data_Structures
{
    public class CustomList
    {

        private const int InitialCapacity = 2;
        private int[] array;

        public CustomList()
        {
            this.array = new int[InitialCapacity];//initialize the array


        }
        public int Count { get; private set; }//actual amount of numbers in the array
        public int this[int index]
        {
            get
            {
                if (index >= this.Count)//check if index is valid not out of range
                {
                    throw new ArgumentOutOfRangeException();//we give this error because we don't get the number, we never initiliaze it
                }
                return this.array[index];
            }
            set
            {
                if (index >= this.Count)//check if index is valid not out of range
                {
                    throw new ArgumentOutOfRangeException();//we give this error because we don't get the number, we never initiliaze it
                    //we try to set some number to this index , but we dont add it to the array
                }
                this.array[index] = value;
            }
        }

        public void Add(int number)
        {
            if (this.Count == this.array.Length)//
            {
                this.Resize();
            }

            this.array[this.Count] = number;//index 0 which is equal to Count 
            this.Count++;
        }
        public void Swap(int firstIndex,int secondIndex)
        {
            //if (firstIndex>=this.Count||secondIndex>=this.Count)
            //{

            //}
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            int firstNum = this.array[firstIndex];
            this.array[firstIndex] = array[secondIndex];
            this.array[secondIndex] = firstNum;

        }
        public int RemoveAt(int index)
        {
            this.ValidateIndex(index);
            int number = this.array[index];//when we take the number we must shift the elemenets in the array <--
            this.array[index] = default;//after we take it , we set its index to default
            this.Shift(index);
            this.Count--;

            if (this.Count == this.array.Length / 4)
            {
                this.Shrink();
            }
            return number;
        }

        public void Insert(int index, int number)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid Index!");
            }

            if (this.Count == this.array.Length)
            {
                this.Resize();
            }

            this.ShiftRight(index);
            this.array[index] = number;
            this.Count++;

        }

        public bool Contains(int number)//check if element is in the array
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i] == number)
                {
                    return true;
                }

            }
            return false;
        }

        
        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.array.Length / 2];
            Array.Copy(this.array, copy, this.Count);

            this.array = copy;//refference from above we save it here
        }

        private void Shift(int index)
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid Index!");
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.array.Length * 2];//we take the old array and make a bigger one 

            for (int i = 0; i < this.array.Length; i++)
            {
                copy[i] = this.array[i];//we take the values from old array to the new
            }
            this.array = copy;//we set the new array to be used
        }


    }
}

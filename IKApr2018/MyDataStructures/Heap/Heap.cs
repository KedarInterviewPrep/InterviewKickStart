using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Heap
{
    public class Heap
    {
        int MAX_SIZE;
        int[] arr;
        int size;

        public Heap(int size)
        {
            MAX_SIZE = size;
            arr = new int[size];
            this.size = 0;
        }

        public int GetMin()
        {
            if (size == 0)
                throw new Exception("Heap is Empty.");
            return arr[0];
        }

        private int GetParent(int i)
        {
            if (i != 0)
                return (i - 1) / 2;
            return -1;
        }

        private int GetLeftChild(int i)
        {
            int index = 2 * i + 1;
            if (index >= size)
            {
                return -1;
            }

            return index;
        }

        private int GetRightChild(int i)
        {
            int index = 2 * i + 2;
            if (index >= size)
            {
                return -1;
            }

            return index;
        }

        public void InsertElement(int value)
        {
            if (size == MAX_SIZE)
                throw new Exception("Heap is Full.");

            arr[size++] = value;
            int i = size - 1;
            while (i != 0 && arr[i] < arr[GetParent(i)])
            {
                swap(arr, i, GetParent(i));
                i = GetParent(i);
            }
        }

        public int DeleteMin()
        {
            if (size == 0)
                throw new Exception("Heap is Empty!");

            int index = 0;
            int minValue = arr[index];
            arr[index] = arr[size - 1];

            while(true)
            {
                int left = GetLeftChild(index) ;
                int right = GetRightChild(index);
                int minIndex = index;

                if(left != -1 && arr[left] < arr[minIndex])
                {
                    minIndex = left;
                }

                if(right != -1 && arr[right] < arr[minIndex])
                {
                    minIndex = right;
                }

                if(minIndex == index) // element reached its right position.
                {
                    size--;
                    return minValue;
                }
                else
                {
                    swap(arr, minIndex, index);
                    index = minIndex;
                }
            }
        }

        private void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public void PrintHeap()
        {
            for(int i = 0; i< this.size; i++)
            {
                Console.Write(this.arr[i] + ", ");
            }

            Console.WriteLine();
        }
    }
}

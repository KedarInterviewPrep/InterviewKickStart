using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataStructures.Heap;

namespace HeapTest
{
    public static class HeapProb
    {
        public static void TestHeap()
        {
            Heap myheap = new Heap(10);
            myheap.InsertElement(10);
            myheap.InsertElement(5);
            myheap.InsertElement(15);
            myheap.InsertElement(7);
            myheap.InsertElement(2);
            myheap.PrintHeap();

            Console.WriteLine(myheap.DeleteMin());
            myheap.PrintHeap();

            Console.WriteLine(myheap.DeleteMin());
            myheap.PrintHeap();

            myheap.InsertElement(12);
            myheap.PrintHeap();

            Console.WriteLine(myheap.DeleteMin());
            myheap.PrintHeap();

            Console.WriteLine(myheap.DeleteMin());
            myheap.PrintHeap();

            Console.WriteLine(myheap.DeleteMin());
            myheap.PrintHeap();
        }
    }
}

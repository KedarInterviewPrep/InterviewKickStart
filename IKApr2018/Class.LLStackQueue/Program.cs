using System;
using Class.LLStackQueue;
using System.Collections.Generic;
using System.Linq;
/*
 * Make sure you are handling all the different cases! And do not forget to actually add or remove element from the map.
 * When practising you did the pointer manipulation for doubly linked list, but forgot to update the actual Map/Cache! :).
 * */

using System.Text;
using System.Threading.Tasks;

namespace Class.LLStackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            // LRUCacheTest();
            // MinStackTest();
            MinStackPersonTest();

            Console.ReadKey();
        }

        private static void MinStackPersonTest()
        {
            var minStack = new MinStack<MyPerson>(5);
            var per1 = new MyPerson()
            {
                Name = "Bob",
                Age = 53
            };

            var per2 = new MyPerson()
            {
                Name = "Alice",
                Age = 32
            };

            var per3 = new MyPerson()
            {
                Name = "Tim",
                Age = 25
            };

            var per4 = new MyPerson()
            {
                Name = "Jack",
                Age = 21
            };

            minStack.Push(per1);
            minStack.PrintStack();

            minStack.Push(per3);
            minStack.PrintStack();

            minStack.Push(per2);
            minStack.PrintStack();

            minStack.Push(per4);
            minStack.PrintStack();

            minStack.Pop();
            minStack.PrintStack();

            minStack.Pop();
            minStack.PrintStack();

            minStack.Pop();
            minStack.PrintStack();
        }

        private static void MinStackTest()
        {
            var minStack = new MinStack<int>(20);
            minStack.Push(1);
            minStack.PrintStack();

            minStack.Push(20);
            minStack.Push(30);
            minStack.Push(40);
            minStack.PrintStack();

            minStack.Push(4);
            minStack.PrintStack();

            minStack.Push(1);
            minStack.PrintStack();

            minStack.Pop();
            minStack.PrintStack();

            minStack.Pop();
            minStack.PrintStack();

            minStack.Pop();
            minStack.PrintStack();

            minStack.Pop();
            minStack.PrintStack();
        }

        private static void LRUCacheTest()
        {
            LRUCache<int> cache = new LRUCache<int>(3);

            cache.PrintCache();
            cache.AddElement("num1", 10);
            cache.AddElement("num2", 20);
            cache.PrintCache();

            cache.DeleteElement("num1");
            cache.PrintCache();
            cache.AddElement("num3", 30);
            cache.AddElement("num4", 40);
            cache.AddElement("num5", 50);

            cache.PrintCache();
            cache.DeleteElement("num2");
            cache.PrintCache();

            cache.DeleteElement("num5");
            cache.PrintCache();

            cache.AddElement("num6", 60);
            cache.PrintCache();

            cache.AddElement("num7", 70);
            cache.PrintCache();

            cache.DeleteElement("num4");
            cache.PrintCache();
        }
    }
}

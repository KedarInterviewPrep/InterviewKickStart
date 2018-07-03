using System;
using System.Collections.Generic;
using System.Linq;
/*
 * Make sure you are handling all the different cases! And do not forget to actually add or remove element from the map.
 * When practising you did the pointer manipulation for doubly linked list, but forgot to update the actual Map/Cache! :).
 * */

using System.Text;
using System.Threading.Tasks;

namespace LinkListStackQueue
{
    class Program
    {
        static void Main(string[] args)
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


            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataStructures;
using LLStackQueue.ReverseLinkList;

namespace LLStackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2};

            var list = MyLinkList<int>.GetLinkList(input);
            MyLinkList<int>.PrintLinkList(list);
            list = ReverseLinkList<int>.ReverseLinkListMethod(list);
            MyLinkList<int>.PrintLinkList(list);

            Console.WriteLine("\r\nHit Enter...");
            Console.ReadKey();
        }
    }
}

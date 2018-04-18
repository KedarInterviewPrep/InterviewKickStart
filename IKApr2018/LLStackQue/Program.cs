using System;
using MyDataStructures;
using System.Linq;

namespace LLStackQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            // *** Problem: Zip a Link List
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var list = MyLinkList<int>.GetLinkList(input);
            MyLinkList<int>.PrintLinkList(list);
            var zipList = ZipLinkList.ZipLinkListAttempt1.zip_given_linked_list(list);
            MyLinkList<int>.PrintLinkList(zipList);

            // *** Problem: LRU Cache.
            //int capacity = 2;
            //int[] query_type = new int[] { 1, 1, 0, 1, 0, 1, 0 };
            //int[] key = new int[] { 5, 10, 5, 15, 10, 5, 5 };
            //int[] value = new int[] {11, 22, 1, 33, 1, 55, 1};


            //var result = LRUCache.LRUCacheAttempt1.implement_LRU_cache(capacity, query_type, key, value);
            //result.ToList().ForEach(x => Console.Write(x + ", "));

            // *** Problem: Reverse a LinkList is group of K
            //int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8};
            //var list = MyLinkList<int>.GetLinkList(input);
            //MyLinkList<int>.PrintLinkList(list);
            //var revList = ReverseInGroupK.RecursiveAttempt.reverse_linked_list_in_groups_of_k(list, 10);
            //MyLinkList<int>.PrintLinkList(revList);

            // *** Problem: MaxInSlidingWindow
            //int[] input = new int[] {6, 0, -6 };
            //var result = MaxInSlidingWindow.OwnAttemptUsingDeque.max_in_sliding_window(input, 1);
            //result.ToList().ForEach(x => Console.Write(x + ", "));



            Console.ReadKey();
        }
    }
}

/*
 * Implemented in 1st attempt, based on the discussion in the class.
 * Idea here is for fast look-up we have a dictionary which maintains the cache.
 * To maintain the order in which elements are accessed or time of access so that we can apply LRU policy,
 * we use a doubly linked-list. The recently accessed element is moved/inserted at the last of the list - 
 * so the first element in the list represents least recenty used element.
  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLStackQueue.LRUCache
{
    public static class LRUCacheAttempt1
    {
        public static int[] implement_LRU_cache(int capacity, int[] query_type, int[] key, int[] value)
        {
            // Hashset for O(1) look-up. key--> node in lruCache
            Dictionary<int, LinkedListNode<int>> lruCache = new Dictionary<int, LinkedListNode<int>>(capacity);

            // lruCache node which contains index as value, so we can retrieve data.
            LinkedList<int> orderedList = new LinkedList<int>();

            var result = new List<int>();

            for(int i = 0; i < query_type.Length; i++)
            {
                if(query_type[i] == 1) // SET operation.
                {
                    if(lruCache.ContainsKey(key[i])) // key already present in the cache.
                    {
                        // get reference for existing node and remove it (??)
                        var node = lruCache[key[i]];
                        orderedList.Remove(node);

                        // Update the time by adding it at the end.
                        node.Value = i; // update the index/value.
                        orderedList.AddLast(node);
                        // lruCache[key[i]] = newNode;
                    }
                    else // new key to insert.
                    {
                        if (orderedList.Count < capacity) // cache not full, so simply insert at the end.
                        {
                            var node = orderedList.AddLast(i);
                            lruCache[key[i]] =  node;
                        }
                        else // cache full, so remove first element and insert new element at the end.
                        {
                            lruCache.Remove(key[orderedList.First.Value]);
                            orderedList.RemoveFirst();
                            lruCache[key[i]] = orderedList.AddLast(i);
                        }
                    }
                }
                else if(query_type[i] == 0) // GET operation.
                {
                    if(lruCache.ContainsKey(key[i])) // Element present in cache.
                    {
                        var node = lruCache[key[i]];
                        result.Add(value[node.Value]);

                        // update the time-stamp of the cache. Push it last.
                        orderedList.Remove(node);

                        // Update the time by adding it at the end.
                        orderedList.AddLast(node);
                        //lruCache[key[i]] = newNode;
                    }
                    else
                    {
                        result.Add(-1);
                    }
                }
            }

            return result.ToArray();
        }
    }
}

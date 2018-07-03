using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Sorting.LinkListStackQueue
{
    public class LRUCache<T>
    {
        private Dictionary<string, LRUNode<T>> Map;
        private int CurrentSize, MaxSize;
        private LRUNode<T> Head;
        private LRUNode<T> Tail;

        public LRUCache(int maxSize)
        {
            MaxSize = maxSize;
            Head = null;
            Tail = null;
            CurrentSize = 0;
            Map = new Dictionary<string, LRUNode<T>>();
        }

        public T GetElement(string Key)
        {
            if (Map.ContainsKey(Key) == false)
            {
                return default(T); // Key is not present.
            }

            var node = Map[Key];
            if (Head == node) // the node is the recent node, so no changes.
            {
                // no pointer re-arrangements required.
            }
            else if (Tail == node) // last node in Doubly LL.
            {
                Tail = node.Previous;
                Tail.Next = null;

                node.Previous = null;
                node.Next = Head;

                Head = node;
            }
            else
            {
                // Intermediate node.
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;

                node.Next = Head;
                node.Previous = null;
                Head.Previous = node;

                Head = node;
            }

            return node.Value;
        }

        public void AddElement(string Key, T value)
        {
            // New element
            if (Map.ContainsKey(Key) == false)
            {
                var node = new LRUNode<T>(Key, value);
                if (CurrentSize < MaxSize)
                {
                    Map.Add(Key, node);

                    node.Next = Head;
                    node.Previous = null;

                    Head.Previous = node;

                    Head = node;

                    CurrentSize++;
                }
                else // new element and the cache is full. So we will have to evict the cache.
                {
                    Tail = Tail.Previous;

                    Tail.Next.Previous = null;
                    Tail.Next = null;

                    Tail.Next = null;
                }
            }
            else // Key already exists in the cache, so we need to update.
            {
                var node = Map[Key];
                node.Value = value; // update the value.

                if (Head == node) // the node is the recent node, so no changes.
                {
                    // no pointer re-arrangements required.
                }
                else if (Tail == node) // last node in Doubly LL.
                {
                    Tail = node.Previous;
                    Tail.Next = null;

                    node.Previous = null;
                    node.Next = Head;

                    Head = node;
                }
                else
                {
                    // Intermediate node.
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;

                    node.Next = Head;
                    node.Previous = null;
                    Head.Previous = node;

                    Head = node;
                }
            }
        }

        public void DeleteElement(string Key)
        {
            if (Map.ContainsKey(Key) == false) return; // no key exists to delete.

            var node = Map[Key];
            CurrentSize--;

            if (node == Head) // head node.
            {
                Head = node.Next;
                node.Next = null;
                node.Previous = null; // ideally not required as it should already be null.

                Head.Previous = null;
            }
            else if (node == Tail) // last node.
            {
                Tail = node.Previous;
                node.Previous = null;
                node.Next = null;
                Tail.Next = null;
            }
            else // intermediate node.
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;

                node.Previous = null;
                node.Next = null;
            }
        }

        public int Count()
        {
            return CurrentSize;
        }

        public void Clear()
        {
            this.Map = new Dictionary<string, LRUNode<T>>();
            Head = null;
            Tail = null;
            CurrentSize = 0;
        }
    }

    internal class LRUNode<T>
    {
        public T Value { get; set; }
        private string Key { get; set; }
        public LRUNode<T> Next { get; set; }
        public LRUNode<T> Previous { get; set; }

        public LRUNode(string Key, T value)
        {
            this.Key = Key;
            this.Value = value;
        }
    }
}

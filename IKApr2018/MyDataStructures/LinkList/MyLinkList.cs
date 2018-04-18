using System;
using MyDataStructures.LinkList;

namespace MyDataStructures
{
    public class MyLinkList<T>
    {
        public static Node<T> GetLinkList(T[] input)
        {
            if(input == null || input.Length == 0)
            {
                return null;
            }

            Node<T> head = new Node<T>(input[0]);
            Node<T> ptr = head;

            for (int i = 1; i < input.Length; i++)
            {
                ptr.Next = new Node<T>(input[i]);
                ptr = ptr.Next;
            }

            return head;
        }

        public static void PrintLinkList(Node<T> head)
        {
            while (head != null)
            {
                Console.Write($"{head.Value} --> ");
                head = head.Next;
            }

            Console.WriteLine("NULL");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataStructures.LinkList;


namespace LLStackQueue.ReverseLinkList
{
    public static class ReverseLinkList<T>
    {
        public static Node<T> ReverseLinkListMethod(Node<T> head)
        {

            Node<T> prev = null;
            Node<T> curr = head;
            Node<T> next = null;

            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }
    }


    public class Node
    {

    }
}

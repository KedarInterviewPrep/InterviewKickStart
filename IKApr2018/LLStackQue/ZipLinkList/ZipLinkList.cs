using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataStructures.LinkList;

namespace LLStackQueue.ZipLinkList
{
    public static class ZipLinkListAttempt1
    {
        public static Node<int> zip_given_linked_list(Node<int> head)
        {
            if(head == null || head.Next == null)
            {
                return null;
            }

            int size = GetSize(head);
            Node<int> firstHalf = head;
            Node<int> secondHalf = null;
            Node<int> prev = null;

            for(int i = 0; i < (size + 1)/2; i++)
            {
                prev = head;
                head = head.Next;
            }
            prev.Next = null; // Terminate the first LL.

            secondHalf = ReverseLinkList(head);
            var newHead = firstHalf;
            Node<int> fhNext = null;
            Node<int> shNext = null;

            while (firstHalf != null && secondHalf != null)
            {
                fhNext = firstHalf.Next;
                shNext = secondHalf.Next;

                firstHalf.Next = secondHalf;
                secondHalf.Next = fhNext;

                firstHalf = fhNext;
                secondHalf = shNext;
            }

            return newHead;
        }

        private static Node<int> ReverseLinkList(Node<int> head)
        {
            Node<int> prev = null;
            Node<int> curr = head;
            Node<int> next = null;

            while(curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

        private static int GetSize(Node<int> head)
        {
            int count = 0;
            while(head != null)
            {
                head = head.Next;
                count++;
            }

            return count;
        }
    }
}

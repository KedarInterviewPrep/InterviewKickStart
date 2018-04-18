/*
 *  I attempted it with recursive approach and all the tests passed.
 *  Also looked only and the solution is on the same line. So looks good!
 *  Online - https://www.geeksforgeeks.org/reverse-a-list-in-groups-of-given-size/
 */
using MyDataStructures.LinkList;

namespace LLStackQueue.ReverseInGroupK
{
    public class RecursiveAttempt
    {
        public static Node<int> reverse_linked_list_in_groups_of_k(Node<int> head, int k)
        {
            return ReverseLinkList(head, k);
        }

        static Node<int> ReverseLinkList(Node<int> origHead, int count)
        {
            if(origHead == null)
            {
                return origHead;
            }

            int k = 0;
            Node<int> prev = null;
            Node<int> curr = origHead;
            Node<int> next = null;

            while (k < count && curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
                k++;
            }

            Node<int> newHead = prev;
            origHead.Next = ReverseLinkList(curr, count);
            return prev;
        }
    }
}

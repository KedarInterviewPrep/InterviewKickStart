/*
 * I intially came up with a solution of creating another link list of the same link list but reversing it and then start traversing the two list
 * till N/2. But this needs extra space. 
 * With some hints from online, I realized the below approach where you don't have to take that extra space and can simply reverse within the same linklist (last N/2 part is reversed).
 * 
 */
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
            prev.Next = null; // NOTE: Terminate the first half LL, otherwise it results into infinite execution due to loop within the linklist.

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

/* // ************* COMMENTS *************
 *  This an attempt using Deque. I was not able to come up with this optimized approach, so I read the approach and coding it.
 *  We don't often come across problems where we need to use Double ended-queue, so this is interesting. Also the approach is very 
 *  intuitive.
 *  Explanation of approach in own words.
 *  (1) Since we need to find the element which is maximum in a window of size W, at any given instance we are only interested in elements
 *  that are part of the window. So at index i, I only care for elements (i-W+1)
 *  (2) So we use double ended queue (Deque) to store indices of the elements that "potentially" could be largest in a window. 
 *  (3) To achieve this, at any given index 'i', we discard the elements from the queue with value/indices (i-W+1) - this can be achieved by 
 *  deleting the elements from the front which are less that (i+W-1). We delete from front, because that's the order in which we inserted the elements.
 *  (4) Also, if the element a[i] is larger than the element at the end of the queue (recently inserted) - then we can discard such elements too,
 *  of, as it is smaller than a[i] and since a[i] is later than this elementas that element cannot be largest in this or subsequent window.
 *  
 *  Note - As compare to maintaining two index, this approach is better because - 
 *  1. It is more intuitive once you understand it well :)
 *  2. Space complexity is better as it is only O(W) -> Lenght of the queue, which at max will contain W elements at any given time.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLStackQueue.MaxInSlidingWindow
{
    public class OwnAttemptUsingDeque
    {
        public static int[] max_in_sliding_window(int[] arr, int w)
        {
            // For C# there is no implementation of double ended queue.
            // So we use double link-list here, which *may* not be ideal option. 
            // **TODO** Read about how double ended queue is implemented in Java and
            // what are some efficient ways to implement it in C#.
            LinkedList<int> deque = new LinkedList<int>();
            int[] result = new int[arr.Length - w + 1];
            int rIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                // Keep only i-w+1 relevant element for the window.
                if (deque.Count != 0 && deque.First.Value < i - w + 1)
                {
                    deque.RemoveFirst();
                }

                while(deque.Count != 0 && arr[deque.Last.Value] < arr[i])
                {
                    deque.RemoveLast();
                }
                deque.AddLast(i);

                if(i>= w - 1)
                {
                    result[rIndex++] = arr[deque.First.Value];
                }
            }

            return result;
        }
    }
}

// // Problem - https://leetcode.com/problems/sliding-window-maximum/description/
/* // ************* COMMENTS *************
 * This was something I was not able to solve on my own completely (apart from Brute force of course which takes O(w.n)  where w is the size of
 * sliding window.
 * I read the approach and coded on my own - this is not the efficient space efficient solution as we need two extra arrays - time complexity is O(n),
 * which is OK.
 * The best solution for this makes use of Double ended queue.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLStackQueue.MaxInSlidingWindow
{
    public static class OwnAttempt
    {
        // This attempt makes use of two arrays - not the optimal solution from space complexity wise as it needs extra two arrays
        // But time complexity is O(n).
        public static int[] max_in_sliding_window(int[] arr, int w)
        {
            int[] max_left = new int[arr.Length];
            int[] max_right = new int[arr.Length];
            int[] result = new int[arr.Length - w + 1];

            int leftMax = int.MinValue;
            int rightMax = int.MinValue;

            for (int i = 0, j = arr.Length - 1; i < arr.Length; i++, j--)
            {
                // max_left processing.
                if (arr[i] > leftMax)
                {
                    leftMax = arr[i];
                }
                max_left[i] = leftMax;

                // Opps: You made a mistake inside if condition by not putting () around i + 1, which resulted in the evaluation of i + 1 % w incorrect.
                // Keep in mind the operator precendence.
                if ((i + 1) % w == 0) // Window boundary.
                {
                    leftMax = int.MinValue;
                }

                if (arr[j] > rightMax)
                {
                    rightMax = arr[j];
                }
                max_right[j] = rightMax;

                if (j % w == 0)
                {
                    rightMax = int.MinValue;
                }
            }

            int k = 0;
            for (; k + w - 1 < arr.Length; k++)
            {
                result[k] = max_left[k + w - 1] > max_right[k] ? max_left[k + w - 1] : max_right[k];
            }

            //while(k < arr.Length)
            //{
            //    result[k] = max_left[k] > max_right[k] ? max_left[k] : max_right[k];
            //    k++;
            //}

            return result;
        }
    }
}

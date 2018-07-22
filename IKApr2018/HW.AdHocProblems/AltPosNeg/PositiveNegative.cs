using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.AdHocProblems
{
    class PositiveNegative
    {
        
        public static int[] alternating_positives_and_negatives(int[] numbers)
        {
            /*
             * Write your code here.
             */

            int[] result = new int[numbers.Length];
            int p1 = 0;
            int p2 = 0;
            int index = 0;

            while (index < numbers.Length)
            {
                p1 = GetNextPositiveIndex(p1, numbers);
                if (p1 != -1)
                {
                    result[index++] = numbers[p1];
                    p1++;
                }

                p2 = GetNextNegativeIndex(p2, numbers);
                if (p2 != -1)
                {
                    result[index++] = numbers[p2];
                    p2++;
                }

                if (p1 == -1 && p2 == -1 && index != numbers.Length)
                    throw new Exception("Invalid Input.");
            }

            return result;
        }

        private static int GetNextPositiveIndex(int start, int[] numbers)
        {
            int pointer = start;
            while (pointer != - 1 && pointer < numbers.Length)
            {
                if (numbers[pointer] >= 0)
                    return pointer;
                pointer++;
            }

            return -1;
        }

        private static int GetNextNegativeIndex(int start, int[] numbers)
        {
            int pointer = start;
            while (pointer != -1 && pointer < numbers.Length)
            {
                if (numbers[pointer] < 0)
                    return pointer;
                pointer++;
            }

            return -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.OddEven
{
    public static class OddEven
    {
        public static int[] solve(int[] arr)
        {
            int evenPtr = 0;
            int oddPtr = arr.Length - 1;

            while(evenPtr < oddPtr)
            {
                while(evenPtr < arr.Length && arr[evenPtr] % 2 == 0)
                {
                    evenPtr++;
                }

                while(oddPtr > 0 && arr[oddPtr] % 2 == 1)
                {
                    oddPtr--;
                }

                if(evenPtr < oddPtr)
                    swap(evenPtr, oddPtr, arr);
            }

            return arr;
        }

        private static void swap(int i, int j, int[] arr)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}

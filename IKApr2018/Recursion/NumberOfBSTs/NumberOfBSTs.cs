using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion.NumberOfBSTs
{
    public class NumberOfBSTs
    {
        static Dictionary<int, long> cache = new Dictionary<int, long>();

        public static long how_many_BSTs(int n)
        {
            if (cache.ContainsKey(n))
                return cache[n];
            if (n == 0 || n == 1)
            {
                cache.Add(n, 1);
                return 1;
            }            

            long count = 0;
            for(int i = n-1; i >= 0; i--)
            {
                long leftCnt = how_many_BSTs(i);
                long rightCnt = how_many_BSTs(n - 1 - i);
                count += leftCnt * rightCnt;
            }

            cache.Add(n, count);
            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.FindZeroSum
{
    public static class FindZeroSumClass
    {
        static string[] findZeroSum(int[] arr)
        {
            var result = new HashSet<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == 0)
                        {
                            var temp = new List<int> { arr[i], arr[j], arr[k] };
                            temp.Sort();
                            var str = string.Join(",", temp);
                            if(result.Contains(str) == false)
                            {
                                result.Add(str);
                            }
                        }
                    }
                }
            }

            var ret = result.ToList() ;
            ret.Sort();
            return ret.ToArray();
        }

        public static void FindZeroSum()
        {
            var input = new int[] { 10, 3, -4, 1, -6, 9 };
            var result = findZeroSum(input);
            foreach(var r in result)
            {
                Console.WriteLine(r);
            }
        }
    }
}

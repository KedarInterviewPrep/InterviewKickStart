using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion.GenerateAllSubsets
{
    public static class GenerateAllSubsets
    {
        public static string[] generate_all_subsets(string s)
        {
            if(s == null)
            {
                s = string.Empty;
            }
            var result = new HashSet<string>();
            genrateAllSubsetRec(s, ref result);
            var resultLst = result.ToList();
            resultLst.Insert(0, result.Count.ToString());
            return resultLst.ToArray();
        }

        private static void genrateAllSubsetRec(string s, ref HashSet<string> result)
        {
            if(result.Contains(s))
            {
                return;
            }

            result.Add(s);
            for(int i = 0; i < s.Length; i++)
            {
                genrateAllSubsetRec(s.Remove(i, 1), ref result);
            }
        }
    }
}

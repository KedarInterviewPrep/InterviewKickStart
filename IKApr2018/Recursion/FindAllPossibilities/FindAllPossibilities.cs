/*
Input: 10?
Output: 101, 100 
i.e. ? behaves like a wild-card. There are two possibilities for 10?, when that ? is replaced with either 0 or 1. 
Input: 1?0?
Output: 1000, 1001, 1100, 1101 

Please write a program that takes given strings as input and produces the suggested output.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion.FindAllPossibilities
{
    public static class FindAllPossibilities
    {
        static string[] find_all_possibilities(string s)
        {
            /*
             * Write your code here.
             */
            List<string> output = new List<string>();
            findAllPossibilities(s, 0, ref output);
            return output.ToArray();
        }

        static void findAllPossibilities(string str, int pos, ref List<string> result)
        {
            while (pos < str.Length && str[pos] != '?')
                pos++;
            if(pos < str.Length) // we found '?'
            {
                findAllPossibilities(str.Insert(pos, "0"), pos + 1, ref result);
                findAllPossibilities(str.Insert(pos, "1"), pos + 1, ref result);
            }
            else // string exhausted. So add to result.
            {
                result.Add(str);
            }
        }
    }
}

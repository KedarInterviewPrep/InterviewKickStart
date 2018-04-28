/*
 * I was able to come up with the approach in first attempt. Idea here is -
 * State is the current set of substring (with added '|' demarkation for different string) 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion.PalindromicDecomposition
{
    public static class PalindromicDecompositioncs
    {
        public static string[] generate_palindromic_decompositions(string s)
        {
            var result = new HashSet<string>();
            var antiResult = new HashSet<string>();
            palindromicDecomposition(s, ref result, ref antiResult);
            var resultLst = result.ToList();
            resultLst.Insert(0, $"{result.Count} different palindromic decompositions possible.");
            return resultLst.ToArray();
        }

        static void palindromicDecomposition(string s, ref HashSet<string> result, ref HashSet<string> antiResult)
        {
            if (s == null)
                return;

            if (result.Contains(s) == true || antiResult.Contains(s) == true)
            {
                return;
            }

            if (checkIfPalidromicDecomposition(s) == true)
                result.Add(s);
            else
                antiResult.Add(s);

            int i = 0;
            while(i < s.Length - 1)
            {
                if(s[i+1] != '|')
                {
                    palindromicDecomposition(s.Insert(i + 1, "|"), ref result, ref antiResult);
                    i++;
                }
                else
                {
                    i = i + 2;
                }
            }
        }

        private static bool checkIfPalidromicDecomposition(string s)
        {
            var candidateSet = s.Split('|');
            foreach(var str in candidateSet)
            {
                bool isPalindrom = checkIfPalindrome(str, 0, str.Length -1);
                if (isPalindrom == false)
                    return false;
            }

            return true;
        }

        private static bool checkIfPalindrome(string s, int start, int end)
        {
            if (s == null) return false;
            if(start >= end)
            {
                return true;
            }

            return s[start] == s[end] && checkIfPalindrome(s, start + 1, end - 1);
        }
    }
}

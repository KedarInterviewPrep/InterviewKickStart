using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherProjects.Recursion.CombinationOfPhoneNumber
{
    public class CombinationOfPhoneNumber
    {
        readonly Dictionary<char, string> digitToAlphaMap = new Dictionary<char, string>();

        
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();
            if (string.IsNullOrWhiteSpace(digits))
            {
                return result;
            }

            digitToAlphaMap.Add('2', "abc");
            digitToAlphaMap.Add('3', "def");
            digitToAlphaMap.Add('4', "ghi");
            digitToAlphaMap.Add('5', "jkl");
            digitToAlphaMap.Add('6', "mno");
            digitToAlphaMap.Add('7', "pqrs");
            digitToAlphaMap.Add('8', "tuv");
            digitToAlphaMap.Add('9', "wxyz");

            
            var sb = new StringBuilder();
            GetCombination(digits, 0, ref sb, ref result);

            return result;
        }

        void GetCombination(string digits, int pos, ref StringBuilder sb, ref IList<string> result)
        {
            if(pos >= digits.Length) // string complete.
            {
                result.Add(sb.ToString());
                return;
            }

            var digit = digits[pos];
            string alphaSet;
            if (digitToAlphaMap.TryGetValue(digit, out alphaSet) == false)
            {
                GetCombination(digits, pos + 1, ref sb, ref result);
                return;
            }

            for (int i = 0; i < alphaSet.Length; i++)
            {
                int currLen = sb.Length;
                sb.Append(alphaSet[i]);
                GetCombination(digits, pos + 1, ref sb, ref result);
                sb.Remove(currLen, 1);
            }
        }
    }
}

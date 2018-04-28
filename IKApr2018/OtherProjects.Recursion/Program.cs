using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherProjects.Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new OtherProjects.Recursion.CombinationOfPhoneNumber.CombinationOfPhoneNumber();
            string digits = "23";
            var result = runner.LetterCombinations(digits);
            Console.WriteLine("Total: " + result.Count);
            foreach(var str in result)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("Hit Enter...");
            Console.ReadKey();
        }
    }
}

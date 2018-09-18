using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.AdHocProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] num = new int[] { 2, 3, -4, -9, -1, -7, 1, 5, 6};
            int[] num = new int[] { 1};

            var result = PositiveNegative.alternating_positives_and_negatives(num);
            foreach (var ele in result)
                Console.Write(ele + ", ");

            Console.WriteLine();
            Console.WriteLine("Completed...");
            Console.ReadKey();
        }
    }
}

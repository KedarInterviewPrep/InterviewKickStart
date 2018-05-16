using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //Shortest path grid.
            string[] input = new string[] { "+B...", "####.", "##b#.", "a...A", "##@##" };
            var result = ShortestPathGrid.find_shortest_path(input);

            //// String Transformation
            //var words = new string[] { "cccw", "accc", "accw" };
            //var result = StringTransformation.string_transformation(words, "cccc", "cccc");

            // Knights Tour
            //var result = KingtsTour.find_minimum_number_of_moves(5, 5, 0, 0, 4, 1);
            //Console.WriteLine(result);

            // Find Order.
            //var input = new string[] { "baa", "abcd", "abca", "cab", "cad" };
            //var result = FindOrderAlienDictionary.find_order(input);
            //Console.WriteLine(result);
        }
    }
}

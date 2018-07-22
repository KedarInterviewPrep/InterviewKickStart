using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoDimArray();
            //AsciiAndUnicode();
            //Dictionary<int, Vertex<int, string>> vertices = new Dictionary<int, Vertex<int,string>>();
            //string str = "kedar";
            //var c = str[0];
            //List<int>[] myList = new List<int>[10];
            //myList[0] = new List<int>();
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static void TwoDimArray()
        {
            char ch = 'a';
            ch++;
            Console.WriteLine(ch);
            int[,] twoDArray = new int[2,3];
            int[][] jaggedArray = new int[3][];

            var t = twoDArray.Length;
            Queue<Tuple<int, int, int>> q = new Queue<Tuple<int, int, int>>();
            q.Enqueue(new Tuple<int, int, int>(1, 2, 3));
        }

        private static void AsciiAndUnicode()
        {
            using (var file = new StreamWriter("Out.txt", true, Encoding.UTF8))
            {
                for (char ch = char.MinValue; ch < char.MaxValue; ch++)
                {
                    file.WriteLine((int)ch + " : " + ch);
                    if (ch % 500 == 0)
                        Console.WriteLine((int)ch + " done.");
                }
            }
        }
    }

    class Vertex<T1, T2>
    {
        public T1 Id;
        public T2 Data;
        public List<Vertex<T1, T2>> Adjacency;
    }
}

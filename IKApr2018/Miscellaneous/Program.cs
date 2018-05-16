using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Vertex<int, string>> vertices = new Dictionary<int, Vertex<int,string>>();
            string str = "kedar";
            var c = str[0];
            List<int>[] myList = new List<int>[10];
            myList[0] = new List<int>();
        }
    }

    class Vertex<T1, T2>
    {
        public T1 Id;
        public T2 Data;
        public List<Vertex<T1, T2>> Adjacency;
    }
}

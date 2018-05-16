using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public static class FindOrderAlienDictionary
    {
        public static string find_order(string[] words)
        {
            Dictionary<char, List<char>> vertices = ConstructGraph(words);
            List<char> topoOrder = GetTopoSort(vertices);

            if (topoOrder == null)
                return string.Empty;

            var result = string.Join("", topoOrder);
            return result;
        }

        private static List<char> GetTopoSort(Dictionary<char, List<char>> vertices)
        {
            List<char> topoSort = new List<char>();
            Dictionary<char, int> indegree = GetIndegrees(vertices);
            Queue<char> q = new Queue<char>();

            // Initialize queue.
            foreach (var node in indegree)
            {
                if (node.Value == 0)
                {
                    q.Enqueue(node.Key);
                }
            }

            while (q.Count != 0)
            {
                var cur = q.Dequeue();
                topoSort.Add(cur);
                foreach (var next in vertices[cur])
                {
                    indegree[next]--;
                    if (indegree[next] == 0)
                    {
                        q.Enqueue(next);
                    }
                }
            }

            if (topoSort.Count != vertices.Count)
            {
                return null;
            }

            return topoSort;
        }

        // Get the indegree numbers for each vertex.
        private static Dictionary<char, int> GetIndegrees(Dictionary<char, List<char>> vertices)
        {
            var indegrees = new Dictionary<char, int>();
            foreach (var node in vertices)
            {
                indegrees.Add(node.Key, 0);
            }

            foreach (var node in vertices)
            {
                foreach (var next in node.Value)
                {
                    indegrees[next]++;
                }
            }

            return indegrees;
        }


        private static Dictionary<char, List<char>> ConstructGraph(string[] words)
        {
            var vertices = new Dictionary<char, List<char>>();
            var fword = words[0];
            foreach (var ch in fword)
            {
                if (vertices.ContainsKey(ch) == false)
                {
                    vertices.Add(ch, new List<char>());
                }
            }

            for (int i = 1; i < words.Length; i++)
            {                
                var sword = words[i];
                foreach (var ch in sword)
                {
                    if (vertices.ContainsKey(ch) == false)
                    {
                        vertices.Add(ch, new List<char>());
                    }
                }

                int min = Math.Min(fword.Length, sword.Length);
                for (int j = 0; j < min; j++)
                {
                    if(fword[j] != sword[j])
                    {
                        vertices[fword[j]].Add(sword[j]);
                        break;
                    }
                }

                fword = sword;
            }

            return vertices;
        }
    }
}

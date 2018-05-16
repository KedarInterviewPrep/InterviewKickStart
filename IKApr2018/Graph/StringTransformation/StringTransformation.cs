using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class StringTransformation
    {
        public static string[] string_transformation(string[] words, string start, string stop)
        {
            //var visited = new HashSet<string>();
            var visited = new Dictionary<string, string>();
            var allWords = new List<string>(words);
            allWords.Add(stop);

            Queue<string> q = new Queue<string>();
            q.Enqueue(start);
            //visited.Add(start, null);
            bool firstIteration = true;

            while(q.Count != 0)
            {
                var cur = q.Dequeue();
                if(cur == stop && (start != stop || !firstIteration))
                {
                    return GetPath(stop, start, visited).ToArray();
                }

                var neighbors = GetNeighbors(cur, allWords);

                foreach(var next in neighbors)
                {
                    if(visited.ContainsKey(next) == false)
                    {
                        visited.Add(next, cur);
                        q.Enqueue(next);
                    }
                }

                firstIteration = false;
            }

            return new string[] { "-1" };
        }

        private static List<string> GetNeighbors(string cur, IList<string> words)
        {
            var neighbors = new List<string>();
            foreach(var word in words)
            {
                bool flag = false; // keeps track that there is exactly one character difference.
                for(int i = 0; i< cur.Length; i++)
                {
                    if(word[i] != cur[i])
                    {
                        if(!flag)
                        {
                            flag = true;
                        }
                        else // more than 1 difference.
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if(flag) // only 1 difference.
                {
                    neighbors.Add(word);
                }
            }

            return neighbors;
        }

        private static List<string> GetPath(string stop, string start, Dictionary<string, string> visited)
        {
            var path = new List<string>();
            string cur = stop;

            do
            {
                path.Add(cur);
                cur = visited[cur];
            } while (cur != start);

            path.Add(start);
            path.Reverse();
            return path;
        }
    }
}

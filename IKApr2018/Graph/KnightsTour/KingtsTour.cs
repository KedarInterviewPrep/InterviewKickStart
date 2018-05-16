using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public static class KingtsTour
    {
        public static int find_minimum_number_of_moves(int rows, int cols, int start_row, int start_col, int end_row, int end_col)
        {
            bool[,] visited = new bool[rows, cols];
            int[,] distance = new int[rows, cols];
            Queue<Cell> q = new Queue<Cell>();

            visited[start_row, start_col] = true;
            distance[start_row, start_col] = 0;
            q.Enqueue(new Cell(start_row, start_col));

            while (q.Count != 0)
            {
                var cur = q.Dequeue();
                if (cur.row == end_row && cur.col == end_col)
                {
                    return distance[cur.row,cur.col];
                }

                List<Cell> neighbors = GetNeighbors(cur, rows, cols);
                foreach (var next in neighbors)
                {
                    if (visited[next.row,next.col] == false)
                    {
                        visited[next.row,next.col] = true;
                        distance[next.row,next.col] = distance[cur.row,cur.col] + 1;
                        q.Enqueue(next);
                    }
                }
            }

            return -1;
        }

        private static List<Cell> GetNeighbors(Cell cur, int row, int col)
        {
            var neighbors = new List<Cell>();
            var transitions = new List<Cell> {
                new Cell(1,2),
                new Cell(1,-2),
                new Cell(-1,2),
                new Cell(-1,-2),
                new Cell(2,1),
                new Cell(2,-1),
                new Cell(-2,1),
                new Cell(-2,-1),
            };

            foreach(var next in transitions)
            {
                int ni = cur.row + next.row;
                int nj = cur.col + next.col;

                if(ni >= 0 && ni < row && nj >= 0 && nj < col)
                {
                    neighbors.Add(new Cell(ni, nj));
                }
            }

            return neighbors;
        }

        class Cell
        {
            public int row;
            public int col;

            public Cell(int i, int j)
            {
                this.row = i;
                this.col = j;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class ShortestPathGrid
    {
        enum CellType
        {
            None = 0,
            Land,
            Water,
            Key,
            Door,
        };

        public static int[][] find_shortest_path(string[] grid)
        {
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            Cell[,] parent = new Cell[grid.Length, grid[0].Length];
            Cell start = GetStartCell(grid);
            HashSet<char> keys = new HashSet<char>();
            Queue<Cell> q = new Queue<Cell>();

            visited[start.row, start.col] = true;
            parent[start.row, start.col] = new Cell(-1, -1);
            q.Enqueue(start);

            while (q.Count != 0)
            {
                var cur = q.Dequeue();
                if(IsEndCell(cur, grid))
                {
                    return GetPath(parent, cur);
                }

                List<Cell> neighbors = GetNeighbors(cur, grid.Length, grid[0].Length);

                foreach (var next in neighbors)
                {
                    if (visited[next.row, next.col])
                        continue;

                    CellType type = GetCellType(next, grid);
                    switch (type)
                    {
                        case CellType.Land:
                            visited[next.row, next.col] = true;
                            parent[next.row, next.col] = cur;
                            q.Enqueue(next);
                            break;
                        case CellType.Water:
                            // do nothing.
                            visited[next.row, next.col] = true; // optimization.
                            break;
                        case CellType.Key:
                            visited[next.row, next.col] = true;
                            parent[next.row, next.col] = cur;
                            q.Enqueue(next);
                            if (!keys.Contains(grid[next.row][next.col]))
                            {
                                keys.Add(grid[next.row][next.col]);
                            }
                            break;
                        case CellType.Door:
                            if(keys.Contains(grid[next.row][next.col].ToString().ToLower().ToCharArray()[0])) // we have the right key.
                            {
                                visited[next.row, next.col] = true;
                                parent[next.row, next.col] = cur;
                                q.Enqueue(next);
                            }
                            break;
                    }
                }
            }

            return null;
        }

        private static int[][] GetPath(Cell[,] parent, Cell endCell)
        {
            var result = new List<int[]>();
            var cur = endCell;

            while(cur.row != -1 && cur.col != -1)
            {
                result.Add(new int[2] { cur.row, cur.col });
                cur = parent[cur.row, cur.col];
            }

            result.Reverse();
            return result.ToArray();
        }

        private static bool IsEndCell(Cell cur, string[] grid)
        {
            return grid[cur.row][cur.col] == '+';
        }

        private static List<Cell> GetNeighbors(Cell cur, int row, int col)
        {
            var neighbors = new List<Cell>();
            var transitions = new List<Cell>()
            {
                new Cell(0,1),
                new Cell(0,-1),
                new Cell(1,0),
                new Cell(-1,0),
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

        private static CellType GetCellType(Cell cur, string[] grid)
        {
            if (grid[cur.row][cur.col] == '.' || grid[cur.row][cur.col] == '+')
                return CellType.Land;
            if (grid[cur.row][cur.col] == '#')
                return CellType.Water;
            if (grid[cur.row][cur.col] >= 'a' && grid[cur.row][cur.col] <= 'z')
                return CellType.Key;
            if (grid[cur.row][cur.col] >= 'A' && grid[cur.row][cur.col] <= 'Z')
                return CellType.Door;

            return CellType.None;
        }

        private static Cell GetStartCell(string[] grid)
        {
            for(int i = 0; i < grid.Length; i++)
            {
                var index = grid[i].IndexOf('@');
                if (index >= 0)
                    return new Cell(i, index);
            }

            return null;
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

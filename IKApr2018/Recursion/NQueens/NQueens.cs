using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Recursion.NQueens
{
    public class NQueens
    {
        public static string[][] find_all_arrangements(int n)
        {
            bool[][] grid = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                grid[i] = new bool[n];
            }



            List<string[]> result = new List<string[]>();
            nQueens(0, n, ref grid, ref result);
            result.Insert(0, new string[] { $"{result.Count} different arrangements possible." });
            return result.ToArray();
        }

        private static void nQueens(int row, int n, ref bool[][] grid, ref List<string[]> result)
        {
            if (row == n)
            {
                result.Add(GetBoard(grid, n));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (isSafe(row, i, grid))
                {
                    grid[row][i] = true;
                    nQueens(row + 1, n, ref grid, ref result);
                    grid[row][i] = false;
                }
            }
        }

        private static bool isSafe(int row, int col, bool[][] grid)
        {
            for (int i = 0; i < row; i++)
            {
                if (grid[i][col] == true)
                    return false;
                if (row - i - 1 >= 0 && col - i - 1 >= 0 && grid[row - i - 1][col - i - 1] == true)
                {
                    return false;
                }
                if (row - i - 1 >= 0 && col + i + 1 < grid.Length && grid[row - i - 1][col + i  + 1] == true)
                {
                    return false;
                }
            }

            return true;
        }


        private static string[] GetBoard(bool[][] grid, int n)
        {
            string[] result = new string[n];
            for (int i = 0; i < n; i++)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j])
                    {
                        sb.Append("q");
                    }
                    else
                    {
                        sb.Append("-");
                    }
                }

                result[i] = sb.ToString();
            }

            return result;
        }
    }
}

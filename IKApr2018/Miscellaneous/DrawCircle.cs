using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscellaneous
{
    public static class DrawCircle
    {
        public static void DrawGrid(int r)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < r; j++)
                    Console.Write("0");
                Console.WriteLine();
            }
        }
    }


}

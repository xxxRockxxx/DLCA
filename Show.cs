using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLCA
{
    class Show
    {
        public void DrawMatrix(int[,] Matrix)
        {
            Console.Clear();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

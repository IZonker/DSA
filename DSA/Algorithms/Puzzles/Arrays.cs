using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Algorithms.Puzzles
{
    public static partial class Puzzles
    {
        /// <summary>
        /// 1,2,3    7,4,1
        /// 4,5,6 => 8,5,2
        /// 7,8,9    9,6,3
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static T[,] Rotate2DMatrix90Degree<T>(T[,] matrix)
        {
            int columnLength = matrix.GetLength(0);
            int rowLength = matrix.GetLength(0);
            var result = new T[columnLength, rowLength];

            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < columnLength; c++)
                {
                    result[r, c] = matrix[columnLength - 1 - c, r];
                }
            }

            return result;
        }

        /// <summary>
        /// 1,2,3    9,8,7
        /// 4,5,6 => 6,5,4
        /// 7,8,9    3,2,1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static T[,] Rotate2DMatrix180Degree<T>(T[,] matrix)
        {
            int columnLength = matrix.GetLength(0);
            int rowLength = matrix.GetLength(0);
            var result = new T[columnLength, rowLength];

            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < columnLength; c++)
                {
                    result[r, c] = matrix[columnLength - 1 - r, rowLength - 1 - r];
                }
            }

            return result;
        }
    }
}

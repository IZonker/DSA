using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{

    public static partial class Sorting
    {
        /// <summary>
        /// O(N ^ 2)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void InsertionSort<T>(this IList<T> list) where T : IComparable<T>
        {
            int length = list.Count;
            
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (list[j].CompareTo(list[j - 1]) <= 0)
                    {
                        list.Swap(j, j - 1);
                    }
                    else break;
                }               
            }            
        }
    }
}

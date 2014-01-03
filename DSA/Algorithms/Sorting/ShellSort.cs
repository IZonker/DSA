using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{

    public static partial class Sorting
    {
        /// <summary>
        /// The best case: O(N log N)
        /// The worst case: O(N ^ 2):
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void ShellSort<T>(this IList<T> list) where T : IComparable<T>
        {
            int length = list.Count;
            int h = 1;
            while (h < length / 3) { h = 3 * h + 1; }
            
            while (h >= 1)
            {
                for (int i = h; i < length; i++)
                {
                    for(int j = i; j >= h && list[j].CompareTo(list[j-h]) < 0; j-=h)
                    {
                        list.Swap(j, j - h);
                        list.Print();
                    }
                }
                
                h = h / 3;
            }        
        }
    }
}

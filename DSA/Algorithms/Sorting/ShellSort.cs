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
        /// <param name="elements"></param>
        public static void ShellSort<T>(this IList<T> elements) where T : IComparable<T>
        {
            int length = elements.Count;
            int gap = length / 2;
            
            while (gap >= 1)
            {
                for (int i = gap; i < length; i++)
                {
                    for(int j = i; j >= gap; j-= gap)
                    {
                        if (elements[j].CompareTo(elements[j - gap]) < 0)
                        {
                            elements.Swap(j, j - gap);
                        }
                    }
                }
                gap /= 2;
            }        
        }
    }
}

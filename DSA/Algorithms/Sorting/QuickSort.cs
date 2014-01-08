using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{
    public static partial class Sorting
    {
        /// <summary>
        /// O(N log N)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        public static void QuickSort<T>(this IList<T> elements) where T : IComparable
        {
           // Shuffle(items);           
            QuickSort(elements, 0, elements.Count - 1);
        }

        /// <summary>
        /// O(N log N)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void QuickSort<T>(IList<T> elements, int left, int right) where T: IComparable
        { 
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];
 
            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0) i++;
 
                while (elements[j].CompareTo(pivot) > 0) j--;
 
                if (i <= j)
                {
                    Swap(elements, i, j);
 
                    i++;
                    j--;
                }
            }
 
            // Recursive calls
            if (left < j)
                QuickSort(elements, left, j);
 
            if (i < right)
                QuickSort(elements, i, right);
        }
    }
}

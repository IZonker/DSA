using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{
    public static partial class Sorting
    {
        /// <summary>
        /// N^2/2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void SelectionSort<T>(this IList<T> list) where T : IComparable<T>
        {
            int length = list.Count;

            for(int i = 0; i < length; i++)
            {
                int min = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (list[j].CompareTo(list[min]) < 0)
                    {
                        min = j;
                    }
                }

                list.Swap<T>(i, min);
            }
        }
    }
}

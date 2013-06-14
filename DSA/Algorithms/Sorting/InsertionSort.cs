using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.Algorithms
{

    public static partial class Sorting
    {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.Algorithms
{
    public static partial class Sorting
    {
        public static IList<T> BubbleSort<T>(this IList<T> list) where T : IComparable
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - i; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        Swap<T>(list, j, j+1);
                    }
                }
            }

            return list;
        }
    }
}

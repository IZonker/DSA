using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{
    public static partial class Sorting 
    {
        private static void Merge<T>(IList<T> items, IList<T> aux, int min, int middle, int max) where T : IComparable
        {
            // copy to aux[]
            for (int k = min; k <= max; k++)
            {
                aux[k] = items[k];
            }

            // merge back to items[]
            int i = min, j = middle + 1;
            for (int k = min; k <= max; k++)
            {
                if      (i > middle)           items[k] = aux[j++];
                else if (j > max)              items[k] = aux[i++];
                else if (Less(aux[j], aux[i])) items[k] = aux[j++];
                else                           items[k] = aux[i++];
            }
        }

        // mergesort items[min..max] using auxiliary array aux[min..max]
        private static void MergeSort<T>(IList<T> items, IList<T> aux, int lo, int hi) where T : IComparable
        {
            if (hi <= lo) 
                return;

            int mid = lo + (hi - lo) / 2;
            MergeSort(items, aux, lo, mid);
            MergeSort(items, aux, mid + 1, hi);
            Merge(items, aux, lo, mid, hi);
        }

        /// <summary>
        /// O(N log N)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public static void MergeSort<T>(this IList<T> items) where T : IComparable
        {
            IList<T> aux = new List<T>();
            for (int i = 0; i < items.Count; i++)
                aux.Add(default(T));

            MergeSort(items, aux, 0, items.Count - 1);
        }

        #region
        private static void MergeBU<T>(IList<T> items, IList<T> aux, int lo, int mid, int hi) where T : IComparable
        {
            // copy to aux[]
            for (int k = lo; k <= hi; k++) 
            {
                aux[k] = items[k];
            }

            // merge back to items[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) items[k] = aux[j++];
                else if (j > hi) items[k] = aux[i++];
                else if (Less(aux[j], aux[i])) items[k] = aux[j++];
                else items[k] = aux[i++];
            }
        }

        public static void MergeSortBU<T>(this IList<T> items) where T : IComparable
        {
            int N = items.Count;
            IList<T> aux = new List<T>();
            for (int i = 0; i < items.Count; i++)
                aux.Add(default(T));

            for (int n = 1; n < N; n = n + n)
            {
                for (int i = 0; i < N - n; i += n + n)
                {
                    int lo = i;
                    int m = i + n - 1;
                    int hi = Math.Min(i + n + n - 1, N - 1);
                    MergeBU(items, aux, lo, m, hi);
                }
            }
        }
        #endregion

    }
}

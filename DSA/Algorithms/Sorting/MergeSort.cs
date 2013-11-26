using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{
    public static partial class Sorting 
    {
        private static void Merge<T>(IList<T> a, IList<T> aux, int lo, int mid, int hi) where T : IComparable
        {
            
            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (Less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }
        }

        static int ccc = 0;
        // mergesort a[lo..hi] using auxiliary array aux[lo..hi]
        private static void MergeSort<T>(IList<T> a, IList<T> aux, int lo, int hi) where T : IComparable
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            MergeSort(a, aux, lo, mid);
            MergeSort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
            ccc++;
            if (ccc == 7)
                a.Print();
        }

        /// <summary>
        /// N*logN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        public static void MergeSort<T>(this IList<T> a) where T : IComparable
        {
            ccc = 0;
            IList<T> aux = new List<T>();
            for (int i = 0; i < a.Count; i++)
                aux.Add(default(T));

            MergeSort(a, aux, 0, a.Count - 1);
        }

        private static void MergeBU<T>(IList<T> a, IList<T> aux, int lo, int mid, int hi) where T : IComparable
        {
            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (Less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }

            ccc++;
            if (ccc == 7)
                a.Print();
        }


        public static void MergeSortBU<T>(this IList<T> a) where T : IComparable
        {
            ccc = 0;
            int N = a.Count;
            IList<T> aux = new List<T>();
            for (int i = 0; i < a.Count; i++)
                aux.Add(default(T));

            for (int n = 1; n < N; n = n + n)
            {
                for (int i = 0; i < N - n; i += n + n)
                {
                    int lo = i;
                    int m = i + n - 1;
                    int hi = Math.Min(i + n + n - 1, N - 1);
                    MergeBU(a, aux, lo, m, hi);
                }
            }
        }
    }
}

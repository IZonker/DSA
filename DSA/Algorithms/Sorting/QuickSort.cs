using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{
    public static partial class Sorting
    {
        public static void QuickSort<T>(this IList<T> items) where T : IComparable
        {
           // Shuffle(items);           
            QuickSort(items, 0, items.Count -1);
        }

        // quicksort the subarray from a[lo] to a[hi]
        private static void QuickSort<T>(IList<T> items, int low, int high) where T: IComparable
        { 
            if (high <= low) 
                return;
            int j = Partition(items, low, high);
            
            QuickSort(items, low, j - 1);
            QuickSort(items, j + 1, high);
            
           
         }

        // partition the subarray a[lo .. hi] by returning an index j
        // so that a[lo .. j-1] <= a[j] <= a[j+1 .. hi]
        private static int Partition<T>(IList<T> items, int low, int high) where T : IComparable
        {
            int i = low;
            int j = high + 1;
            T v = items[low];
            
            while (true)
            {
                
                // find item on lo to swap
                while (Less(items[++i], v))
                    if (i == high) break;
               
                // find item on hi to swap
                while (Less(v, items[--j]))
                    if (j == low) break;      // redundant since a[lo] acts as sentinel
                
               
               
                // check if pointers cross
                if (i >= j) break;

                Swap(items, i, j);
               
            }

            // put v = a[j] into position
            Swap(items, low, j);
            items.Print();
            // with a[lo .. j-1] <= a[j] <= a[j+1 .. hi]
            return j;
        }


        // quicksort the array a[] using 3-way partitioning
        public static void QuickSort3way<T>(this IList<T> a) where T: IComparable
        {
            QuickSort3way(a, 0, a.Count - 1);
        }

        // quicksort the subarray a[lo .. hi] using 3-way partitioning
        private static void QuickSort3way<T>(IList<T> a, int lo, int hi) where T : IComparable
        { 
            if (hi <= lo) return;
            int lt = lo, gt = hi;
            T v = a[lo];
            int i = lo;
            while (i <= gt) {
                int cmp = a[i].CompareTo(v);
                if      (cmp < 0) Swap(a, lt++, i++);
                else if (cmp > 0) Swap(a, i, gt--);
                else              i++;
            }
            a.Print();
            // a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]. 
            QuickSort3way(a, lo, lt-1);
            QuickSort3way(a, gt+1, hi);           
        }

        public static T QuickSortSelect<T>(this IList<T> a, int k) where T : IComparable
        {
            Shuffle(a);
            int lo = 0, hi = a.Count - 1;
            while (hi > lo)
            {
                int i = Partition(a, lo, hi);
                //a.Print();
                if (i > k) hi = i - 1;
                else if (i < k) lo = i + 1;
                else return a[i];
            }
            return a[lo];
        }
    }
}

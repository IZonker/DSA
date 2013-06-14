using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.Algorithms.Searching
{
    public static class BinarySearch
    {
        public static int Search(int key, int[] a)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while (lo <= hi)
            {
                // Key is in a[lo..hi] or not present.
                int mid = lo + (hi - lo) / 2;
                Console.WriteLine(a[mid]);
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) lo = mid + 1;
                else return mid;
            }
            return -1;
        }
    }
}

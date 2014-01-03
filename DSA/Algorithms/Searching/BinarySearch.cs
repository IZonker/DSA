using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.Algorithms.Searching
{
    public static partial class Searching
    {
        /// <summary>
        /// Worst case: O(log N)
        /// Best case: O(1)  
        /// </summary>
        /// <param name="key"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int BinarySearch(int key, int[] a)
        {
            int min = 0;
            int max = a.Length - 1;
            while (min <= max)
            {
                // Key is in a[min..max] or not present.
                int middle = min + (max - min) / 2;
                
                if (key < a[middle]) 
                    max = middle - 1;
                else if (key > a[middle]) 
                    min = middle + 1;
                else return middle;
            }
            return -1;
        }

        /// <summary>
        /// Worst case: O(log N)
        /// Best case: O(1)  
        /// </summary>
        /// <param name="key"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int RBinarySearch(int key, int[] items)
        {
            return RBinarySearch(key, items, 0, items.Length);
        }

        private static int RBinarySearch(int key, int[] items, int min, int max)
        {
            int middle = min + (max - min)/2;

            if (key == items[middle])
                return middle;
            if (key > items[middle])
                return RBinarySearch(key, items, middle + 1, max);
            if (key < items[middle])
                return RBinarySearch(key, items, min,        middle - 1);

            return -1;
        }
    }
}

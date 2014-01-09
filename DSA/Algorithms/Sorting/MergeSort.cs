using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{
    public static partial class Sorting 
    {
        /// <summary>
        /// O(N log N)
        /// </summary>
        /// <param name="elements"></param>
        public static void MergeSort<T>(this List<T> elements) where T : IComparable
        {
            MergeSort(elements, 0, elements.Count - 1);
        }
        static void Print<T>(T[] elements)
        {
            Console.Write(string.Join(",", elements) + " \t");
        }

        /// <summary>
        /// O(N log N)
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void MergeSort<T>(this List<T> elements, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                
                MergeSort(elements, left,       middle);
                MergeSort(elements, middle + 1, right);
                
                //Merge
                var leftArray = new T[middle - left + 1];
                var rightArray = new T[right - middle];
                
                Array.Copy(elements.ToArray(), left,       leftArray,  0, middle - left + 1);
                Array.Copy(elements.ToArray(), middle + 1, rightArray, 0, right - middle);

                Print(leftArray);
                Print(rightArray);

                int i = 0;
                int j = 0;

                for (int k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        elements[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        elements[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i].CompareTo(rightArray[j]) <= 0)
                    {
                        elements[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        elements[k] = rightArray[j];
                        j++;
                    } 
                }
            }
        }
    }
}

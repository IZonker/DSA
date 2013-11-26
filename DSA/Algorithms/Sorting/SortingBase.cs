using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{
    public static partial class Sorting
    {

        internal static void Swap<T>(this IList<T> list, int first, int second)
        {
            T temp = list[first];
            list[first] = list[second];
            list[second] = temp;
        }

        public static void Print<T>(this IList<T> elements)
        {
            Console.WriteLine(string.Join(" ", elements));
        }

        private static bool Less<T>(T v, T w) where T :IComparable
        {
            return (v.CompareTo(w) < 0);
        }

        private static void Shuffle<T>(IList<T> items)
        {
            int N = items.Count;
            var random = new Random();
            for (int i = 0; i < N; i++)
            {
                int r = i + random.Next(N - i);
                Swap(items, i, r);
            }           
        } 
    }
}

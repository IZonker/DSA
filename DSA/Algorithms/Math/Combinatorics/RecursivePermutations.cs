using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Math.Combinatorics
{
    public static partial class Combinatorics
    {
        public static void PrintPermutationsR<T>(this IList<T> elements, int? resultSize = null, bool withRepetition = false)
        {
            Action<IList<T>> action = (list) => Console.WriteLine(string.Join("", list));
            elements.GetPermutationsR(action);
        }

        public static void GetPermutationsR<T>(this IList<T> elements, Action<IList<T>> action = null, IList<T> result = null, bool[] used = null, int position = 0)
        {
            var length = elements.Count;
            if (result == null) result = new List<T>(length);
            if (used == null)   used   = new bool[length];

            if (position == length && action != null)
            {
                action(result);
                return;
            }

            for (int i = 0; i < length; i++)
            {
                if (used[i]) continue;

                result.Add(elements[i]);
                used[i] = true;

                GetPermutationsR(elements, action, result, used, position + 1);

                result.RemoveAt(result.Count - 1);
                used[i] = false;
            }
        }
    }
}

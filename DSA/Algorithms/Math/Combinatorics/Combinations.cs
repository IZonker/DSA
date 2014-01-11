using System;
using System.Collections.Generic;

namespace DSA.Algorithms.Math.Combinatorics
{
    public static partial class Combinatorics
    {
        public static void PrintCombinations<T>(this IList<T> elements, int? resultSize = null, bool withRepetition = false)
        {
            Action<IList<T>> action = (list) => Console.WriteLine(string.Join("", list));
            elements.GetCombinations(action, resultSize, withRepetition);
        }

        /// <summary>
        /// Gets all combinations (of a given size) of a given list, either with or without reptitions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="action"></param>
        /// <param name="resultSize"></param>
        /// <param name="withRepetition"></param>
        public static void GetCombinations<T>(this IList<T> list, Action<IList<T>> action, int? resultSize = null, bool withRepetition = false)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (action == null)
                throw new ArgumentNullException("action");
            if (resultSize.HasValue && resultSize.Value <= 0)
                throw new ArgumentException("Value must be greater than zero, if specified.", "resultSize");

            var result = new T[resultSize.HasValue ? resultSize.Value : list.Count];
            var indices = new int[result.Length];
            for (int i = 0; i < indices.Length; i++)
                indices[i] = withRepetition ? -1 : indices.Length - i - 2;

            int curIndex = 0;
            while (curIndex != -1)
            {
                indices[curIndex]++;
                if (indices[curIndex] == (curIndex == 0 ? list.Count : indices[curIndex - 1] + (withRepetition ? 1 : 0)))
                {
                    indices[curIndex] = withRepetition ? -1 : indices.Length - curIndex - 2;
                    curIndex--;
                }
                else
                {
                    result[curIndex] = list[indices[curIndex]];
                    if (curIndex < indices.Length - 1)
                        curIndex++;
                    else
                        action(result);
                }
            }
        }
    }
}

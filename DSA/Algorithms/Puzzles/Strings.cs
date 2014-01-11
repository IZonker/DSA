using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Algorithms.Puzzles
{
    public static partial class Puzzles
    {
        /// <summary>
        /// Determine if a string has all unique characters without additional data structures
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasUniqueChars(string str)
        {
            int flag = 0;
            foreach (char c in str)
            {
                int value = 1 << (c - 'a');

                if ((flag & value) == 0)
                {
                    flag |= value;
                }
                else return false;
            }

            return true;
        }

        /// <summary>
        /// Removes the duplicate characters in a string without using any additional buffer 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveDuplicates(string str)
        {
            var chars = str.ToCharArray();
            int len = chars.Length;
            int tail = 1;

            for (int i = 1; i < len; i++)
            {
                int j;
                for (j = 0; j < tail; j++)
                {
                    if (chars[j] == chars[i]) break;
                }

                if (j == tail)
                {
                    chars[j] = chars[i];
                    tail++;
                }
            }
            return new string(chars, 0, tail);
        }

        /// <summary>
        /// Decides if two strings are anagrams or not
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool IsAnagram(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;
            if (s1.Length != s2.Length)
                return false;

            foreach (char c in s2)
            {
                int ix = s1.IndexOf(c);
                if (ix >= 0)
                {
                    s1 = s1.Remove(ix, 1);
                }
            }

            return string.IsNullOrEmpty(s1);
        }
    }
}

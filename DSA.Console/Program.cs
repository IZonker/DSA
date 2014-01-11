using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Algorithms;
using DSA.Algorithms.Searching;
using DSA.Algorithms.Sorting;
using DSA.DataStructures.Lists;
using DSA.DataStructures.Trees;
using DSA.Algorithms.Math.Combinatorics;
namespace DSA.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "ccdedcafrgcffkl";
            removeDuplicates(value.ToCharArray());
            System.Console.Read();
        }

        public static void RemoveDuplicates(char[] value)
        {
            int length = value.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = i+1; j < length-1; j++)
                {
                    if (value[i] == value[j])
                    {
                        
                    }

                }
            }
        }

        public static bool HasUniqueChars(string value)
        {
            int flag = 0;
            for (int i = 0; i < value.Length; i++)
            {
                int bit = (value[i] - 'a');
                int val = 1 << bit;

                if ((flag & val) == 0)
                    flag |= val;
                else return false;
            }
            return true;
        }

        public static void removeDuplicates(char[] chars)
        {
            int len = chars.Length;
            int tail = 1;

            for (int i = 1; i < len; i++)
            {
                int j;
                for (j = 0; j < tail; j++)
                    if (chars[i] == chars[j]) break;

                if (j == tail)
                {
                    chars[tail] = chars[i];
                    tail++;
                }
            }
            chars[tail] = '\0';

            System.Console.WriteLine(chars);
        }

        private static string Reverse(string value, int index)
        {
            if (index == 0)
                return value[index].ToString();

            return value[index-1] + Reverse(value, index-1);
        }

    }
}

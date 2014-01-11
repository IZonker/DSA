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
        private string var = @"asdasdasdasdasd";
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int, string>();
            tree.Add(10);
            tree.Add(12);
            tree.Add(8);
            tree.Add(6);
            tree.Print();
           bool d = tree.Remove(10);
           // tree.Print();

            var elements = new List<int>() {1,2,3,4,5};
            elements.PrintCombinations(3,true);

            //PrintCombinations(5, 4);
            System.Console.Read();
        }

        

        private static bool NextPermutation(int[] numList)
        {
            /*
             Knuths
             1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
             2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
             3. Swap a[j] with a[l].
             4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

             */
            var largestIndex = -1;
            for (var i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }

            if (largestIndex < 0) return false;

            var largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }

            var tmp = numList[largestIndex];
            numList[largestIndex] = numList[largestIndex2];
            numList[largestIndex2] = tmp;

            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                tmp = numList[i];
                numList[i] = numList[j];
                numList[j] = tmp;
            }

            return true;
        }

        static void PrintCombinations(int n, int k)
        {
            if (n < 1)
                throw new ArgumentException("Set must have at least one element");
            if (k > n)
                throw new ArgumentException("Subset length can not be greater than set length");

            int[] subset = new int[k];
            int j;

            for (int i = 1; i <= k; i++)
                subset[i - 1] = i;

            do
            {
                for (int i = 0; i < k; i++)
                    System.Console.Write(subset[i]);
                System.Console.WriteLine();

                for (j = k - 1; (j != 0) && (subset[j] == n - k + j + 1); j--) ;

                subset[j]++;

                for (int i = j + 1; i < k; i++)
                    subset[i] = subset[i - 1] + 1;

            } while (subset[k - 1] <= n);
        } 

        static void hanoi(int x, char from, char to, char help)
        {
            if (x > 0)
            {
                hanoi(x - 1, from, help, to);
                
                hanoi(x - 1, help, to, from);
            }

        }

        public static void Hanoi(int n, int d)
        {
            if (n == 0) return;


            Hanoi(n - 1, -d);
            Hanoi(n - 1, -d);
        }

        public static void MergeSort(int k, int left, int right, char c)
        {
            if (left < right)
            {
                int middle = (left + right)/2;

                MergeSort(k, left,       middle, 'A');
                System.Console.WriteLine("{0}, {1}, {2}, {3}", c, middle, left, right);
                MergeSort(k, middle + 1, right,  'B');
            }
        }

        public static void Rec(int l, int r)
        {
            if (l<r)
                return;

           
            Rec(l+1,r);
            Rec(l,r-1);
            System.Console.WriteLine(l);
            
        }

        private static string Reverse(string value, int index)
        {
            if (index == 0)
                return value[index].ToString();

            return value[index-1] + Reverse(value, index-1);
        }

        private static int Factorial(int value)
        {
            if (value <= 1)
                return value;

            return value * Factorial(value - 1);
        }

        private static int Fibonacci(int value)
        {
            if (value <= 1)
                return 1;

            return Fibonacci(value - 1) + Fibonacci(value - 2);
        }
    }
}

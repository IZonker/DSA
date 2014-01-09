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

            var elements = new List<int>() {4,3,1,7,5,6,2};
            elements.Print();
            elements.ShellSort();
            elements.Print();

            System.Console.Read();
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

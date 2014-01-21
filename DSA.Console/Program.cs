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
using DSA.Algorithms.Puzzles;

namespace DSA_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new SinglyLinkedList<int> {3, 1, 5};

            var list2 = new SinglyLinkedList<int> {5, 9, 2};

            var sum = Puzzles.AddLists<int>(list1.Head, list2.Head, 0);


            Console.Read();
        }
    }
}

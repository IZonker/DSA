using System;
using System.Collections.Generic;
using DSA.Algorithms.Math.Combinatorics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.Algorithms.Math
{
    [TestClass]
    public class CombinatorialMethodsTest
    {
        [TestMethod]
        public void TestPermutations()
        {
            var elements = new List<int> { 1, 2, 3, 4, 5 };
            elements.PrintPermutations();
        }

        [TestMethod]
        public void TestCombinations()
        {
            var elements = new List<int> { 1, 2, 3, 4, 5 };
            elements.PrintPermutations();
        }
    }
}

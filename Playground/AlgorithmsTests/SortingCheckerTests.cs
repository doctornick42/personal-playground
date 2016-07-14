using Microsoft.VisualStudio.TestTools.UnitTesting;
using Playground.Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.AlgorithmsTests
{
    [TestClass]
    public class SortingCheckerTests
    {
        [TestMethod]
        public void CheckOrder_CorrectlyOrderedArray_True()
        {
            SortingChecker<int> sortingChecker = new SortingChecker<int>();

            int[] testArray = new int[5] { 1, 2, 3, 4, 5 };

            Assert.IsTrue(sortingChecker.CheckOrder(testArray));
        }

        [TestMethod]
        public void CheckOrder_IncorrectlyOrderedArray_False()
        {
            SortingChecker<int> sortingChecker = new SortingChecker<int>();

            int[] testArray = new int[5] { 3, 2, 1, 5, 4 };

            Assert.IsFalse(sortingChecker.CheckOrder(testArray));
        }
    }
}

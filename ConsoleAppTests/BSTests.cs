using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAlgos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAlgos.Tests
{
    [TestClass()]
    public class BSTests
    {

        [TestMethod()]
        public void IsPerfectSquareTestwithPerfectSquare()
        {
            //arange
            BS test = new();
            int value = 808201;
            bool isPerfect = test.IsPerfectSquare(value);

            Assert.IsTrue(isPerfect);
        }

        [TestMethod()]
        public void IsPerfectSquareTestwithNotPerfectSquare()
        {
            //arange
            BS test = new();
            int value = 20;
            bool isPerfect = test.IsPerfectSquare(value);

            Assert.IsFalse(isPerfect);
        }

        [TestMethod()]
        public void SearchMatrixTestTargetInMatrix()
        {
            //arange
            BS test = new();
            int[][] theMatrix = [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]];
            int target = 60;
            bool foundTarget = test.SearchMatrix(theMatrix,target);

            Assert.IsTrue(foundTarget);
        }

        [TestMethod()]
        public void FindMinTest()
        {
            //arange
            BS test = new();
            int[] theArray = [5, 3, 4, 1, 2 ];
            int foundTarget = test.FindMin(theArray);

            Assert.AreEqual(1,foundTarget);
        }

        [TestMethod()]
        public void SearchMTest()
        {
            //arange
            BS test = new();
            int[] theArray = [1, 3];
            int foundTarget = test.SearchM(theArray,3);

            Assert.AreEqual(1, foundTarget);
        }

        [TestMethod()]
        public void KokoBanna()
        {
            //arange
            BS test = new();
            int[] theArray = [805306368, 805306368, 805306368];
            int h = 1000000000;
            int foundTarget = test.MinEatingSpeed(theArray, h);

            Assert.AreEqual(3, foundTarget);
        }
    }
}
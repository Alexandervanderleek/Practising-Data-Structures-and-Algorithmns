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
    public class DynamicProgramingTests
    {
        

        [TestMethod()]
        public void FibTopDownTest()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.FibTopDown(3);
        
            Assert.AreEqual(2, result);
        
        }


        [TestMethod()]
        public void FibTabulationTest()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.BottomUpFib(3);

            Assert.AreEqual(2, result);

        }

        [TestMethod()]
        public void RecusiveStairsTest()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.RecursiveStairsCounter(3);

            Assert.AreEqual(3, result);

        }

        [TestMethod()]
        public void MinCostStairsRecursive()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.MinClimbStairs(new int[] {10,15,20});

            Assert.AreEqual(15, result);

        }

        [TestMethod()]
        public void minCostBottomUp()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.MinClimbStairsDP(new int[] { 10, 15, 20 });

            Assert.AreEqual(15, result);

        }

        [TestMethod()]
        public void RobTest()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.Rob(new int[] { 2, 1,1, 2 });

            Assert.AreEqual(4, result);

        }

        [TestMethod()]
        public void UniquePathTest()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.UniquePaths(3,7);

            Assert.AreEqual(28, result);

        }

        [TestMethod()]
        public void MaxSubArrTest()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.MaxSubArray([1,2]);

            Assert.AreEqual(3, result);

        }

        [TestMethod()]
        public void CoinTest()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.CoinChange([1, 2,5],11);

            Assert.AreEqual(0, result);

        }


        [TestMethod()]
        public void LongestSubSeq()
        {
            DynamicPrograming programing = new DynamicPrograming();
            int result = programing.LengthOfLIS([10, 9, 2, 5, 3, 7, 101, 18]);

            Assert.AreEqual(4, result);

        }
    }
}
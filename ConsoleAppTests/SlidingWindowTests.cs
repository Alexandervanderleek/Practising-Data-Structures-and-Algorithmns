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
    public class SlidingWindowTests
    {
        [TestMethod()]
        public void FindMaxAverageTest()
        {
            SlidingWindow window = new SlidingWindow();

            int[] values = [1, 12, -5, -6, 50, 3];
            int width = 4;

            double result = window.FindMaxAverage(values, width);

            Assert.AreEqual(result, 12.75);
        
        }

        [TestMethod()]
        public void LongestOnesTest()
        {
            SlidingWindow window = new SlidingWindow();

            int[] values = [0, 0, 0];
            int kValue = 2;
            int result = window.LongestOnes(values, kValue);

            Assert.AreEqual(result, 2);

        }

        [TestMethod()]
        public void LengthOfLongestSubstringTest()
        {
            SlidingWindow window = new SlidingWindow();

            string myString = "dvdf";
            int result = window.LengthOfLongestSubstring(myString);

            Assert.AreEqual(result, 3);

        }

        [TestMethod()]
        public void CharacterReplacementTest()
        {
            SlidingWindow window = new SlidingWindow();

            string myString = "ABBB";
            int kValue = 2;
            int result = window.CharacterReplacement(myString,kValue);

            Assert.AreEqual(result, 4);

        }

        [TestMethod()]
        public void MinSubArrayLenTest()
        {
            SlidingWindow window = new SlidingWindow();

            int[] myArr = [10, 5, 13, 4, 8, 4, 5, 11, 14, 9, 16, 10, 20, 8];
            int target = 80;
            int result = window.MinSubArrayLen(target, myArr);

            Assert.AreEqual(result, 6);

        }

        [TestMethod()]
        public void CheckInclusionTest()
        {
            SlidingWindow window = new SlidingWindow();

            string s1 = "ab";
            string s2 = "eidboaoo";

            bool result = window.CheckInclusion(s1, s2);

            Assert.AreEqual(result, false );

        }

        [TestMethod()]
        public void recusionTest()
        {
            SlidingWindow window = new SlidingWindow();

            

            window.reverseRecursive();

            Assert.AreEqual(true, true);

        }

    }
}
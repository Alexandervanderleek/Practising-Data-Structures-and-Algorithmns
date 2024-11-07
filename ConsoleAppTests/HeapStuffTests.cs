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
    public class HeapStuffTests
    {
        [TestMethod()]
        public void LastStoneWeightTest()
        {
            HeapStuff heapStuff = new HeapStuff();

            int result = heapStuff.LastStoneWeight([2, 7, 4, 1, 8, 1]);

            Assert.AreEqual(1, result);

            //Assert.Fail();
        }

        [TestMethod()]
        public void KthLargest()
        {
            HeapStuff heapStuff = new HeapStuff();

            int result = heapStuff.FindKthLargest([3, 2, 1, 5, 6, 4], 2);

            Assert.AreEqual(5, result);

        }

        [TestMethod()]
        public void GroupingTest()
        {
            HeapStuff heapStuff = new HeapStuff();

            int[] result = heapStuff.TopKFrequent([1, 1, 1, 2, 2, 3], 2);

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Result is "+result[i]);
            }

            int[] anotherResult = new int[2] {1,2};

            Console.WriteLine(anotherResult.Length);
            Console.WriteLine(result.Length);

            CollectionAssert.AreEqual(anotherResult, result);
        }


        [TestMethod()]
        public void ClosestPointsTest()
        {
            HeapStuff heapStuff = new HeapStuff();

            int[][] result = heapStuff.KClosest([[0, 1], [1, 0]], 2);

            int[][] correct = new int[2][] { [0, 1], [1, 0] };

            Assert.AreEqual(result.Length, correct.Length);
            for (int i = 0; i < result.Length; i++)
            {
                CollectionAssert.AreEqual(result[i], correct[i]);
            }
        }
    }
}

namespace ConsoleAppTests
{
    class HeapStuffTests
    {
    }
}

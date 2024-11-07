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
    public class GraphStuffTests
    {
        [TestMethod()]
        public void ConvertAdjancyMatrixTest()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
                [0,1],
                [1,2],
                [0,3],
                [3,4],
                [3,6],
                [3,7],
                [4,2],
                [4,5],
                [5,2]
            };


            gs.ConvertAdjancyMatrix(adjvalues);

            Assert.AreEqual(true, true);


        }

        [TestMethod()]
        public void ConvertAdjancyToList()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
                [0,1],
                [1,2],
                [0,3],
                [3,4],
                [3,6],
                [3,7],
                [4,2],
                [4,5],
                [5,2]
            };


            gs.ConvertAdjancyList(adjvalues);

            Assert.AreEqual(true, true);


        }

        [TestMethod()]
        public void TestDfs()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
                [0,1],
                [1,2],
                [0,3],
                [3,4],
                [3,6],
                [3,7],
                [4,2],
                [4,5],
                [5,2]
            };


            gs.DFSwRecursion(adjvalues);

            Assert.AreEqual(true, true);


        }

        [TestMethod()]
        public void TestDfsStackVersion()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
                [0,1],
                [1,2],
                [0,3],
                [3,4],
                [3,6],
                [3,7],
                [4,2],
                [4,5],
                [5,2]
            };


            gs.DFSwStack(adjvalues);

            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void TestBFSQ()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
                [0,1],
                [1,2],
                [0,3],
                [3,4],
                [3,6],
                [3,7],
                [4,2],
                [4,5],
                [5,2]
            };


            gs.BFSsearch(adjvalues);

            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void FindIfPathTest()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
                [0,1],[1,2],[2,0]
            };


            gs.ValidPath(3,adjvalues,0,2);

            Assert.AreEqual(true, true);
        }


        [TestMethod()]
        public void IslandCount()
        {
            GraphStuff gs = new GraphStuff();

            char[][] adjvalues = new char[][]
            {
              ['1','1','0','0','0'],
              ['1','1','0','0','0'],
              ['0','0','1','0','0'],
              ['0','0','0','1','1']
            };


            int numIslands = gs.NumIslands(adjvalues);

            Assert.AreEqual(3, numIslands);
        }

        [TestMethod()]
        public void MaxAreaTest()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
                [0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]
            };


            int maxArea = gs.MaxAreaOfIsland(adjvalues);

            Assert.AreEqual(6, maxArea);
        }

        [TestMethod()]
        public void CycleCoursesTest()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
               [1,4],[2,4],[3,1],[3,2]
            };


            bool cyclePresent = gs.CanFinish(5,adjvalues);

            Assert.AreEqual(true, cyclePresent);
        }

        [TestMethod()]
        public void PreReqTest()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
              [0,1],[1,0]
            };


            int[] returnedList = gs.FindOrder(2, adjvalues);

            Console.WriteLine(string.Join(",", returnedList));

            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void FlowTest()
        {
            GraphStuff gs = new GraphStuff();

            int[][] adjvalues = new int[][]
            {
              [1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]
            };


            IList<IList<int>> returnedList = gs.PacificAtlantic(adjvalues);

            Console.WriteLine(string.Join(",", returnedList));

            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void TestClonse()
        {
            GraphStuff gs = new GraphStuff();

            GraphStuff.Node2 node1  = new GraphStuff.Node2(1);
            GraphStuff.Node2 node2 = new GraphStuff.Node2(2);
            GraphStuff.Node2 node3 = new GraphStuff.Node2(3);
            GraphStuff.Node2 node4 = new GraphStuff.Node2(4);

            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);

            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);

            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);

            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

             gs.CloneGraph(node1);

            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void TestMinDistancePim()
        {
            GraphStuff gs = new GraphStuff();

         
            int returnedMin = gs.MinCostConnectPoints([[0, 0], [2, 2], [3, 10], [5, 2], [7, 0]]);

            Assert.AreEqual(returnedMin, 20);
        }


    }
}
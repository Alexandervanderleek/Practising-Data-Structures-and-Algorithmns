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
    public class FunWithTreesTests
    {
       

        [TestMethod()]
        public void MaxDepthTest()
        {
            FunWithTrees trees = new FunWithTrees();

            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(3);
            FunWithTrees.TreeNode nine = new FunWithTrees.TreeNode(9);
            FunWithTrees.TreeNode twenty = new FunWithTrees.TreeNode(20);
            FunWithTrees.TreeNode fifteen = new FunWithTrees.TreeNode(15);
            FunWithTrees.TreeNode seven = new FunWithTrees.TreeNode(7);

            three.left = nine;
            three.right = twenty;

            //twenty.left = fifteen;
            //twenty.right = seven;

            int retunrend  = trees.MaxDepth(three);

            Assert.AreEqual(2, retunrend);

        }


        [TestMethod()]
        public void BalancedTest()
        {
            FunWithTrees trees = new FunWithTrees();

            FunWithTrees.TreeNode one = new FunWithTrees.TreeNode(1);
            
            FunWithTrees.TreeNode two = new FunWithTrees.TreeNode(2);
            FunWithTrees.TreeNode twotwo = new FunWithTrees.TreeNode(2);

            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(3);
            FunWithTrees.TreeNode threethree = new FunWithTrees.TreeNode(3);

            FunWithTrees.TreeNode four = new FunWithTrees.TreeNode(4);
            FunWithTrees.TreeNode fourfour = new FunWithTrees.TreeNode(4);

            one.left = two;
            one.right = twotwo;

            two.left = three;
            two.right = threethree;

            three.left = four;
            three.right = fourfour;


            //twenty.right = seven;

            bool retunrend = trees.IsBalanced(one);

            Assert.AreEqual(true, retunrend);

        }

        [TestMethod()]
        public void isEqualNodes()
        {
            FunWithTrees trees = new FunWithTrees();

            FunWithTrees.TreeNode one = new FunWithTrees.TreeNode(12);

            FunWithTrees.TreeNode two = new FunWithTrees.TreeNode(72);
            FunWithTrees.TreeNode twotwo = new FunWithTrees.TreeNode(-60);

            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(12);


            three.right = twotwo;
            one.right = two;

            

            //twenty.right = seven;

            bool retunrend = trees.IsSameTree(one,three);

            Assert.AreEqual(false, retunrend);

        }


        [TestMethod()]
        public void SymCheckTest()
        {
            FunWithTrees trees = new FunWithTrees();

            FunWithTrees.TreeNode one = new FunWithTrees.TreeNode(12);

            FunWithTrees.TreeNode two = new FunWithTrees.TreeNode(60);
            FunWithTrees.TreeNode twotwo = new FunWithTrees.TreeNode(60);

            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(12);


            one.left = two;
            one.right = twotwo;

            two.left = three;



            //twenty.right = seven;

            bool retunrend = trees.IsSymmetric(one);

            Assert.AreEqual(false, retunrend);

        }


        [TestMethod()]
        public void TraverseSumCheck()
        {
            FunWithTrees trees = new FunWithTrees();

            FunWithTrees.TreeNode one = new FunWithTrees.TreeNode(1);

            FunWithTrees.TreeNode two = new FunWithTrees.TreeNode(2);

            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(3);


            one.left = two;
            //one.right = three;

            //twenty.right = seven;

            int targetValue = 2;

            bool returnedValue = trees.HasPathSum(one, targetValue);


            Assert.AreEqual(false, returnedValue);

        }

        [TestMethod()]
        public void IsSubtreeTest()
        {
            FunWithTrees trees = new FunWithTrees();

            FunWithTrees.TreeNode one = new FunWithTrees.TreeNode(1);

            FunWithTrees.TreeNode two = new FunWithTrees.TreeNode(2);

            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(3);

            FunWithTrees.TreeNode four = new FunWithTrees.TreeNode(4);

            FunWithTrees.TreeNode five = new FunWithTrees.TreeNode(5);

            FunWithTrees.TreeNode anotherfour = new FunWithTrees.TreeNode(4);

            FunWithTrees.TreeNode anotherOne = new FunWithTrees.TreeNode(1);

            FunWithTrees.TreeNode anotherTwo = new FunWithTrees.TreeNode(2);

            FunWithTrees.TreeNode zero = new FunWithTrees.TreeNode(0);

            three.left = four;
            three.right = five;

            four.left = one;
            four.right = two;

            two.left = zero;

            anotherfour.left = anotherOne;
            anotherfour.right = anotherTwo;
            //one.right = three;

            //twenty.right = seven;

            bool returnedValue = trees.IsSubtree(three, anotherfour);


            Assert.AreEqual(false, returnedValue);

        }

        [TestMethod()]
        public void BFSTest()
        {
            FunWithTrees trees = new FunWithTrees();

            

            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(3);

            FunWithTrees.TreeNode nine = new FunWithTrees.TreeNode(9);

            FunWithTrees.TreeNode twenty = new FunWithTrees.TreeNode(20);

            FunWithTrees.TreeNode fifteen = new FunWithTrees.TreeNode(15);

            FunWithTrees.TreeNode seven = new FunWithTrees.TreeNode(7);

            FunWithTrees.TreeNode eight = new FunWithTrees.TreeNode(8);
            FunWithTrees.TreeNode ten = new FunWithTrees.TreeNode(10);
            three.left = nine;
            three.right = twenty;

            twenty.left = fifteen;
            twenty.right = seven;

            nine.left = eight;

            trees.LevelOrder(three);


            Assert.AreEqual(false, false);

        }
        [TestMethod()]
        public void Kth()
        {
            FunWithTrees trees = new FunWithTrees();

            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(3);
            FunWithTrees.TreeNode one = new FunWithTrees.TreeNode(1);
            FunWithTrees.TreeNode two = new FunWithTrees.TreeNode(2);
            FunWithTrees.TreeNode four = new FunWithTrees.TreeNode(4);

            three.left = one;
            three.right = four;

            one.right = two;

            trees.KthSmallest(three,1);


            Assert.AreEqual(false, false);

        }

        [TestMethod()]
        public void validBstTest()
        {
            FunWithTrees trees = new FunWithTrees();

            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(int.MinValue);
            FunWithTrees.TreeNode one = new FunWithTrees.TreeNode(int.MaxValue);
  
            three.right = one;


            bool returned = trees.IsValidBST(three);


            Assert.AreEqual(true, returned);

        }

        [TestMethod()]
        public void AncestorTest()
        {
            FunWithTrees trees = new FunWithTrees();

            FunWithTrees.TreeNode zero = new FunWithTrees.TreeNode(0);
            FunWithTrees.TreeNode two = new FunWithTrees.TreeNode(2);
            FunWithTrees.TreeNode three = new FunWithTrees.TreeNode(3);
            FunWithTrees.TreeNode four = new FunWithTrees.TreeNode(4);
            FunWithTrees.TreeNode five = new FunWithTrees.TreeNode(5);
            FunWithTrees.TreeNode six = new FunWithTrees.TreeNode(6);
            FunWithTrees.TreeNode seven = new FunWithTrees.TreeNode(7);
            FunWithTrees.TreeNode eight = new FunWithTrees.TreeNode(8);
            FunWithTrees.TreeNode nine = new FunWithTrees.TreeNode(9);

            six.left = two;
            six.right = eight;

            two.left = zero;
            two.right = four;

            four.left = three;
            four.right = five;

            eight.left = seven;
            eight.right = nine;

            trees.LowestCommonAncestor(six,two,four);

            Assert.AreEqual(true, true);

        }
    }
}
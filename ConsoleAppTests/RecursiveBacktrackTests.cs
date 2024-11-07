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
    public class RecursiveBacktrackTests
    {
        [TestMethod()]
        public void SubsetsTest()
        {
            DataAlgos.RecursiveBacktrack rusriveThing = new DataAlgos.RecursiveBacktrack();

            int[] input = new int[3] {1,2,3};

            IList<IList<int>> result = rusriveThing.Subsets(input);

            int correctCount = 8;

            //check for length
            Assert.AreEqual(correctCount, result.Count());

        }

        [TestMethod()]
        public void PermTests()
        {
            DataAlgos.RecursiveBacktrack rusriveThing = new DataAlgos.RecursiveBacktrack();

            int[] input = new int[2] { 0, 1 };

            IList<IList<int>> result = rusriveThing.Permute(input);

            int correctCount = 2;

            //check for length
            Assert.AreEqual(correctCount, result.Count());

        }


        [TestMethod()]
        public void CombinationTests()
        {
            DataAlgos.RecursiveBacktrack rusriveThing = new DataAlgos.RecursiveBacktrack();

            int n = 4;
            int k = 2;

            IList<IList<int>> results = rusriveThing.Combine(n, k);

            foreach(IList<int> results2 in results)
            {
                Console.WriteLine($"the coutn is {results2.Count()}");
                Console.WriteLine(string.Join(",",results2));
            }

            //check for length
            Assert.AreEqual(results.Count(),6);

        }

        [TestMethod()]
        public void CombinationSumTests()
        {
            DataAlgos.RecursiveBacktrack rusriveThing = new DataAlgos.RecursiveBacktrack();

            int n = 4;
            int k = 2;

            IList<IList<int>> results = rusriveThing.CombinationSum([2,3,6,7], 7);

            foreach (IList<int> results2 in results)
            {
                Console.WriteLine($"the coutn is {results2.Count()}");
                Console.WriteLine(string.Join(",", results2));
            }

            //check for length
            Assert.AreEqual(results.Count(), 2);

        }


        [TestMethod()]
        public void LetterComboTest()
        {
            DataAlgos.RecursiveBacktrack rusriveThing = new DataAlgos.RecursiveBacktrack();

            IList<string> results = rusriveThing.LetterCombinations("23");

            //check for length
            Assert.AreEqual(results.Count(), 9);

        }

        [TestMethod()]
        public void ParenthesisTest()
        {
            DataAlgos.RecursiveBacktrack rusriveThing = new DataAlgos.RecursiveBacktrack();

            IList<string> results = rusriveThing.GenerateParenthesis(3);

            //check for length
            Assert.AreEqual(results.Count(), 5);

        }
    }
}
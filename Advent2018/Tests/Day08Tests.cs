using System.Collections.Generic;
using System.Linq;
using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day08Tests
    {
        private Day08 _day08;

        [TestInitialize]
        public void Setup()
        {
            _day08 = new Day08();
        }

        [TestMethod]
        public void BuildTree()
        {
            string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            TreeNode tree = _day08.ParseTree(input);
            ValidateSampleTree(tree);
        }

        [TestMethod]
        public void SampleTree()
        {
            var tree = new TreeNode
            {
                MetaData = {1, 1, 2},
                Nodes = new List<TreeNode>
                {
                    new TreeNode
                    {
                        MetaData = {10, 11, 12},
                    },
                    new TreeNode
                    {
                        MetaData = {2},
                        Nodes = new List<TreeNode>
                        {
                            new TreeNode
                            {
                                MetaData = {99}
                            }
                        }
                    },
                }
            };

            ValidateSampleTree(tree);
        }

        private void ValidateSampleTree(TreeNode root)
        {
            Assert.AreEqual(2, root.Nodes.Count);
            CollectionAssert.AreEquivalent(new List<int> { 1, 1, 2 }, root.MetaData);
            
            Assert.AreEqual(0, root.Nodes.First().Nodes.Count);
            CollectionAssert.AreEquivalent(new List<int> { 10,11,12 }, root.Nodes.First().MetaData);

            Assert.AreEqual(1, root.Nodes.Last().Nodes.Count);
            CollectionAssert.AreEquivalent(new List<int> { 2 }, root.Nodes.Last().MetaData);

            Assert.AreEqual(0, root.Nodes.Last().Nodes.First().Nodes.Count);
            CollectionAssert.AreEquivalent(new List<int>{ 99 }, root.Nodes.Last().Nodes.First().MetaData);
        }

        [TestMethod]
        public void CalculateMetaDataSumOfSampleData()
        {
            const string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var tree = _day08.ParseTree(input);
            Assert.AreEqual(138, _day08.SumMetaData(tree));
        }

        [TestMethod]
        public void CalculateMetaDataSum()
        {
            var input = FileReader.ReadFile("day08.txt").Single();
            var tree = _day08.ParseTree(input);
            Assert.AreEqual(37905, _day08.SumMetaData(tree));
        }

        [TestMethod]
        public void ValueOfRootNodeSample()
        {
            const string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var tree = _day08.ParseTree(input);
            Assert.AreEqual(66, _day08.ValueOfRootNode(tree));
        }

        [TestMethod]
        public void ValueOfRootNode()
        {
            var input = FileReader.ReadFile("day08.txt").Single();
            var tree = _day08.ParseTree(input);
            Assert.AreEqual(33891, _day08.ValueOfRootNode(tree));
        }
    }
}

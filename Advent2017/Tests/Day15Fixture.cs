using System.Collections.Generic;
using System.Linq;
using Advent2017.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day15Fixture
    {
        private Day15 _day15 = new Day15();

        [TestMethod]
        public void GeneratorA()
        {
            var expected = new List<long> { 1092455, 1181022009, 245556042, 1744312007, 1352636452 };
            var result = _day15.GetSequence(65, Day15.A).Take(5).ToList();

            Assert.AreEqual(string.Join(",", expected),
                            string.Join(",", result));
        }
        [TestMethod]
        public void GeneratorB()
        {
            var expected = new List<long> { 430625591, 1233683848, 1431495498, 137874439, 285222916 };
            var result = _day15.GetSequence(8921, Day15.B).Take(5).ToList();

            Assert.AreEqual(string.Join(",", expected),
                            string.Join(",", result));
        }

        [TestMethod]
        public void Sample()
        {
            Assert.AreEqual(1, _day15.FinalCount(65, 8921, 5));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(600, _day15.FinalCount(699, 124, 40000000));
        }

        [TestMethod]
        public void GeneratorA_Mod4()
        {
            var expected = new List<long> { 1352636452, 1992081072, 530830436, 1980017072, 740335192 };
            var result = _day15.GetSequence(65, Day15.A, 4).Take(5).ToList();

            Assert.AreEqual(string.Join(",", expected),
                string.Join(",", result));
        }

        [TestMethod]
        public void GeneratorB_Mod8()
        {
            var expected = new List<long> { 1233683848, 862516352, 1159784568, 1616057672, 412269392 };
            var result = _day15.GetSequence(8921, Day15.B, 8).Take(5).ToList();

            Assert.AreEqual(string.Join(",", expected),
                string.Join(",", result));
        }

        [TestMethod]
        public void Sample_Part2_First()
        {
            Assert.AreEqual(0, _day15.FinalCount(65, 8921, 1055, true));
            Assert.AreEqual(1, _day15.FinalCount(65, 8921, 1056, true));
        }

        [TestMethod]
        public void Sample_Part2()
        {
            Assert.AreEqual(309, _day15.FinalCount(65, 8921, 5000000, true));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(313, _day15.FinalCount(699, 124, 5000000, true));
        }
    }
}

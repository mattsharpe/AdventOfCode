using System;
using Advent2015.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day10Fixture
    {
        private Day10 _day10;

        [TestInitialize]
        public void TestInitialize() => _day10 = new Day10();

        [DataTestMethod]
        [DataRow("1","11")]
        [DataRow("11","21")]
        [DataRow("21","1211")]
        [DataRow("1211","111221")]
        [DataRow("111221","312211")]
        public void Samples(string input, string expected)
        {
            Assert.AreEqual(expected, _day10.LookAndSay(input));
        }

        [TestMethod]
        public void TwoOneOne()
        {
            var result = _day10.LookAndSay("211");
            Assert.AreEqual("1221", result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day10.Part1("1321131112");
            Assert.AreEqual(492982, result);
        }

    }
}

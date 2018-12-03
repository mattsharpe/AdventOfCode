using System;
using System.Linq;
using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day5Fixture
    {
        private Day5 _day5 = new Day5();

        private int[] _sample;

        [TestInitialize]
        public void Setup()
        {
            _sample = new []{ 0, 3, 0, 1, -3};
        }

        [TestMethod]
        public void Sample()
        {
            Assert.AreEqual(5, _day5.Solve(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day5.txt").Select(x => Convert.ToInt32(x)).ToArray();
            Assert.AreEqual(355965, _day5.Solve(input));
        }

        [TestMethod]
        public void Sample_Part2()
        {
            Assert.AreEqual(10, _day5.SolvePart2(_sample));
        }


        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day5.txt").Select(x => Convert.ToInt32(x)).ToArray();
            Assert.AreEqual(26948068, _day5.SolvePart2(input));
        }
    }
}

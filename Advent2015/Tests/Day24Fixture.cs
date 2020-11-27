using System;
using System.Linq;
using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    
    [TestClass]
    public class Day24Fixture
    {
        private Day24 _day24;

        [TestInitialize]
        public void Initialize()
        {
            _day24 = new Day24();
        }

        [TestMethod]
        public void Sample()
        {
            var input = new []
            {
                "1", "2", "3", "4", "5", "7", "8", "9", "10", "11"
            };

            _day24.Solve(input.Select(x => Convert.ToInt32(x)).ToArray());
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day24.Solve(FileReader.ReadFile("day24.txt").Select(x => Convert.ToInt32(x)).ToArray());
            Assert.AreEqual(10723906903, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = _day24.SolvePart2(FileReader.ReadFile("day24.txt").Select(x => Convert.ToInt32(x)).ToArray());
            Assert.AreEqual(74850409, result);
        }
    }
}

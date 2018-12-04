using Advent2016.Solutions;
using Advent2016.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day20Fixture
    {
        private Day20 _day20;

        [TestInitialize]
        public void Setup()
        {
            _day20 = new Day20();
        }

        private string[] _sample = {"5-8", "0-2", "4-7"};

        [TestMethod]
        public void SampleData()
        {
            var result = _day20.Solve(_sample);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day 20.txt");
            var result  = _day20.Solve(input);
            Assert.AreEqual(32259706, result);
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day 20.txt");
            var result = _day20.Solve(input, true);
            Assert.AreEqual(113, result);
        }

    }
}

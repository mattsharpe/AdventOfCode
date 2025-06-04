using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day06Fixture
    {
        private Day06 _day6 = new Day06();

        [TestInitialize]
        public void Setup()
        {
            _day6 = new Day06();
        }

        [TestMethod]
        public void SampleData()
        {
            Assert.AreEqual(5, _day6.Solve("0\t2\t7\t0"));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(12841, _day6.Solve(FileReader.ReadFile("day06.txt")[0]));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(4, _day6.Solve("0\t2\t7\t0", true));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(8038, _day6.Solve(FileReader.ReadFile("day06.txt")[0], true));
        }
    }
}

using Advent2015.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    
    [TestClass]
    public class Day20Fixture
    {
        private Day20 _day20;

        [TestInitialize]
        public void Initialize()
        {
            _day20 = new Day20();
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(786240, _day20.Solve(34000000));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(831600, _day20.Part2(34000000));
        }
    }
}

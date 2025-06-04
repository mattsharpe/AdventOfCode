using Advent2017.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day03Fixture
    {
        private readonly Day03 _day3 = new Day03();
        
        [DataRow(1, 0)]
        [DataRow(12, 3)]
        [DataRow(23, 2)]
        [DataRow(1024, 31)]
        [DataTestMethod]
        public void Samples(int square, int expected)
        {
            Assert.AreEqual(expected,_day3.Solve(square));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(430, _day3.Solve(312051));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(312453, _day3.Solve2(312051));
        }
    }
}

using Advent2017.Solutions;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day3Fixture
    {
        private readonly Day3 _day3 = new Day3();
        
        [TestCase(1, 0)]
        [TestCase(12, 3)]
        [TestCase(23, 2)]
        [TestCase(1024, 31)]
        public void Samples(int square, int expected)
        {
            Assert.AreEqual(expected,_day3.Solve(square));
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual(430, _day3.Solve(312051));
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual(312453, _day3.Solve2(312051));
        }
    }
}

using Advent2017.Solutions;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day17Fixture
    {
        private Day17 _day17 = new Day17();

        [SetUp]
        public void Setup()
        {
            _day17 = new Day17();
        }

        [TestCase(1, "0,1")]
        [TestCase(2, "0,2,1")]
        [TestCase(3, "0,2,3,1")]
        [TestCase(4, "0,2,4,3,1")]
        [TestCase(5, "0,5,2,4,3,1")]
        [TestCase(6, "0,5,2,4,3,6,1")]
        [TestCase(7, "0,5,7,2,4,3,6,1")]
        [TestCase(8, "0,5,7,2,4,3,8,6,1")]
        [TestCase(9, "0,9,5,7,2,4,3,8,6,1")]
        public void Sample(int repetitions, string expected)
        {
            Assert.AreEqual(expected, _day17.ReturnBufffer(3, repetitions));
        }

        public void SampleData()
        {
            Assert.AreEqual(638, _day17.Part1(3, 2017));
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual(1670, _day17.Part1(328, 2017));
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual(2316253, _day17.Part2(328, 50000000));
        }
    }
}

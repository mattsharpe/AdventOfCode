using System;
using System.Linq;
using Advent2017.Solutions;
using Advent2017.Utilities;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day5Fixture
    {
        private Day5 _day5 = new Day5();

        private int[] _sample;

        [SetUp]
        public void Setup()
        {
            _sample = new []{ 0, 3, 0, 1, -3};
        }

        [Test]
        public void Sample()
        {
            Assert.AreEqual(5, _day5.Solve(_sample));
        }

        [Test]
        public void Part1()
        {
            var input = FileReader.ReadFile("day5.txt").Select(x => Convert.ToInt32(x)).ToArray();
            Assert.AreEqual(355965, _day5.Solve(input));
        }

        [Test]
        public void Sample_Part2()
        {
            Assert.AreEqual(10, _day5.SolvePart2(_sample));
        }


        [Test]
        public void Part2()
        {
            var input = FileReader.ReadFile("day5.txt").Select(x => Convert.ToInt32(x)).ToArray();
            Assert.AreEqual(26948068, _day5.SolvePart2(input));
        }
    }
}

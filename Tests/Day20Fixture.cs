using System;
using System.Linq;
using AdventOfCode.Solutions;
using AdventOfCode.Utilities;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day20Fixture
    {
        private Day20 _day20;

        [SetUp]
        public void Setup()
        {
            _day20 = new Day20();
        }

        private string[] _sample = {"5-8", "0-2", "4-7"};

        [Test]
        public void SampleData()
        {
            var result = _day20.Solve(_sample);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Part1()
        {
            var input = FileReader.ReadFile("day 20.txt");
            var result  = _day20.Solve(input);
            Assert.AreEqual(32259706, result);
        }

        [Test]
        public void Part2()
        {
            var input = FileReader.ReadFile("day 20.txt");
            var result = _day20.Solve(input, true);
            Assert.AreEqual(113, result);
        }

    }
}

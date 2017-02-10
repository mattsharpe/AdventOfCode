using System;
using System.Linq;
using AdventOfCode.Solutions;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day19Fixture
    {
        private Day19 _day19;

        [SetUp]
        public void Setup()
        {
            _day19 = new Day19();
        }

        [Test]
        public void SampleData()
        {
            int result = _day19.Simulate(5);
            Assert.AreEqual(3,result);
        }

        [Test]
        public void Part1()
        {
            int result = _day19.Simulate(3018458);
            Assert.AreEqual(1842613, result);
        }

        [Test]
        public void Pattern()
        {
            for (int i = 1; i < 101; i++)
            {
                _day19 = new Day19();
                Console.WriteLine(_day19.Simulate(i));
            }
        }
    }
}

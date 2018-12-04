using System;
using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day19Fixture
    {
        private Day19 _day19;

        [TestInitialize]
        public void Setup()
        {
            _day19 = new Day19();
        }

        [TestMethod]
        public void SampleData()
        {
            int result = _day19.Simulate(5);
            Assert.AreEqual(3,result);
        }

        [TestMethod]
        public void Part1()
        {
            int result = _day19.Simulate(3018458);
            Assert.AreEqual(1842613, result);
        }

        [TestMethod]
        public void Pattern()
        {
            for (int i = 1; i < 101; i++)
            {
                _day19 = new Day19();
                Console.WriteLine(_day19.Simulate(i));
            }
        }

        [TestMethod]
        public void Part2Sample()
        {
            var result = _day19.Part2(5);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void Part2()
        {
            var result = _day19.Part2(3018458);
            Assert.AreEqual(result, 1424135);
        }
    }
}

using System;
using System.Linq;
using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day17Fixture
    {
        private Day17 _day17;

        [TestInitialize]
        public void Initialize() => _day17 = new Day17();

        [TestMethod]
        public void EggNogBatchingSample()
        {
            var containers = new[] { 20, 15, 10, 5, 5 };
            var amount = 25;
            Assert.AreEqual(4, _day17.FillContainers(containers, amount));
        }

        [TestMethod]
        public void EggNogBatchingPart1()
        {
            var containers = FileReader.ReadFile("day17.txt").Select(x=>Convert.ToInt32(x)).ToArray();
            var amount = 150;
            
            Assert.AreEqual(654, _day17.FillContainers(containers, amount));
        }

        [TestMethod]
        public void MinimumNumberOfContainersSample()
        {
            var containers = new[] { 20, 15, 10, 5, 5 };
            var amount = 25;
            
            Assert.AreEqual(3, _day17.MinimumNumberOfContainers(containers, amount));
        }

        [TestMethod]
        public void MinimumNumberOfContainersPart2()
        {
            var containers = FileReader.ReadFile("day17.txt").Select(x=>Convert.ToInt32(x)).ToArray();
            var amount = 150;
            
            Assert.AreEqual(57, _day17.MinimumNumberOfContainers(containers, amount));
        }
    }
}

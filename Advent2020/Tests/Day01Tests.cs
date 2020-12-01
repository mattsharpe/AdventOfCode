using System;
using System.IO;
using System.Linq;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day01Tests
    {
        private Day01 _day01;
        private int[] _sample;
        private int[] _input;

        [TestInitialize]
        public void Initialize()
        {
            _day01 = new Day01();
            _sample = new[] {1721, 979, 366, 299, 675, 1456};
            _input = File.ReadAllLines("Input/Day01.txt").Select(x => Convert.ToInt32(x)).ToArray();
        }

        [TestMethod]
        public void Sample()
        {
            var result = _day01.ProductOfSum(_sample);
            Assert.AreEqual(514579, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day01.ProductOfSum(_input);

            Assert.AreEqual(471019, result);
        }

        [TestMethod]
        public void Part2Sample()
        {
            var result = _day01.GroupOfThree(_sample);

            Assert.AreEqual(241861950, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = _day01.GroupOfThree(_input);

            Assert.AreEqual(103927824, result);
        }
    }


}
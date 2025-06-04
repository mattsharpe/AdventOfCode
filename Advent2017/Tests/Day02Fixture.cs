using System;
using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day02Fixture
    {
        private Day02 _day2 = new Day02();

        [TestMethod]
        public void SampleData()
        {
            string[] input =
            {
                "5\t1\t9\t5",
                "7\t5\t3",
                "2\t4\t6\t8"
            };

            Assert.AreEqual(18, _day2.Solve(input));
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day02.txt");
            Assert.AreEqual(47136, _day2.Solve(input));
        }

        [TestMethod]
        public void SampleData2()
        {
            string[] input =
            {
                "5\t9\t2\t8",
                "9\t4\t7\t3",
                "3\t8\t6\t5"
            };

            Assert.AreEqual(9, _day2.Solve2(input));
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day02.txt");
            Assert.AreEqual(250, _day2.Solve2(input));
        }
    }
}

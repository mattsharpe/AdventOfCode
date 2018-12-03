using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day2Fixture
    {
        private Day2 _day2 = new Day2();

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
            var input = FileReader.ReadFile("day2.txt");
            Console.WriteLine(_day2.Solve(input));
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
            var input = FileReader.ReadFile("day2.txt");
            Console.WriteLine(_day2.Solve2(input));
        }
    }
}

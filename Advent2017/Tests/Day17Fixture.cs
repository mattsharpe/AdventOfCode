using Advent2017.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day17Fixture
    {
        private Day17 _day17 = new Day17();

        [TestInitialize]
        public void Setup()
        {
            _day17 = new Day17();
        }

        [DataRow(1, "0,1")]
        [DataRow(2, "0,2,1")]
        [DataRow(3, "0,2,3,1")]
        [DataRow(4, "0,2,4,3,1")]
        [DataRow(5, "0,5,2,4,3,1")]
        [DataRow(6, "0,5,2,4,3,6,1")]
        [DataRow(7, "0,5,7,2,4,3,6,1")]
        [DataRow(8, "0,5,7,2,4,3,8,6,1")]
        [DataRow(9, "0,9,5,7,2,4,3,8,6,1")]
        [DataTestMethod]
        public void Sample(int repetitions, string expected)
        {
            Assert.AreEqual(expected, _day17.ReturnBufffer(3, repetitions));
        }

        public void SampleData()
        {
            Assert.AreEqual(638, _day17.Part1(3, 2017));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(1670, _day17.Part1(328, 2017));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(2316253, _day17.Part2(328, 50000000));
        }
    }
}

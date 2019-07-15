using Advent2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day14Tests
    {
        private Day14 _day14;

        [TestInitialize]
        public void Setup()
        {
            _day14 = new Day14();
        }

        [TestMethod]
        [DataRow(9, "5158916779")]
        [DataRow(5, "0124515891")]
        [DataRow(18, "9251071085")]
        [DataRow(2018, "5941429882")]
        public void TestData(int input, string expected)
        {
            Assert.AreEqual(expected, _day14.GetNext10(input));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual("1617111014", _day14.GetNext10(681901));
        }
}
}

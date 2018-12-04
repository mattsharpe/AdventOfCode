using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day16Fixture
    {
        private Day16 _day16;

        [TestInitialize]
        public void Setup()
        {
            _day16 = new Day16();
        }

        [TestMethod]
        public void RandomData()
        {
            Assert.AreEqual("100",_day16.RandomData("1"));
            Assert.AreEqual("001",_day16.RandomData("0"));
            Assert.AreEqual("11111000000", _day16.RandomData("11111"));
            Assert.AreEqual("1111000010100101011110000", _day16.RandomData("111100001010"));
        }

        [TestMethod]
        public void Checksum()
        {
            var result = _day16.Checksum("110010110100");
            Assert.AreEqual("100", result);
        }

        [TestMethod]
        public void SampleData()
        {
            var target = 20;
            var input = "10000";

            string checksum =_day16.Part1(target, input);
            Assert.AreEqual("01100", checksum);
        }

        [TestMethod]
        public void Part1()
        {
            var target = 272;
            var input = "11011110011011101";

            string checksum =_day16.Part1(target, input);
            Assert.AreEqual("00000100100001100", checksum);
        }

        [TestMethod]
        public void Part2()
        {
            var target = 35651584;
            var input = "11011110011011101";

            string checksum =_day16.Part1(target, input);
            Assert.AreEqual("00011010100010010", checksum);
        }

    }
}

using Advent2017.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day14Fixture
    {
        private Day14 _day14 = new Day14();

        [TestMethod]
        public void Sample()
        {
            _day14.BuildGrid("flqrgnkx");
            Assert.AreEqual(8108, _day14.UsedSquares());
        }

        [DataRow("0","0000")]
        [DataRow("1","0001")]
        [DataRow("2","0010")]
        [DataRow("3","0011")]
        [DataRow("4","0100")]
        [DataRow("5","0101")]
        [DataRow("6","0110")]
        [DataRow("7","0111")]
        [DataRow("8","1000")]
        [DataRow("9","1001")]
        [DataRow("A","1010")]
        [DataRow("B","1011")]
        [DataRow("C","1100")]
        [DataRow("D","1101")]
        [DataRow("E","1110")]
        [DataRow("F","1111")]
        [DataRow("a0c2017", "1010000011000010000000010111")]
        [DataTestMethod]
        public void HexToBin(string hex, string binary)
        {
            Assert.AreEqual(binary, _day14.HexToBinary(hex));
        }

        [TestMethod]
        public void Part1()
        {
            _day14.BuildGrid("hfdlxzhv");
            Assert.AreEqual(8230, _day14.UsedSquares());
        }

        [TestMethod]
        public void Part2_Sample()
        {
            _day14.BuildGrid("flqrgnkx");
            Assert.AreEqual(1242, _day14.CountRegions());
        }

        [TestMethod]
        public void Part2()
        {
            _day14.BuildGrid("hfdlxzhv");
            Assert.AreEqual(1103, _day14.CountRegions());
        }
    }
}

using Advent2017.Solutions;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day14Fixture
    {
        private Day14 _day14 = new Day14();

        [Test]
        public void Sample()
        {
            _day14.BuildGrid("flqrgnkx");
            Assert.AreEqual(8108, _day14.UsedSquares());
        }

        [TestCase("0","0000")]
        [TestCase("1","0001")]
        [TestCase("2","0010")]
        [TestCase("3","0011")]
        [TestCase("4","0100")]
        [TestCase("5","0101")]
        [TestCase("6","0110")]
        [TestCase("7","0111")]
        [TestCase("8","1000")]
        [TestCase("9","1001")]
        [TestCase("A","1010")]
        [TestCase("B","1011")]
        [TestCase("C","1100")]
        [TestCase("D","1101")]
        [TestCase("E","1110")]
        [TestCase("F","1111")]
        [TestCase("a0c2017", "1010000011000010000000010111")]
        public void HexToBin(string hex, string binary)
        {
            Assert.AreEqual(binary, _day14.HexToBinary(hex));
        }

        [Test]
        public void Part1()
        {
            _day14.BuildGrid("hfdlxzhv");
            Assert.AreEqual(8230, _day14.UsedSquares());
        }

        [Test]
        public void Part2_Sample()
        {
            _day14.BuildGrid("flqrgnkx");
            Assert.AreEqual(1242, _day14.CountRegions());
        }

        [Test]
        public void Part2()
        {
            _day14.BuildGrid("hfdlxzhv");
            Assert.AreEqual(1103, _day14.CountRegions());
        }
    }
}

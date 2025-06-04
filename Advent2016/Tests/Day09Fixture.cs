using System.Linq;
using Advent2016.Solutions;
using Advent2016.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day09Fixture
    {
        private Day09 _day9;

        [TestInitialize]
        public void Setup()
        {
            _day9 = new Day09();
        }

        [TestMethod]
        public void Decompress_1()
        {
            string result = _day9.Decompress("ADVENT");
            Assert.AreEqual("ADVENT", result);
        }

        [TestMethod]
        public void Decompress_2()
        {
            string result = _day9.Decompress("A(1x5)BC");
            Assert.AreEqual("ABBBBBC", result);
        }

        [TestMethod]
        public void Decompress_3()
        {
            string result = _day9.Decompress("(3x3)XYZ");
            Assert.AreEqual("XYZXYZXYZ", result);
        }

        [TestMethod]
        public void Decompress_4()
        {
            string result = _day9.Decompress("A(2x2)BCD(2x2)EFG");
            Assert.AreEqual("ABCBCDEFEFG", result);
        }

        [TestMethod]
        public void Decompress_5()
        {
            string result = _day9.Decompress("(6x1)(1x3)A");
            Assert.AreEqual("(1x3)A", result);
        }

        [TestMethod]
        public void Decompress_6()
        {
            string result = _day9.Decompress("(6x1)(1x3)A");
            Assert.AreEqual("(1x3)A", result);
        }

        [TestMethod]
        public void Decompress_7()
        {
            string result = _day9.Decompress("X(8x2)(3x3)ABCY");
            Assert.AreEqual("X(3x3)ABC(3x3)ABCY", result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day9.Part1();
            Assert.AreEqual(70186, result.Length);
        }


        [TestMethod]
        public void RecursiveDecompress()
        {
            var result = _day9.RecursiveDecompress("ADVENT");
            Assert.AreEqual("ADVENT".Length, result);
        }

        [TestMethod]
        public void RecursiveDecompress1()
        {
            var result = _day9.RecursiveDecompress("(3x3)XYZ");
            Assert.AreEqual("XYZXYZXYZ".Length, result);
        }

        [TestMethod]
        public void RecursiveDecompress2()
        {
            var result = _day9.RecursiveDecompress("X(8x2)(3x3)ABCY");
            Assert.AreEqual("XABCABCABCABCABCABCY".Length, result);
        }

        [TestMethod]
        public void RecursiveDecompress3()
        {
            var result = _day9.RecursiveDecompress("(27x12)(20x12)(13x14)(7x10)(1x12)A");
            Assert.AreEqual(241920, result);
        }

        [TestMethod]
        public void RecursiveDecompress4()
        {
            var result = _day9.RecursiveDecompress("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN");
            Assert.AreEqual(445, result);
        }

        [TestMethod]
        public void Part2()
        {
            var file = FileReader.ReadFile("day09 compressed file.txt");
            var result = _day9.RecursiveDecompress(file.First());
            Assert.AreEqual(10915059201, result);
        }
    }
}

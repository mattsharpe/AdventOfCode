using AdventOfCode.Solutions;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day9Fixture
    {
        private Day9 _day9;

        [SetUp]
        public void Setup()
        {
            _day9 = new Day9();
        }

        [Test]
        public void Decompress_1()
        {
            string result = _day9.Decompress("ADVENT");
            Assert.AreEqual("ADVENT", result);
        }

        [Test]
        public void Decompress_2()
        {
            string result = _day9.Decompress("A(1x5)BC");
            Assert.AreEqual("ABBBBBC", result);
        }

        [Test]
        public void Decompress_3()
        {
            string result = _day9.Decompress("(3x3)XYZ");
            Assert.AreEqual("XYZXYZXYZ", result);
        }

        [Test]
        public void Decompress_4()
        {
            string result = _day9.Decompress("A(2x2)BCD(2x2)EFG");
            Assert.AreEqual("ABCBCDEFEFG", result);
        }

        [Test]
        public void Decompress_5()
        {
            string result = _day9.Decompress("(6x1)(1x3)A");
            Assert.AreEqual("(1x3)A", result);
        }

        [Test]
        public void Decompress_6()
        {
            string result = _day9.Decompress("(6x1)(1x3)A");
            Assert.AreEqual("(1x3)A", result);
        }

        [Test]
        public void Decompress_7()
        {
            string result = _day9.Decompress("X(8x2)(3x3)ABCY");
            Assert.AreEqual("X(3x3)ABC(3x3)ABCY", result);
        }

        [Test]
        public void Part1()
        {
            var result = _day9.Part1();
            Assert.AreEqual(70186, result.Length);
        }
    }
}

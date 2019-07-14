using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day02Tests
    {
        private Day02 _day02;

        [TestInitialize]
        public void Setup()
        {
            _day02 = new Day02();
        }

        [DataTestMethod]
        [DataRow("abcdef", 0, 0)]
        [DataRow("bababc", 1, 1)]
        [DataRow("abbcde", 1, 0)]
        [DataRow("abcccd", 0, 1)]
        [DataRow("aabcdd", 1, 0)]
        [DataRow("abcdee", 1, 0)]
        [DataRow("ababab", 0, 1)]
        public void SampleData(string input, int doubleLetters, int tripleLetters)
        {
            _day02.ProcessBox(input);
            Assert.AreEqual(doubleLetters, _day02.DoubleLetters);
            Assert.AreEqual(tripleLetters, _day02.TripleLetters);
        }

        [TestMethod]
        public void Part1()
        {
            var boxes = FileReader.ReadFile("day02.txt");
            foreach (var box in boxes)
            {
                _day02.ProcessBox(box);
            }

            var checksum = _day02.DoubleLetters * _day02.TripleLetters;
            Assert.AreEqual(6225, checksum);
        }

        [TestMethod]
        public void Part2_Sample()
        {
            var boxes = new[] {"abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz"};
            Assert.AreEqual("fgij",_day02.FindCommonLetters(boxes));
        }

        [TestMethod]
        public void Part2()
        {
            var boxes = FileReader.ReadFile("day02.txt");
            Assert.AreEqual("revtaubfniyhsgxdoajwkqilp", _day02.FindCommonLetters(boxes));
        }
    }
}

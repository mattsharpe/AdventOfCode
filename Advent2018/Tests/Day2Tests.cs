using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day2Tests
    {
        private Day2 _day2;

        [TestInitialize]
        public void Setup()
        {
            _day2 = new Day2();
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
            _day2.ProcessBox(input);
            Assert.AreEqual(doubleLetters, _day2.DoubleLetters);
            Assert.AreEqual(tripleLetters, _day2.TripleLetters);
        }

        [TestMethod]
        public void Part1()
        {
            var boxes = FileReader.ReadFile("Day2Input.txt");
            foreach (var box in boxes)
            {
                _day2.ProcessBox(box);
            }

            var checksum = _day2.DoubleLetters * _day2.TripleLetters;
            Assert.AreEqual(6225, checksum);
        }

        [TestMethod]
        public void Part2_Sample()
        {
            var boxes = new[] {"abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz"};
            Assert.AreEqual("fgij",_day2.FindCommonLetters(boxes));
        }

        [TestMethod]
        public void Part2()
        {
            var boxes = FileReader.ReadFile("Day2Input.txt");
            Assert.AreEqual("revtaubfniyhsgxdoajwkqilp", _day2.FindCommonLetters(boxes));
        }
    }
}

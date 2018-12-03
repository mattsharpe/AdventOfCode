using System;
using System.Xml.Schema;
using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day8Fixture
    {
        private Day8 _day8 = new Day8();
        
        [DataRow("\"\"", 2, 0)]
        [DataRow("\"abc\"", 5, 3)]
        [DataRow("\"aaa\\\"aaa\"", 10, 7)]
        [DataRow("\"\\x27\"", 6, 1)]
        public void Sample(string input, int lengthOfCode, int lengthOfString)
        {
            var result = _day8.DecodedLength(input);
            Assert.AreEqual(lengthOfString, result);
            Assert.AreEqual(lengthOfCode, input.Length);
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day8.txt");
            Assert.AreEqual(1342, _day8.Part1(input));
        }

        [DataRow("\"\"", 6)]
        [DataRow("\"abc\"", 9)]
        [DataRow("\"aaa\\\"aaa\"", 16)]
        [DataRow("\"\\x27\"", 11)]
        public void Sample2(string input, int lengthEncoded)
        {
            var result = _day8.EncodedLength(input);
            Assert.AreEqual(lengthEncoded, result);
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day8.txt");
            Assert.AreEqual(2074, _day8.Part2(input));
        }
    }
}

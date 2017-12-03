using System;
using System.Xml.Schema;
using Advent2015.Solutions;
using Advent2015.Utilities;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    class Day8Fixture
    {
        private Day8 _day8 = new Day8();
        
        [TestCase("\"\"", 2, 0)]
        [TestCase("\"abc\"", 5, 3)]
        [TestCase("\"aaa\\\"aaa\"", 10, 7)]
        [TestCase("\"\\x27\"", 6, 1)]
        public void Sample(string input, int lengthOfCode, int lengthOfString)
        {
            var result = _day8.DecodedLength(input);
            Assert.AreEqual(lengthOfString, result);
            Assert.AreEqual(lengthOfCode, input.Length);
        }

        [Test]
        public void Part1()
        {
            var input = FileReader.ReadFile("day8.txt");
            Assert.AreEqual(1342, _day8.Part1(input));
        }

        [TestCase("\"\"", 6)]
        [TestCase("\"abc\"", 9)]
        [TestCase("\"aaa\\\"aaa\"", 16)]
        [TestCase("\"\\x27\"", 11)]
        public void Sample2(string input, int lengthEncoded)
        {
            var result = _day8.EncodedLength(input);
            Assert.AreEqual(lengthEncoded, result);
        }

        [Test]
        public void Part2()
        {
            var input = FileReader.ReadFile("day8.txt");
            Assert.AreEqual(2074, _day8.Part2(input));
        }
    }
}

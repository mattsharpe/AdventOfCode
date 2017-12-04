using System.Linq;
using Advent2017.Solutions;
using Advent2017.Utilities;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day4Fixture
    {
        private Day4 _day4 = new Day4();

        [TestCase("aa bb cc dd ee", true)]
        [TestCase("aa bb cc dd aa", false)]
        [TestCase("aa bb cc dd aaa", true)]
        public void IsValid_Sample(string input, bool expected)
        {
            Assert.AreEqual(expected, _day4.IsValid(input));
        }

        [Test]
        public void Part1()
        {
            var input = FileReader.ReadFile("day4.txt");
            var result = input.Count(_day4.IsValid);
            Assert.AreEqual(477, result);
        }

        [TestCase("abcde fghij", true)]
        [TestCase("abcde xyz ecdab", false)]
        [TestCase("a ab abc abd abf abj", true)]
        [TestCase("iiii oiii ooii oooi oooo", true)]
        [TestCase("oiii ioii iioi iiio", false)]
        public void IsValid_Anagram(string input, bool expected)
        {
            Assert.AreEqual(expected, _day4.IsValidAnagram(input));
        }

        [Test]
        public void Part2()
        {
            var input = FileReader.ReadFile("day4.txt");
            var result = input.Count(_day4.IsValidAnagram);
            Assert.AreEqual(167, result);
        }
    }
}

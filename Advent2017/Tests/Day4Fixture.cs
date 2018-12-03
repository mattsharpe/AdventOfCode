using System.Linq;
using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day4Fixture
    {
        private Day4 _day4 = new Day4();

        [DataRow("aa bb cc dd ee", true)]
        [DataRow("aa bb cc dd aa", false)]
        [DataRow("aa bb cc dd aaa", true)]
        [DataTestMethod]
        public void IsValid_Sample(string input, bool expected)
        {
            Assert.AreEqual(expected, _day4.IsValid(input));
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day4.txt");
            var result = input.Count(_day4.IsValid);
            Assert.AreEqual(477, result);
        }

        [DataRow("abcde fghij", true)]
        [DataRow("abcde xyz ecdab", false)]
        [DataRow("a ab abc abd abf abj", true)]
        [DataRow("iiii oiii ooii oooi oooo", true)]
        [DataRow("oiii ioii iioi iiio", false)]
        [DataTestMethod]
        public void IsValid_Anagram(string input, bool expected)
        {
            Assert.AreEqual(expected, _day4.IsValidAnagram(input));
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day4.txt");
            var result = input.Count(_day4.IsValidAnagram);
            Assert.AreEqual(167, result);
        }
    }
}

using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day9Fixture
    {
        private Day9 _day9 = new Day9();

        [DataRow("{}", 1)]
        [DataRow("{{{}}}", 3)]
        [DataRow("{{},{}}", 3)]
        [DataRow("{{{},{},{{}}}}", 6)]
        [DataRow("{<{},{},{{}}>}", 1)]
        [DataRow("{<a>,<a>,<a>,<a>}", 1)]
        [DataRow("{{<a>},{<a>},{<a>},{<a>}}", 5)]
        [DataRow("{{<!>},{<!>},{<!>},{<a>}}", 2)]
        [DataTestMethod]
        public void CountGroups(string input, int count)
        {
            Assert.AreEqual(count, _day9.GetCountOfGroups(input));
        }

        [DataRow("{}",1)]
        [DataRow("{{{}}}", 6)]
        [DataRow("{{},{}}", 5)]
        [DataRow("{{{},{},{{}}}}", 16)]
        [DataRow("{<a>,<a>,<a>,<a>}", 1)]
        [DataRow("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [DataRow("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [DataRow("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        [DataTestMethod]
        public void GetScore(string input, int expected)
        {
            Assert.AreEqual(expected, _day9.GetTotalScore(input));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(12505, _day9.GetTotalScore(FileReader.ReadFile("day9.txt")[0]));
        }

        [DataRow("<>", 0)]
        [DataRow("<random characters>", 17)]
        [DataRow("<<<<>", 3)]
        [DataRow("<{!>}>", 2)]
        [DataRow("<!!>", 0)]
        [DataRow("<{o\"i!a,<{i<a>", 10)]
        [DataTestMethod]
        public void RemovedGarbage(string input, int expected)
        {
            Assert.AreEqual(expected, _day9.SizeOfGarbage(input));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(6671, _day9.SizeOfGarbage(FileReader.ReadFile("day9.txt")[0]));
        }
    }
}

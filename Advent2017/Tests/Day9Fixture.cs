using Advent2017.Solutions;
using Advent2017.Utilities;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day9Fixture
    {
        private Day9 _day9 = new Day9();

        [TestCase("{}", 1)]
        [TestCase("{{{}}}", 3)]
        [TestCase("{{},{}}", 3)]
        [TestCase("{{{},{},{{}}}}", 6)]
        [TestCase("{<{},{},{{}}>}", 1)]
        [TestCase("{<a>,<a>,<a>,<a>}", 1)]
        [TestCase("{{<a>},{<a>},{<a>},{<a>}}", 5)]
        [TestCase("{{<!>},{<!>},{<!>},{<a>}}", 2)]
        public void CountGroups(string input, int count)
        {
            Assert.AreEqual(count, _day9.GetCountOfGroups(input));
        }

        [TestCase("{}",1)]
        [TestCase("{{{}}}", 6)]
        [TestCase("{{},{}}", 5)]
        [TestCase("{{{},{},{{}}}}", 16)]
        [TestCase("{<a>,<a>,<a>,<a>}", 1)]
        [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void GetScore(string input, int expected)
        {
            Assert.AreEqual(expected, _day9.GetTotalScore(input));
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual(12505, _day9.GetTotalScore(FileReader.ReadFile("day9.txt")[0]));
        }

        [TestCase("<>", 0)]
        [TestCase("<random characters>", 17)]
        [TestCase("<<<<>", 3)]
        [TestCase("<{!>}>", 2)]
        [TestCase("<!!>", 0)]
        [TestCase("<{o\"i!a,<{i<a>", 10)]
        public void RemovedGarbage(string input, int expected)
        {
            Assert.AreEqual(expected, _day9.SizeOfGarbage(input));
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual(6671, _day9.SizeOfGarbage(FileReader.ReadFile("day9.txt")[0]));
        }
    }
}

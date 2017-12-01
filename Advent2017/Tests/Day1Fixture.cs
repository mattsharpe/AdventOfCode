using Advent2017.Solutions;
using Advent2017.Utilities;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day1Fixture
    {
        private Day1 _day1 = new Day1();
        // 1122 produces a sum of 3 (1 + 2) because the first digit (1) matches the second digit and the third digit (2) matches the fourth digit.
        // 1111 produces 4 because each digit(all 1) matches the next.
        // 1234 produces 0 because no digit matches the next.
        // 91212129 produces 9 because the only digit that matches the next one is the last digit, 9.

        [TestCase("1122",3)]
        [TestCase("1111", 4)]
        [TestCase("1234", 0)]
        [TestCase("91212129", 9)]
        public void SampleData(string sequence, int expected)
        {
            var result = _day1.GetSum(sequence);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Part1()
        {
            var input = FileReader.ReadFile("day1.txt");
            Assert.AreEqual(1223, _day1.GetSum(input[0]));
        }

        [TestCase("1212", 6)]
        [TestCase("1221", 0)]
        [TestCase("123425", 4)]
        [TestCase("123123", 12)]
        [TestCase("12131415", 4)]
        public void SampleDataPart2(string input, int expected)
        {
            var result = _day1.GetSum2(input);
            Assert.AreEqual(expected,result);
        }

        [Test]
        public void Part2()
        {
            var input = FileReader.ReadFile("day1.txt");
            Assert.AreEqual(1284, _day1.GetSum2(input[0]));
        }
    }
}

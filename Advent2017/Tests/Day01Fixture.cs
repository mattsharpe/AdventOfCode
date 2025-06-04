using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day01Fixture
    {
        private Day01 _day1 = new Day01();
        // 1122 produces a sum of 3 (1 + 2) because the first digit (1) matches the second digit and the third digit (2) matches the fourth digit.
        // 1111 produces 4 because each digit(all 1) matches the next.
        // 1234 produces 0 because no digit matches the next.
        // 91212129 produces 9 because the only digit that matches the next one is the last digit, 9.

        [DataRow("1122",3)]
        [DataRow("1111", 4)]
        [DataRow("1234", 0)]
        [DataRow("91212129", 9)]
        [DataTestMethod]
        public void SampleData(string sequence, int expected)
        {
            var result = _day1.GetSum(sequence);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day01.txt");
            Assert.AreEqual(1223, _day1.GetSum(input[0]));
        }

        [DataRow("1212", 6)]
        [DataRow("1221", 0)]
        [DataRow("123425", 4)]
        [DataRow("123123", 12)]
        [DataRow("12131415", 4)]
        [DataTestMethod]
        public void SampleDataPart2(string input, int expected)
        {
            var result = _day1.GetSum2(input);
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day01.txt");
            Assert.AreEqual(1284, _day1.GetSum2(input[0]));
        }
    }
}

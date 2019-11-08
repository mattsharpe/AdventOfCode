using Advent2015.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day11Fixture
    {
        private Day11 _day11;

        [TestInitialize]
        public void TestInitialize() => _day11 = new Day11();

        [TestMethod]
        public void FailsSecondRequirement()
        {
            Assert.IsFalse(_day11.IsValid("hijklmmn"));
        }

        [TestMethod]
        public void FailsFirstRequirement()
        {
            Assert.IsFalse(_day11.IsValid("abbceffg"));
        }

        [TestMethod]
        public void FailsThirdRequirement()
        {
            Assert.IsFalse(_day11.IsValid("abbcegjk"));
        }

        [TestMethod]
        public void FailsThirdRequirementWithRepeats()
        {
            Assert.IsFalse(_day11.IsValid("abbcebbg"));
        }

        [TestMethod]
        public void NextPassword()
        {
            var result = _day11.NextPassword("abcdefgh");
            Assert.AreEqual("abcdffaa", result);
        }

        [TestMethod]
        public void NextPassword2()
        {
            var result = _day11.NextPassword("ghijklmn");
            Assert.AreEqual("ghjaabcc", result);
        }

        [DataTestMethod]
        [DataRow("xx","xy")]
        [DataRow("xy","xz")]
        [DataRow("xy","xz")]
        [DataRow("xz","ya")]
        [DataRow("ya","yb")]
        [DataRow("abc","abd")]
        public void GenerateNextPassword(string input, string expected)
        {
            Assert.AreEqual(expected, _day11.GenerateNextPassword(input));
        }

        [TestMethod]
        public void NextPasswordPart1()
        {
            var result = _day11.NextPassword("vzbxkghb");
            Assert.AreEqual("vzbxxyzz",result);
        }

        [TestMethod]
        public void NextPasswordPart2()
        {
            var result = _day11.NextPassword(_day11.GenerateNextPassword("vzbxxyzz"));
            Assert.AreEqual("vzcaabcc",result);
        }
    }
}

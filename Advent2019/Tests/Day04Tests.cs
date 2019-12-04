using Advent2019.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day04Tests
    {
        private Day04 _day4;

        [TestInitialize] 
        public void Initialize() => _day4 = new Day04();

        [DataTestMethod]
        [DataRow(111111, true)]
        [DataRow(223450, false)]
        [DataRow(123789, false)]
        public void SamplePasswords(int password, bool valid)
        {
            Assert.AreEqual(valid, _day4.IsValid(password));
        }

        [TestMethod]
        public void PasswordsInRange()
        {
            var result = _day4.PasswordsInRange(168630, 718098);
            Assert.AreEqual(1686, result);
        }

        [DataTestMethod]
        [DataRow(112233, true)]
        [DataRow(123444, false)]
        [DataRow(111122, true)]
        public void SamplePasswordsPart2(int password, bool expected)
        {
            Assert.AreEqual(expected, _day4.TwoAdjacentDigitsNotPartOfLargerGroup(password));
        }

        [TestMethod]
        public void PasswordsInRangePart2()
        {
            var result = _day4.PasswordsInRange(168630, 718098, true);
            Assert.AreEqual(1145, result);
        }
    }
}
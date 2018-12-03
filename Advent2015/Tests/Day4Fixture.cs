using Advent2015.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day4Fixture
    {
        private Day4 _day4 = new Day4();

        [TestMethod]
        public void Sample1()
        {
            var result = _day4.MinimumNumberRequired("abcdef");
            Assert.AreEqual(609043, result);
        }

        [TestMethod]
        public void Sample2()
        {
            var result = _day4.MinimumNumberRequired("pqrstuv");
            Assert.AreEqual(1048970, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day4.MinimumNumberRequired("ckczppom");
            Assert.AreEqual(117946, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = _day4.MinimumNumberRequired("ckczppom", true);
            Assert.AreEqual(3938038, result);
        }
    }
}

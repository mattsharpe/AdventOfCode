using Advent2015.Solutions;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    public class Day4Fixture
    {
        private Day4 _day4 = new Day4();

        [Test]
        public void Sample1()
        {
            var result = _day4.MinimumNumberRequired("abcdef");
            Assert.AreEqual(609043, result);
        }

        [Test]
        public void Sample2()
        {
            var result = _day4.MinimumNumberRequired("pqrstuv");
            Assert.AreEqual(1048970, result);
        }

        [Test]
        public void Part1()
        {
            var result = _day4.MinimumNumberRequired("ckczppom");
            Assert.AreEqual(117946, result);
        }

        [Test]
        public void Part2()
        {
            var result = _day4.MinimumNumberRequired("ckczppom", true);
            Assert.AreEqual(3938038, result);
        }
    }
}

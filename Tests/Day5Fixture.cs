using Advent2016.Solutions;
using NUnit.Framework;

namespace Advent2016.Tests
{

    [TestFixture, Explicit]
    public class Day5Fixture
    {
        private Day5 _day5;


        [SetUp]
        public void Setup()
        {
            _day5 = new Day5();
        }

        [Test]
        public void SampleData()
        {
            var password = _day5.CalculatePassword("abc");
            Assert.AreEqual("18f47a30",password);
        }

        [Test]
        public void Part1()
        {
            var password = _day5.CalculatePassword("ugkcyxxp");
            Assert.AreEqual("d4cd2ee1", password);
        }

        [Test]
        public void Part2SampleData()
        {
            var password = _day5.CalculatePasswordWithOrder("abc");
            Assert.AreEqual("05ace8e3", password);
        }

        [Test]
        public void Part2()
        {
            var password = _day5.CalculatePasswordWithOrder("ugkcyxxp");
            Assert.AreEqual("f2c730e5", password);
        }
    }
}

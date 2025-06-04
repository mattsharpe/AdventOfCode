using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{

    [TestClass, Ignore]
    public class Day05Fixture
    {
        private Day05 _day5;


        [TestInitialize]
        public void Setup()
        {
            _day5 = new Day05();
        }

        [TestMethod]
        public void SampleData()
        {
            var password = _day5.CalculatePassword("abc");
            Assert.AreEqual("18f47a30",password);
        }

        [TestMethod]
        public void Part1()
        {
            var password = _day5.CalculatePassword("ugkcyxxp");
            Assert.AreEqual("d4cd2ee1", password);
        }

        [TestMethod]
        public void Part2SampleData()
        {
            var password = _day5.CalculatePasswordWithOrder("abc");
            Assert.AreEqual("05ace8e3", password);
        }

        [TestMethod]
        public void Part2()
        {
            var password = _day5.CalculatePasswordWithOrder("ugkcyxxp");
            Assert.AreEqual("f2c730e5", password);
        }
    }
}

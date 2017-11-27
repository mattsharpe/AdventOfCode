using Advent2015.Solutions;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    class Day1Fixture
    {

        private readonly Day1 _day1 = new Day1();

        [Test]
        public void SampleDataFloor0()
        {
            Assert.AreEqual(0, _day1.ParseInput("(())"));
            Assert.AreEqual(0, _day1.ParseInput("()()"));
        }

        [Test]
        public void SampleDataFloor3()
        {
            Assert.AreEqual(3, _day1.ParseInput("((("));
            Assert.AreEqual(3, _day1.ParseInput("(()(()("));
            Assert.AreEqual(3, _day1.ParseInput("))((((("));
        }

        [Test]
        public void SampleDataFloor_1()
        {
            Assert.AreEqual(-1, _day1.ParseInput("())"));
            Assert.AreEqual(-1, _day1.ParseInput("))("));
        }

        [Test]
        public void SampleDataFloor_3()
        {
            Assert.AreEqual(-3, _day1.ParseInput(")))"));
            Assert.AreEqual(-3, _day1.ParseInput(")())())"));
        }
    }
}

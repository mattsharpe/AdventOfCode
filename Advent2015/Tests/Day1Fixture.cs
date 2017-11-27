using Advent2015.Solutions;
using Advent2015.Utilities;
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

        [Test]
        public void SampleData()
        {
            var result = _day1.ParseInput(FileReader.ReadFile("day1.txt")[0]);
			Assert.AreEqual(138, result);
        }

        [Test]
        public void Part2()
        {
            var result = _day1.FindBasement(FileReader.ReadFile("day1.txt")[0]);
			Assert.AreEqual(1771, result);
        }
    }
}

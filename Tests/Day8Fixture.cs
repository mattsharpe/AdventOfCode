using AdventOfCode.Solutions;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day8Fixture
    {
        private Day8 _day8;

        [SetUp]
        public void Setup()
        {
            _day8 = new Day8();    
        }

        [Test]
        public void DisplayIsInitialisedToFalse()
        {
            Assert.AreEqual(0, _day8.ActivePixels);
        }

        [Test]
        public void ThreeByTwoRectangle()
        {
            _day8.Rectangle("rect 3x2");
            Assert.AreEqual(6, _day8.ActivePixels);
            _day8.PrintArray();
        }

        [Test]
        public void ThreeByThreeRectangle()
        {
            _day8.Rectangle("rect 3x3");
            Assert.AreEqual(9, _day8.ActivePixels);
            _day8.PrintArray();
        }
    }
}

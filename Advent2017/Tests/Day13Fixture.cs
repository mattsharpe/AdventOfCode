using Advent2017.Solutions;
using Advent2017.Utilities;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    public class Day13Fixture
    {
        private string[] _sample =
        {
            "0: 3",
            "1: 2",
            "4: 4",
            "6: 4"
        };

        private Day13 _day13 = new Day13();

        [Test]
        public void Sample()
        {
            Assert.AreEqual(24, _day13.CalculateSeverity(_sample));
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual(748, _day13.CalculateSeverity(FileReader.ReadFile("day13.txt")));
        }

        [Test]
        public void Part2_Sample()
        {
            Assert.AreEqual(10, _day13.CalculateDelay(_sample));
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual(3873662, _day13.CalculateDelay(FileReader.ReadFile("day13.txt")));
        }
    }
}

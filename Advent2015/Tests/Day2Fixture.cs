using Advent2015.Solutions;
using Advent2015.Utilities;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    public class Day2Fixture
    {
        private readonly Day2 _day2 = new Day2();

        [Test]
        public void SampleData()
        {
            var result = _day2.AmountOfWrappingPaperRequired(new[] {"2x3x4"});
            Assert.AreEqual(58, result);
        }

        [Test]
        public void SampleData2()
        {
            var result = _day2.AmountOfWrappingPaperRequired(new[] { "1x1x10" });
            Assert.AreEqual(43, result);
        }

        [Test]
        public void SampleDataSummed()
        {
            var result = _day2.AmountOfWrappingPaperRequired(new[] { "2x3x4", "1x1x10" });
            Assert.AreEqual(101, result);
        }

        [Test]
        public void Part1()
        {
            var result = _day2.AmountOfWrappingPaperRequired(FileReader.ReadFile("day2.txt"));
            Assert.AreEqual(1586300, result);

        }

        [Test]
        public void RibbonRequiredSample()
        {
            var result = _day2.AmountOfRibbonRequired(new []{"2x3x4"});
            Assert.AreEqual(34, result);
        }

        [Test]
        public void RibbonRequiredSample2()
        {
            var result = _day2.AmountOfRibbonRequired(new []{"1x1x10"});
            Assert.AreEqual(14, result);
        }

        [Test]
        public void Part2()
        {
            var result = _day2.AmountOfRibbonRequired(FileReader.ReadFile("day2.txt"));
            Assert.AreEqual(3737498, result);
        }
    }
}

using System.Text;
using AdventOfCode2016.Solutions;
using NUnit.Framework;

namespace AdventOfCode2016.Tests
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

            var display = _day8.ToString();
            var sb = new StringBuilder();

            sb.AppendLine("###...............................................");
            sb.AppendLine("###...............................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");

            Assert.AreEqual(sb.ToString(), display);
        }

        [Test]
        public void ThreeByThreeRectangle()
        {
            _day8.Rectangle("rect 3x3");
            Assert.AreEqual(9, _day8.ActivePixels);

            var display = _day8.ToString();
            var sb = new StringBuilder();

            sb.AppendLine("###...............................................");
            sb.AppendLine("###...............................................");
            sb.AppendLine("###...............................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");

            Assert.AreEqual(sb.ToString(),display);
        }

        [Test]
        public void ThirtyFiveByOneRectangle()
        {
            _day8.Rectangle("rect 35x1");
            Assert.AreEqual(35, _day8.ActivePixels);

            var display = _day8.ToString();
            var sb = new StringBuilder();

            sb.AppendLine("###################################...............");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");

            Assert.AreEqual(sb.ToString(),display);
        }

        [Test]
        public void Column1X1()
        {
            _day8.ProcessInstruction("rect 3x3");

            var display = _day8.ToString();
            var sb = new StringBuilder();

            _day8.ProcessInstruction("rotate column x=1 by 1");
            sb.Clear();

            sb.AppendLine("#.#...............................................");
            sb.AppendLine("###...............................................");
            sb.AppendLine("###...............................................");
            sb.AppendLine(".#................................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");

            Assert.AreEqual(sb.ToString(), _day8.ToString());
        }

        [Test]
        public void Row1X1()
        {
            _day8.ProcessInstruction("rect 3x3");

            var sb = new StringBuilder();

            _day8.ProcessInstruction("rotate row y=1 by 1");
            sb.Clear();

            sb.AppendLine("###...............................................");
            sb.AppendLine(".###..............................................");
            sb.AppendLine("###...............................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");
            sb.AppendLine("..................................................");

            Assert.AreEqual(sb.ToString(), _day8.ToString());
        }

        [Test]
        public void TestData()
        {
            _day8.Part1();
            Assert.AreEqual(116,_day8.ActivePixels);
        }
    }
}

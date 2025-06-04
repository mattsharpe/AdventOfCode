using System.Text;
using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class tDay08Fixture
    {
        private Day08 _day8;

        [TestInitialize]
        public void Setup()
        {
            _day8 = new Day08();    
        }

        [TestMethod]
        public void DisplayIsInitialisedToFalse()
        {
            Assert.AreEqual(0, _day8.ActivePixels);
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void TestData()
        {
            _day8.Part1();
            Assert.AreEqual(116,_day8.ActivePixels);
        }
    }
}

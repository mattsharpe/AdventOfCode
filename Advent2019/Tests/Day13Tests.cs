using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day13Tests
    {
        private Day13 _day13 = new Day13();

        [TestInitialize]
        public void Initialize() => _day13 = new Day13();

        [TestMethod]
        public void RunGame()
        {
            var program = FileReader.ReadFile("day13.txt").First();
            Assert.AreEqual(226, _day13.CountNumberOfBlocks(program));
        }
    }
}

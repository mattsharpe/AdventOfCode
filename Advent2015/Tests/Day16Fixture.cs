using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day16Fixture
    {
        private Day16 _day16;

        [TestInitialize] 
        public void Initialize() => _day16 = new Day16();

        [TestMethod]
        public void FindAuntSue()
        {
            var sueId = _day16.FilterAuntSue(FileReader.ReadFile("day16.txt"));
            Assert.AreEqual(373, sueId);
        }

        [TestMethod]
        public void FindAuntSuePart2()
        {
            var sueId = _day16.FilterAuntSue(FileReader.ReadFile("day16.txt"), true);
            Assert.AreEqual(260, sueId);
        }

    }
}

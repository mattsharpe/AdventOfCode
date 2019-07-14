using System.Linq;
using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day05Tests
    {
        private Day05 _day05;

        [TestInitialize]
        public void Setup()
        {
            _day05 = new Day05();
        }

        [TestMethod]
        [DataRow("aA","")]
        [DataRow("abBA", "")]
        [DataRow("abAB", "abAB")]
        [DataRow("aabAAB", "aabAAB")]
        [DataRow("dabAcCaCBAcCcaDA", "dabCBAcaDA")]
        public void Process(string input, string expected)
        {
            Assert.AreEqual(expected, _day05.ProcessPolymerReaction(input));
        }
        
        [TestMethod]
        public void ProcessPolymerPart1()
        {
            var polymer = FileReader.ReadFile("day05.txt").First();
            Assert.AreEqual(11264, _day05.ProcessPolymerReaction(polymer).Length);
        }

        [TestMethod]
        public void PolymerReduction()
        {
            var polymer = FileReader.ReadFile("day05.txt").First();
            Assert.AreEqual(4552, _day05.FindShortestPolymer(polymer));
        }
    }
}

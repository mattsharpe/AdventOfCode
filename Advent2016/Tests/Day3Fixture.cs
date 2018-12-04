using System.Linq;
using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day3Fixture
    {
        private Day3 _day3;

        [TestInitialize]
        public void Setup()
        {
            _day3 = new Day3();
        }
        
        [TestMethod]
        public void Part1()
        {
            var result = _day3.FindInvalidTriangles();
            Assert.AreEqual(917, result);
        }

        [TestMethod]
        public void MultilineParsing()
        {
            var input = new[]
            {
                "  330  143  338",
                "  769  547   83",
                "  930  625  317"
            };

            var results = _day3.ParseDataForVerticalTriangles(input).ToList();

            Assert.AreEqual(3, results.Count);

            Assert.AreEqual(results[0].A, 330);
            Assert.AreEqual(results[0].B, 769);
            Assert.AreEqual(results[0].C, 930);

            Assert.AreEqual(results[1].A, 143);
            Assert.AreEqual(results[1].B, 547);
            Assert.AreEqual(results[1].C, 625);

            Assert.AreEqual(results[2].A, 338);
            Assert.AreEqual(results[2].B, 83);
            Assert.AreEqual(results[2].C, 317);
        }


        [TestMethod]
        public void Part2()
        {
            var result = _day3.BuildTrianglesVertically();
            Assert.AreEqual(1649, result);
        }
    }
}

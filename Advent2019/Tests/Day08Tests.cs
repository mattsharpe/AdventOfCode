using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day08Tests
    {
        private Day08 _day08;

        [TestInitialize]
        public void TestInitialize() => _day08 = new Day08();

        [TestMethod]
        public void ParseSmallInput()
        {
            var input = "123456789012";
            _day08.ParseLayers(input,3,2);
        }

        [TestMethod]
        public void ParseInput()
        {
            var input = FileReader.ReadFile("day08.txt").First();
            _day08.ParseLayers(input, 25, 6);
            Assert.AreEqual(1463, _day08.Checksum());
        }

        [TestMethod]
        public void PrintImage()
        {
            var input = FileReader.ReadFile("day08.txt").First();
            _day08.ParseLayers(input, 25, 6);
            _day08.FlattenLayers();
        }
    }
}

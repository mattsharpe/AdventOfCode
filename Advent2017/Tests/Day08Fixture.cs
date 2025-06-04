using System.Linq;
using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day08Fixture
    {
        private Day08 _day8 = new Day08();

        private string[] _sample =
        {
            "b inc 5 if a > 1",
            "a inc 1 if b < 5",
            "c dec -10 if a >= 1",
            "c inc -20 if c == 10"
        };

        [TestInitialize]
        public void Setup()
        {
            _day8 = new Day08();
        }

        [TestMethod]
        public void Sample()
        {
            _day8.ProcessInstructions(_sample);
            Assert.AreEqual(1,_day8.Registers.Max(x=>x.Value));
        }
        
        [TestMethod]
        public void Part1()
        {
            _day8.ProcessInstructions(FileReader.ReadFile("day08.txt"));
            Assert.AreEqual(7787, _day8.Registers.Max(x => x.Value));
        }
        
        [TestMethod]
        public void Part2_Sample()
        {
            _day8.ProcessInstructions(_sample);
            Assert.AreEqual(10, _day8.HighWaterMark);
        }
        
        [TestMethod]
        public void Part2()
        {
            _day8.ProcessInstructions(FileReader.ReadFile("day08.txt"));
            Assert.AreEqual(8997, _day8.HighWaterMark);
        }
    }
}
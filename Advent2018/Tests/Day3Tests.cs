using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day3Tests
    {
        private Day3 _day3;

        [TestInitialize]
        public void Setup()
        {
            _day3 = new Day3();
        }

        [TestMethod]
        public void Sample()
        {
            var sample = new[] {"#123 @ 3,2: 5x4"};
            _day3.ProcessInstructions(sample);
        }

        [TestMethod]
        public void SampleData()
        {
            var sample = new[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };
            _day3.ProcessInstructions(sample);
            Assert.AreEqual(4, _day3.CountOverlappingSquares());
        }

        [TestMethod]
        public void FindNumberOfOverlappingClaims()
        {
            var input = FileReader.ReadFile("day3.txt");
            _day3.ProcessInstructions(input);
            Assert.AreEqual(96569, _day3.CountOverlappingSquares());
        }

        [TestMethod]
        public void FindClaimThatDoesntOverlap()
        {
            var input = FileReader.ReadFile("day3.txt");
            _day3.ProcessInstructions(input);
            var claim = _day3.FindClaimThatDoesntOverlap();
            Assert.AreEqual(1023, claim.Id);
        }
    }
}

using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day07Tests
    {
        private Day07 _day7;

        [TestInitialize]
        public void Initialize() => _day7 = new Day07();

        [DataTestMethod]
        [DataRow("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", 
            new []{4,3,2,1,0}, 43210)]
        [DataRow("3,23,3,24,1002,24,10,24,1002,23,-1,23, 101,5,23,23,1,24,23,23,4,23,99,0,0",
            new []{0,1,2,3,4}, 54321)]
        [DataRow("3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0",
            new[]{1,0,4,3,2}, 65210)]
        public void SamplePhaseSettings(string program, int[] phases, int expected)
        {
            Assert.AreEqual(expected, _day7.RunAmplifiers(phases, program));
        }

        [TestMethod]
        public void FindLargestSignal()
        {
            var program = FileReader.ReadFile("day07.txt").First();
            Assert.AreEqual(880726, _day7.FindLargestSignal(program));
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    [TestCategory("IntCode")]
    public class Day07Tests
    {
        private Day07 _day7;

        [TestInitialize]
        public void Initialize() => _day7 = new Day07();

        [DataTestMethod]
        [DataRow("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0",
            new[] { 4, 3, 2, 1, 0 }, 43210)]
        [DataRow("3,23,3,24,1002,24,10,24,1002,23,-1,23, 101,5,23,23,1,24,23,23,4,23,99,0,0",
            new[] { 0, 1, 2, 3, 4 }, 54321)]
        [DataRow("3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0",
            new[] { 1, 0, 4, 3, 2 }, 65210)]
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

        [DataTestMethod]
        [DataRow(139629729, new[] {9, 8, 7, 6, 5},
            "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5")]
        [DataRow(18216, new[] {9, 7, 8, 5, 6},
            "3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10")]
        public async Task FeedbackLoopSamples(int expected, int[] phases, string program)
        {
            var result = await _day7.RunFeedbackLoopAsync(phases, program);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RunFeedbackLoop()
        {
            var program = FileReader.ReadFile("day07.txt").First();
            Assert.AreEqual(4931744, _day7.FindLargestSignalWithFeedbackLoop(program));
        }
    }
}

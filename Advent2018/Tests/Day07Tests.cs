using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day07Tests
    {
        private Day07 _day07;
        private readonly string[] _input =
        {
            "Step C must be finished before step A can begin.",
            "Step C must be finished before step F can begin.",
            "Step A must be finished before step B can begin.",
            "Step A must be finished before step D can begin.",
            "Step B must be finished before step E can begin.",
            "Step D must be finished before step E can begin.",
            "Step F must be finished before step E can begin."
        };

        [TestInitialize]
        public void Setup()
        {
            _day07 = new Day07();
        }

        [TestMethod]
        public void SampleSteps()
        {
            

            string result = _day07.CalculatePath(_input);
            Assert.AreEqual("CABDFE", result);
        }

        [TestMethod]
        public void CalculateBuildOrderPart1()
        {
            var input = FileReader.ReadFile("day07.txt");

            string result = _day07.CalculatePath(input);
            Assert.AreEqual("JNOIKSYABEQRUVWXGTZFDMHLPC", result);
        }

        [TestMethod]
        public void CalculateTimeTaken()
        {
            var result = _day07.CalculateTimeTaken(_input, 2, false);
            Assert.AreEqual(15, result);
        }
        
        [TestMethod]
        public void CalculateTimeTakenWithRealData()
        {
            var result = _day07.CalculateTimeTaken(FileReader.ReadFile("day07.txt"));
            Assert.AreEqual(1099, result);
        }
    }
}

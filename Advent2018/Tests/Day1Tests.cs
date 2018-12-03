using System;
using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day1Tests
    {
        private FrequencyCalibrator _calibrator;

        [TestInitialize]
        public void Setup()
        {
            _calibrator = new FrequencyCalibrator { CurrentFrequency = 0 };
        }

        [TestMethod]
        public void Sample_Data_1()
        {
            var input = new[] { "+1", "+1", "+1" };
            Assert.AreEqual(3, _calibrator.ProcessInstructions(input));
        }

        [TestMethod]
        public void Sample_Data_2()
        {
            var input = new[] { "+1", "+1", "-2" };
            Assert.AreEqual(0, _calibrator.ProcessInstructions(input));
        }

        [TestMethod]
        public void Sample_Data_3()
        {
            var input = new[] { "-1", "-2", "-3" };
            Assert.AreEqual(-6, _calibrator.ProcessInstructions(input));
        }

        [TestMethod]
        public void Process()
        {
            var input = FileReader.ReadFile("Day1Input.txt");

            Assert.AreEqual(425, _calibrator.ProcessInstructions(input));
        }

        [TestMethod]
        public void Part2Sample1()
        {
            var input = new[] { "+1", "-1" };
            Assert.AreEqual(0, _calibrator.FindFirstVisited(input));
        }

        [TestMethod]
        public void Part2Sample2()
        {
            var input = new[] { "+3", "+3","+4", "-2", "-4" };
            Assert.AreEqual(10, _calibrator.FindFirstVisited(input));
        }

        [TestMethod]
        public void Part2Sample3()
        {
            var input = new[] { "-6","+3","+8","+5","-6" };
            Assert.AreEqual(5, _calibrator.FindFirstVisited(input));
        }

        [TestMethod]
        public void Part2Sample4()
        {
            var input = new[] { "+7","+7","-2","-7","-4" };
            Assert.AreEqual(14, _calibrator.FindFirstVisited(input));
        }

        [TestMethod]
        public void ProcessPart2()
        {
            var input = FileReader.ReadFile("Day1Input.txt");
            Console.WriteLine(_calibrator.FindFirstVisited(input));
        }
    }
}

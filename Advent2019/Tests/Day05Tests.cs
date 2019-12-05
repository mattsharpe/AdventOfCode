using System;
using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day05Tests
    {
        private IntCodeComputer _computer;

        [TestInitialize]
        public void Initialize() => _computer = new IntCodeComputer();

        [TestMethod]
        public void DiagnosticOutput()
        {
            var input = FileReader.ReadFile("day05.txt");
            _computer.InitializePositions(input.First());
            _computer.Inputs.Enqueue(1);
            _computer.RunProgram();
            Assert.AreEqual(13547311, _computer.Outputs.Last());
        }

        [TestMethod]
        public void Test()
        {
            var input = 1002;
            Console.WriteLine(input % 1000);
            Console.WriteLine(input.ToString("D5"));
        }

        [TestMethod]
        public void PassThroughInput()
        {
            _computer.InitializePositions("3,0,4,0,99");
            _computer.Inputs.Enqueue(123);
            _computer.RunProgram();
            Assert.AreEqual(123, _computer.Outputs.Last());
        }

        [TestMethod]
        public void SampleProgram()
        {
            _computer.InitializePositions("1002,4,3,4,33");
            _computer.RunProgram();
            Assert.AreEqual(99, _computer.Addresses[4]);
        }

        [TestMethod]
        public void NegativeNumbersAreHandledCorrectly()
        {
            _computer.InitializePositions("1101,100,-1,4,0");
            _computer.RunProgram();
            Assert.AreEqual(99, _computer.Addresses[4]);
        }
    }
}

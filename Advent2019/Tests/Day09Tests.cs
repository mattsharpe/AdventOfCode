using System;
using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass, TestCategory("IntCode")]
    public class Day09Tests
    {
        private IntCodeComputer _computer;

        [TestInitialize]
        public void Initialize() => _computer = new IntCodeComputer();

        [TestMethod]
        public void GenerateCopyOfInput()
        {
            var program = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99";
            _computer.InitializePositions(program);
            _computer.RunProgram();
            Assert.AreEqual(program, string.Join(",",_computer.Outputs));
        }

        [TestMethod]
        public void SixteenDigitNumber()
        {
            var program = "1102,34915192,34915192,7,4,7,99,0";
            _computer.InitializePositions(program);
            _computer.RunProgram();
            Assert.AreEqual(1219070632396864, _computer.Outputs.First());
        }

        [TestMethod]
        public void OutputLargeNumber()
        {
            var program = "104,1125899906842624,99";
            _computer.InitializePositions(program);
            _computer.RunProgram();
            Assert.AreEqual(1125899906842624, _computer.Outputs.First());
        }

        [TestMethod]
        public void BoostKeycode()
        {
            var program = FileReader.ReadFile("day09.txt").First();
            _computer.InitializePositions(program);
            _computer.Inputs.Add(1);
            _computer.RunProgram();
            Assert.AreEqual(2204990589, _computer.Outputs.First());
        }

        [TestMethod]
        public void RunBoostProgram()
        {
            var program = FileReader.ReadFile("day09.txt").First();
            _computer.InitializePositions(program);
            _computer.Inputs.Add(2);
            _computer.RunProgram();
            Assert.AreEqual(50008, _computer.Outputs.First());
        }
    }
}

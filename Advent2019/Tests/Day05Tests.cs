using System;
using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass, TestCategory("IntCode")]
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
            _computer.Inputs.Add(1);
            _computer.RunProgram();
            Assert.AreEqual(13547311, _computer.Outputs.Last());
        }
        
        [TestMethod]
        public void PassThroughInput()
        {
            _computer.InitializePositions("3,0,4,0,99");
            _computer.Inputs.Add(123);
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

        [TestMethod]
        public void EqualToEight()
        {
            _computer.InitializePositions("3,9,8,9,10,9,4,9,99,-1,8");
            _computer.Inputs.Add(8);
            _computer.RunProgram();
            Assert.AreEqual(1, _computer.Outputs.Last());
        }

        [TestMethod]
        public void EqualToEight_Immediate()
        {
            _computer.InitializePositions("3,3,1108,-1,8,3,4,3,99");
            _computer.Inputs.Add(8);
            _computer.RunProgram();
            Assert.AreEqual(1, _computer.Outputs.Last());
        }

        [TestMethod]
        public void NotEqualToEight_Immediate()
        {
            _computer.InitializePositions("3,3,1108,-1,8,3,4,3,99");
            _computer.Inputs.Add(1);
            _computer.RunProgram();
            Assert.AreEqual(0, _computer.Outputs.Last());
        }

        [TestMethod]
        public void NotEqualToEight()
        {
            _computer.InitializePositions("3,9,8,9,10,9,4,9,99,-1,8");
            _computer.Inputs.Add(1);
            _computer.RunProgram();
            Assert.AreEqual(0, _computer.Outputs.Last());
        }

        [TestMethod]
        public void LessThanEight()
        {
            _computer.InitializePositions("3,9,7,9,10,9,4,9,99,-1,8");
            _computer.Inputs.Add(1);
            _computer.RunProgram();
            Assert.AreEqual(1, _computer.Outputs.Last());
        }

        [TestMethod]
        public void NotLessThanEight()
        {
            _computer.InitializePositions("3,9,7,9,10,9,4,9,99,-1,8");
            _computer.Inputs.Add(9);
            _computer.RunProgram();
            Assert.AreEqual(0, _computer.Outputs.Last());
        }
        
        [TestMethod]
        public void LessThanEight_Immediate()
        {
            _computer.InitializePositions("3,3,1107,-1,8,3,4,3,99");
            _computer.Inputs.Add(1);
            _computer.RunProgram();
            Assert.AreEqual(1, _computer.Outputs.Last());
        }

        [TestMethod]
        public void NotLessThanEight_Immediate()
        {
            _computer.InitializePositions("3,3,1107,-1,8,3,4,3,99");
            _computer.Inputs.Add(9);
            _computer.RunProgram();
            Assert.AreEqual(0, _computer.Outputs.Last());
        }

        [TestMethod]
        public void JumpImmediateZero()
        {
            _computer.InitializePositions("3,3,1105,-1,9,1101,0,0,12,4,12,99,1");
            _computer.Inputs.Add(0);
            _computer.RunProgram();
            Assert.AreEqual(0, _computer.Outputs.Last());
        }

        [TestMethod]
        public void JumpImmediateNonZero()
        {
            _computer.InitializePositions("3,3,1105,-1,9,1101,0,0,12,4,12,99,1");
            _computer.Inputs.Add(123);
            _computer.RunProgram();
            Assert.AreEqual(1, _computer.Outputs.Last());
        }

        [TestMethod]
        public void JumpPositionZero()
        {
            _computer.InitializePositions("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9");
            _computer.Inputs.Add(0);
            _computer.RunProgram();
            Assert.AreEqual(0, _computer.Outputs.Last());
        }

        [TestMethod]
        public void JumpPositionNonZero()
        {
            _computer.InitializePositions("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9");
            _computer.Inputs.Add(123);
            _computer.RunProgram();
            Assert.AreEqual(1, _computer.Outputs.Last());
        }

        [DataTestMethod]
        [DataRow(7, 999)]
        [DataRow(8, 1000)]
        [DataRow(9, 1001)]
        public void SampleProgramme(int input, int expected)
        {
            _computer.InitializePositions("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99");
            _computer.Inputs.Add(input);
            _computer.RunProgram();
            Assert.AreEqual(expected, _computer.Outputs.Last());
        }

        [TestMethod]
        public void DiagnosticTest()
        {
            var input = FileReader.ReadFile("day05.txt");
            _computer.InitializePositions(input.First());
            _computer.Inputs.Add(5);
            _computer.RunProgram();
            Assert.AreEqual(236453, _computer.Outputs.Last());
        }
    }
}

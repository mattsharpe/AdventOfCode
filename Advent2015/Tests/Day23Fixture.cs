using System;
using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day23Fixture
    {
        private Day23 _day23;

        [TestInitialize]
        public void Initialize()
        {
            _day23 = new Day23();
        }

        [TestMethod]
        public void SampleInstructions()
        {
            var input = new[]
            {
                "inc a",
                "jio a, +2",
                "tpl a",
                "inc a"
            };
            
            _day23.ProcessInstructions(input);

            Assert.AreEqual(2, _day23.Registers['a']);
        }

        [TestMethod]
        public void UnrecognisedInstruction()
        {
            _day23.Registers['a'] = 4;

            Assert.ThrowsException<ArgumentException>(() =>
            {
                _day23.ProcessInstructions(new[] {"badger, monkey"});
            });
        }


        [TestMethod]
        public void HalfInstruction()
        {
            _day23.Registers['a'] = 4;

            _day23.ProcessInstructions(new []{"hlf a"});

            Assert.AreEqual(2, _day23.Registers['a']);
        }

        [TestMethod]
        public void TripeInstruction()
        {
            _day23.Registers['a'] = 2;

            _day23.ProcessInstructions(new []{"tpl a"});

            Assert.AreEqual(6, _day23.Registers['a']);
        }

        [TestMethod]
        public void IncrementInstruction()
        {
            _day23.Registers['b'] = 2;

            _day23.ProcessInstructions(new []{ "inc b" });

            Assert.AreEqual(3, _day23.Registers['b']);
        }

        [TestMethod]
        public void PositiveJumpInstruction()
        {
            var result = _day23.ProcessInstruction("jmp +12");

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void NegativeJumpInstruction()
        {
            var result = _day23.ProcessInstruction("jmp -7");

            Assert.AreEqual(-7, result);
        }

        [TestMethod]
        public void JumpIfEvenInstructionWithEvenRegister()
        {
            _day23.Registers['a'] = 6;
            var result = _day23.ProcessInstruction("jie a, -2");
            
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void JumpIfEvenInstructionWithOddRegister()
        {
            _day23.Registers['a'] = 5;
            var result = _day23.ProcessInstruction("jie a, -2");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void JumpIfOneInstructionWithNonOne()
        {
            _day23.Registers['a'] = 6;
            var result = _day23.ProcessInstruction("jio a, +2");
            
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void JumpIfOneInstructionWithOne()
        {
            _day23.Registers['a'] = 1;
            var result = _day23.ProcessInstruction("jio a, +2");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day23.txt");

            _day23.ProcessInstructions(input);

            Assert.AreEqual(255, _day23.Registers['b']);
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day23.txt");

            _day23.Registers['a'] = 1;
            _day23.ProcessInstructions(input);

            Assert.AreEqual(334, _day23.Registers['b']);
        }
    }
}
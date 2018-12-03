using System;
using System.Threading.Tasks;
using Advent2017.Solutions;
using Advent2017.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day18Fixture
    {
        private Day18 _day18 = new Day18();

        [TestInitialize]
        public void Setup()
        {
            _day18 = new Day18();
        }

        [TestMethod]
        public void Sound()
        {
            _day18.Registers["a"] = 123;
            _day18.ProcessInstructions(new []{"snd a"});
            _day18.Speaker = 123;
        }

        [TestMethod]
        public void Set_From_Register()
        {
            _day18.Registers["a"] = 123;
            _day18.ProcessInstructions(new[] { "set b a" });
            Assert.AreEqual(123, _day18.Registers["b"]);
        }

        [TestMethod]
        public void Set_From_Value()
        {
            _day18.ProcessInstructions(new[] { "set a 123" });
            Assert.AreEqual(123, _day18.Registers["a"]);
        }

        [TestMethod]
        public void Add_FromValue()
        {
            _day18.ProcessInstructions(new[] { "add a 123" });
            Assert.AreEqual(123, _day18.Registers["a"]);
        }

        [TestMethod]
        public void Add_FromRegister()
        {
            _day18.Registers["b"] = 123;
            _day18.ProcessInstructions(new[] { "add a b" });
            Assert.AreEqual(123, _day18.Registers["a"]);
        }

        [TestMethod]
        public void Mul_FromValue()
        {
            _day18.Registers["a"] = 2;
            _day18.ProcessInstructions(new[] { "mul a 2" });
            Assert.AreEqual(4, _day18.Registers["a"]);
        }

        [TestMethod]
        public void Mul_FromRegister()
        {
            _day18.Registers["a"] = 2;
            _day18.Registers["b"] = 3;
            _day18.ProcessInstructions(new[] { "mul a b" });
            Assert.AreEqual(6, _day18.Registers["a"]);
        }

        [TestMethod]
        public void Mod_FromValue()
        {
            _day18.Registers["a"] = 5;
            _day18.ProcessInstructions(new[] { "mod a 2" });
            Assert.AreEqual(1, _day18.Registers["a"]);
        }

        [TestMethod]
        public void Mod_FromRegister()
        {
            _day18.Registers["a"] = 8;
            _day18.Registers["b"] = 3;
            _day18.ProcessInstructions(new[] { "mod a b" });
            Assert.AreEqual(2, _day18.Registers["a"]);
        }

        [TestMethod]
        public void Receive()
        {
            _day18.Speaker = 123;
            var result = _day18.ProcessInstructions(new []{"rcv 1"});
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void Receive_SkipsOn0()
        {
            _day18.Speaker = 123;
            var result = _day18.ProcessInstructions(new []{"rcv 0"});
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Sample()
        {
            var input = new[]
            {
                "set a 1",
                "add a 2",
                "mul a a",
                "mod a 5",
                "snd a",
                "set a 0",
                "rcv a",
                "jgz a -1",
                "set a 1",
                "jgz a -2"
            };

            var result = _day18.ProcessInstructions(input);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Part1()
        {
            var instructions = FileReader.ReadFile("day18.txt");
            var result = _day18.ProcessInstructions(instructions);
            Console.WriteLine();
            Assert.AreEqual(3423, result);
        }

        [TestMethod]
        public void Part2()
        {
            var instructions = FileReader.ReadFile("day18.txt");
            var zero = new Day18Part2 {Registers = {["p"] = 0}, Id=0};
            var one = new Day18Part2 { Registers = {["p"] = 1}, Id=1};

            zero.InputQueue = one.OutputQueue;
            zero.OutputQueue = one.InputQueue;
            zero.OtherBlocked = one.IsBlocked;
            one.OtherBlocked = zero.IsBlocked;

            var task1 = Task.Run(() => zero.ProcessInstructions(instructions));
            var task2 = Task.Run(() => one.ProcessInstructions(instructions));

            Task.WaitAll(task1, task2);
            
            Assert.AreEqual(7493, one.SendCount);

        }

        [TestMethod]
        public void Sample_Part2()
        {
            var instructions = new[]
            {
                "snd 1",
                "snd 2",
                "snd p",
                "rcv a",
                "rcv b",
                "rcv c",
                "rcv d"
            };

            var zero = new Day18Part2 { Registers = { ["p"] = 0 } };
            var one = new Day18Part2 { Registers = { ["p"] = 1 } };

            zero.InputQueue = one.OutputQueue;
            zero.OutputQueue = one.InputQueue;
            zero.OtherBlocked = one.IsBlocked;
            one.OtherBlocked = zero.IsBlocked;

            var task1 = Task.Run(() => zero.ProcessInstructions(instructions));
            var task2 = Task.Run(() => one.ProcessInstructions(instructions));

            Task.WaitAll(task1, task2);
            
            Assert.AreEqual(3, zero.SendCount);
            Assert.AreEqual(3, one.SendCount);
            

        }
    }
}

using System;
using System.Threading.Tasks;
using Advent2017.Solutions;
using Advent2017.Utilities;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day18Fixture
    {
        private Day18 _day18 = new Day18();

        [SetUp]
        public void Setup()
        {
            _day18 = new Day18();
        }

        [Test]
        public void Sound()
        {
            _day18.Registers["a"] = 123;
            _day18.ProcessInstructions(new []{"snd a"});
            _day18.Speaker = 123;
        }

        [Test]
        public void Set_From_Register()
        {
            _day18.Registers["a"] = 123;
            _day18.ProcessInstructions(new[] { "set b a" });
            Assert.AreEqual(123, _day18.Registers["b"]);
        }

        [Test]
        public void Set_From_Value()
        {
            _day18.ProcessInstructions(new[] { "set a 123" });
            Assert.AreEqual(123, _day18.Registers["a"]);
        }

        [Test]
        public void Add_FromValue()
        {
            _day18.ProcessInstructions(new[] { "add a 123" });
            Assert.AreEqual(123, _day18.Registers["a"]);
        }

        [Test]
        public void Add_FromRegister()
        {
            _day18.Registers["b"] = 123;
            _day18.ProcessInstructions(new[] { "add a b" });
            Assert.AreEqual(123, _day18.Registers["a"]);
        }

        [Test]
        public void Mul_FromValue()
        {
            _day18.Registers["a"] = 2;
            _day18.ProcessInstructions(new[] { "mul a 2" });
            Assert.AreEqual(4, _day18.Registers["a"]);
        }

        [Test]
        public void Mul_FromRegister()
        {
            _day18.Registers["a"] = 2;
            _day18.Registers["b"] = 3;
            _day18.ProcessInstructions(new[] { "mul a b" });
            Assert.AreEqual(6, _day18.Registers["a"]);
        }

        [Test]
        public void Mod_FromValue()
        {
            _day18.Registers["a"] = 5;
            _day18.ProcessInstructions(new[] { "mod a 2" });
            Assert.AreEqual(1, _day18.Registers["a"]);
        }

        [Test]
        public void Mod_FromRegister()
        {
            _day18.Registers["a"] = 8;
            _day18.Registers["b"] = 3;
            _day18.ProcessInstructions(new[] { "mod a b" });
            Assert.AreEqual(2, _day18.Registers["a"]);
        }

        [Test]
        public void Receive()
        {
            _day18.Speaker = 123;
            var result = _day18.ProcessInstructions(new []{"rcv 1"});
            Assert.AreEqual(123, result);
        }

        [Test]
        public void Receive_SkipsOn0()
        {
            _day18.Speaker = 123;
            var result = _day18.ProcessInstructions(new []{"rcv 0"});
            Assert.AreEqual(0, result);
        }

        [Test]
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

        [Test]
        public void Part1()
        {
            var instructions = FileReader.ReadFile("day18.txt");
            var result = _day18.ProcessInstructions(instructions);
            Console.WriteLine();
            Assert.AreEqual(3423, result);
        }

        [Test]
        public void Part2()
        {
            var instructions = FileReader.ReadFile("day18.txt");
            var zero = new Day18 {Registers = {["p"] = 0}};
            var one = new Day18 {Registers = {["p"] = 1}};

            zero.InputQueue = one.OutputQueue;
            zero.OutputQueue = one.InputQueue;

            var task1 = Task.Run(() => zero.ProcessInstructions2(instructions, one.IsBlocked));
            var task2 = Task.Run(() => one.ProcessInstructions2(instructions, zero.IsBlocked));

            Task.WaitAll(task1, task2);

            Assert.AreEqual(7493, one.SendCount);

        }

        [Test]
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

            var zero = new Day18 { Registers = { ["p"] = 0 } };
            var one = new Day18 { Registers = { ["p"] = 1 } };

            zero.InputQueue = one.OutputQueue;
            zero.OutputQueue = one.InputQueue;

            var task1 = Task.Run(() => zero.ProcessInstructions2(instructions, one.IsBlocked));
            var task2 = Task.Run(() => one.ProcessInstructions2(instructions, zero.IsBlocked));

            Task.WaitAll(task1, task2);
            
            Console.WriteLine(zero.SendCount);
            Console.WriteLine(one.SendCount);
            

        }
    }
}

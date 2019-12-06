using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day02Tests
    {
        private IntCodeComputer _day2;

        [TestInitialize] 
        public void Initialize() => _day2 = new IntCodeComputer();

        [TestMethod]
        public void SampleProgram()
        {
            var program = "1,9,10,3,2,3,11,0,99,30,40,50";
            _day2.InitializePositions(program);
            _day2.RunProgram();
            Assert.AreEqual(3500, _day2.Addresses[0]);
        }

        [DataTestMethod]
        [DataRow("1,0,0,0,99", 0, 2)]
        [DataRow("2,3,0,3,99", 3, 6)]
        [DataRow("2,4,4,5,99,0", 5, 9801)]
        [DataRow("1,1,1,4,99,5,6,0,99", 0, 30)]
        [DataRow("1,1,1,4,99,5,6,0,99", 4, 2)]
        public void SamplePrograms(string program, int position, int expected)
        {
            _day2.InitializePositions(program);
            _day2.RunProgram();
            
            Assert.AreEqual(expected, _day2.Addresses[position]);
        }

        [TestMethod]
        public void Part1()
        {
            var program = FileReader.ReadFile("day02.txt").Single();
            _day2.InitializePositions(program);
            _day2.Addresses[1] = 12;
            _day2.Addresses[2] = 2;
            _day2.RunProgram();
            Assert.AreEqual(4023471, _day2.Addresses[0]);
        }

        [TestMethod]
        public void Part2()
        {
            var program = FileReader.ReadFile("day02.txt").Single();
            _day2.InitializePositions(program);

            var result = Enumerable.Range(0, 99)
                .SelectMany(noun => Enumerable.Range(0, 99), (noun, verb) => (noun, verb))
                .Single(x =>
                    {
                        _day2.InitializePositions(program);
                        _day2.Addresses[1] = x.noun;
                        _day2.Addresses[2] = x.verb;
                        _day2.RunProgram();
                        return _day2.Addresses[0] == 19690720;
                    });
            
            Assert.AreEqual(8051, 100 * result.noun + result.verb);
        }
    }
}

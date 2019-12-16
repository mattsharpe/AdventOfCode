using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Advent2019.Tests
{
    [TestClass, TestCategory("IntCode")]
    public class Day11Tests
    {
        private Day11 _robot;

        [TestInitialize]
        public void Initialize() => _robot = new Day11();

        [TestMethod]
        public void CountPaintedSquares()
        {
            var program = FileReader.ReadFile("day11.txt").First();
            _robot.Initialize(program);
            _robot.DrawRegistration();

            Assert.AreEqual(2093, _robot.PaintedSquares());
        }

        [TestMethod]
        public void PaintShipName()
        {
            var program = FileReader.ReadFile("day11.txt").First();
            _robot.Initialize(program);
            _robot.AddInput(1);
            _robot.DrawRegistration();
            _robot.Print();
            
        }
    }

}

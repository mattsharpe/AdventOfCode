using System;
using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day12Tests
    {

        private Day12 _day12;

        [TestInitialize]
        public void Initialize() => _day12 = new Day12();

        [TestMethod]
        public void SingleStep()
        {
            string[] input =
            {
                "<x=-1, y=0, z=2>",
                "<x=2, y=-10, z=-7>",
                "<x=4, y=-8, z=8>",
                "<x=3, y=5, z=-1>"
            };

            _day12.ParseInput(input);
            foreach (var moon in _day12.Moons)
            {
                Console.WriteLine(moon.Position + ", " + moon.Velocity);
            }

            _day12.Step();
            Console.WriteLine("*****");

            foreach (var moon in _day12.Moons)
            {
                Console.WriteLine(moon.Position + ", " + moon.Velocity);
            }

            //Assert.AreEqual(_day12.Moons[0].Position, (2,-1,1));
            Assert.AreEqual(_day12.Moons[0].Velocity, (3,-1,-1));

            //Assert.AreEqual(_day12.Moons[1].Position, (3, -7, -4));
            Assert.AreEqual(_day12.Moons[1].Velocity, (1,3,3));
            
            //Assert.AreEqual(_day12.Moons[2].Position, (1,-7,5));
            Assert.AreEqual(_day12.Moons[2].Velocity, (-3,1,-3));
            
            //Assert.AreEqual(_day12.Moons[3].Position, (2,2,0));
            Assert.AreEqual(_day12.Moons[3].Velocity, (-1,-3,1));
        }

        [TestMethod]
        public void TenSteps()
        {
            string[] input =
            {
                "<x=-1, y=0, z=2>",
                "<x=2, y=-10, z=-7>",
                "<x=4, y=-8, z=8>",
                "<x=3, y=5, z=-1>"
            };

            _day12.ParseInput(input);
            foreach (var moon in _day12.Moons)
            {
                Console.WriteLine(moon.Position + ", " + moon.Velocity);
            }

            foreach (var irrelevant in Enumerable.Range(1,10))
            {
                
                _day12.Step();
                Console.WriteLine("********************");
                foreach (var moon in _day12.Moons)
                {
                    Console.WriteLine(moon.Position + ", " + moon.Velocity);
                }
            }
            
            Assert.AreEqual(_day12.Moons[0].Position, (2,1,-3));
            Assert.AreEqual(_day12.Moons[0].Velocity, (-3,-2,1));

            Assert.AreEqual(_day12.Moons[1].Position, (1,-8,0));
            Assert.AreEqual(_day12.Moons[1].Velocity, (-1,1,3));
            
            Assert.AreEqual(_day12.Moons[2].Position, (3,-6,1));
            Assert.AreEqual(_day12.Moons[2].Velocity, (3,2,-3));
            
            Assert.AreEqual(_day12.Moons[3].Position, (2,0,4));
            Assert.AreEqual(_day12.Moons[3].Velocity, (1,-1,-1));

        }

        [TestMethod]
        public void TotalEnergyAfter10Steps()
        {
            string[] input =
            {
                "<x=-1, y=0, z=2>",
                "<x=2, y=-10, z=-7>",
                "<x=4, y=-8, z=8>",
                "<x=3, y=5, z=-1>"
            };

            _day12.ParseInput(input);

            foreach (var irrelevant in Enumerable.Range(1,10))
            {
                _day12.Step();
            }

            Assert.AreEqual(179,_day12.CalculateTotalEnergy());
        }

        [TestMethod]
        public void TotalEnergyAfter10StepsSecond()
        {
            string[] input =
            {
                "<x=-8, y=-10, z=0>",
                "<x=5, y=5, z=10>",
                "<x=2, y=-7, z=3>",
                "<x=9, y=-8, z=-3>"
            };

            _day12.ParseInput(input);

            foreach (var irrelevant in Enumerable.Range(1,100))
            {
                _day12.Step();
            }

            Assert.AreEqual(1940, _day12.CalculateTotalEnergy());
        }

        [TestMethod]
        public void EnergyAfter1000Steps()
        {
            var input = FileReader.ReadFile("day12.txt");

            _day12.ParseInput(input);

            foreach (var irrelevant in Enumerable.Range(1,1000))
            {
                _day12.Step();
            }

            Assert.AreEqual(1940, _day12.CalculateTotalEnergy());

        }

    }
}
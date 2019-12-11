using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day10Tests
    {
        private Day10 _day10;

        [TestInitialize]
        public void Initialize() => _day10 = new Day10();

        [TestMethod]
        public void SmallMap()
        {
            var input = new[]
            {
                ".#..#",
                ".....",
                "#####",
                "....#",
                "...##",
            };

            var result = _day10.BestLocationForStation(input);
            Assert.AreEqual(result, (8, 3, 4));
        }

        [TestMethod]
        public void Detects33AsteroidsAtX5Y8()
        {
            var input = new[]
            {
                "......#.#.",
                "#..#.#....",
                "..#######.",
                ".#.#.###..",
                ".#..#.....",
                "..#....#.#",
                "#..#....#.",
                ".##.#..###",
                "##...#..#.",
                ".#....####",
            };

            var result = _day10.BestLocationForStation(input);
            Assert.AreEqual(result, (33, 5, 8));
        }

        [TestMethod]
        public void Detects35AsteroidsAtX1Y2()
        {
            var input = new[]
            {
                "#.#...#.#.",
                ".###....#.",
                ".#....#...",
                "##.#.#.#.#",
                "....#.#.#.",
                ".##..###.#",
                "..#...##..",
                "..##....##",
                "......#...",
                ".####.###.",
            };

            var result = _day10.BestLocationForStation(input);
            Assert.AreEqual(result, (35, 1, 2));
        }

        [TestMethod]
        public void Detects41AsteroidsAtX6Y3()
        {
            var input = new[]
            {
                ".#..#..###",
                "####.###.#",
                "....###.#.",
                "..###.##.#",
                "##.##.#.#.",
                "....###..#",
                "..#.#..#.#",
                "#..#.#.###",
                ".##...##.#",
                ".....#.#.."
            };

            var result = _day10.BestLocationForStation(input);
            Assert.AreEqual(result, (41, 6, 3));
        }

        [TestMethod]
        public void Detects210AsteroidsAtX11Y13()
        {
            var input = new[]
            {
                ".#..##.###...#######",
                "##.############..##.",
                ".#.######.########.#",
                ".###.#######.####.#.",
                "#####.##.#.##.###.##",
                "..#####..#.#########",
                "####################",
                "#.####....###.#.#.##",
                "##.#################",
                "#####.##.###..####..",
                "..######..##.#######",
                "####.##.####...##..#",
                ".#####..#.######.###",
                "##...#.##########...",
                "#.##########.#######",
                ".####.#.###.###.#.##",
                "....##.##.###..#####",
                ".#.#.###########.###",
                "#.#.#.#####.####.###",
                "###.##.####.##.#..##",
            };

            var result = _day10.BestLocationForStation(input);
            Assert.AreEqual(result, (210, 11, 13));
        }

        [TestMethod]
        public void FindBestLocationForAsteroidStation()
        {
            var input = FileReader.ReadFile("day10.txt");
            Assert.AreEqual((344, 30,34), _day10.BestLocationForStation(input));

        }

        [TestMethod]
        public void RunAsteroidVaporizationSimulation()
        {
            var asteroidField = new []
            {
                ".#....#####...#..",
                "##...##.#####..##",
                "##...#...#.#####.",
                "..#.....#...###..",
                "..#.#.....#....##",
            };
            Assert.AreEqual((30,8,3), _day10.BestLocationForStation(asteroidField));
            
            _day10.FireTheLaserPewPew((8,3));
        }

        [TestMethod]
        public void RunAsteroidVaporizationSimulationLargeSample()
        {
            var asteroidField = new[]
            {
                ".#..##.###...#######",
                "##.############..##.",
                ".#.######.########.#",
                ".###.#######.####.#.",
                "#####.##.#.##.###.##",
                "..#####..#.#########",
                "####################",
                "#.####....###.#.#.##",
                "##.#################",
                "#####.##.###..####..",
                "..######..##.#######",
                "####.##.####...##..#",
                ".#####..#.######.###",
                "##...#.##########...",
                "#.##########.#######",
                ".####.#.###.###.#.##",
                "....##.##.###..#####",
                ".#.#.###########.###",
                "#.#.#.#####.####.###",
                "###.##.####.##.#..##",
            };
            Assert.AreEqual((210,11,13), _day10.BestLocationForStation(asteroidField));
            
            var (x, y) = _day10.FireTheLaserPewPew((11,13))[199];
            
            Assert.AreEqual(802, x * 100 + y);
        }


        [TestMethod]
        public void FireZeLasers()
        {
            var asteroidField = FileReader.ReadFile("day10.txt");
            Assert.AreEqual((344,30,34), _day10.BestLocationForStation(asteroidField));
            var (x, y) = _day10.FireTheLaserPewPew((30,34))[199];
            
            Assert.AreEqual(2732, x * 100 + y);
        }
    }
}
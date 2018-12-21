using System;
using System.Linq;
using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day12Tests
    {
        private Day12 _day12;
        private string[] SampleRules = new[]
        {
            "...## => #",
            "..#.. => #",
            ".#... => #",
            ".#.#. => #",
            ".#.## => #",
            ".##.. => #",
            ".#### => #",
            "#.#.# => #",
            "#.### => #",
            "##.#. => #",
            "##.## => #",
            "###.. => #",
            "###.# => #",
            "####. => #"
        };

        [TestInitialize]
        public void Setup()
        {
            _day12 = new Day12();
        }

        [TestMethod]
        public void PlantPotSample()
        {
            _day12.InitialState = "#..#.#..##......###...###";

            _day12.ParseRules(SampleRules);

            Assert.AreEqual("#..#.#..##......###...###", _day12.InitialState);

            var result = _day12.EvolveGeneration(new PlantGeneration{PlantPots = _day12.InitialState});

            Assert.AreEqual("..#...#....#.....#..#..#..#..", result.PlantPots);
            Console.WriteLine(result);
        }

        [DataTestMethod]
        [DataRow(1, "..#...#....#.....#..#..#..#..")]
        [DataRow(2, "....##..##...##....#..#..#..##...")]
        [DataRow(3, ".....#.#...#..#.#....#..#..#...#.....")]
        [DataRow(4, "........#.#..#...#.#...#..#..##..##......")]
        [DataRow(5, "...........#...##...#.#..#..#...#...#........")]
        [DataRow(6, ".............##.#.#....#...#..##..##..##.........")]
        [DataRow(7, "..............#..###.#...##..#...#...#...#...........")]
        [DataRow(8, "................#....##.#.#.#..##..##..##..##............")]
        [DataRow(9, "..................##..#..#####....#...#...#...#..............")]
        [DataRow(10, "...................#.#..#...#.##....##..##..##..##...............")]
        [DataRow(11, "......................#...##...#.#...#.#...#...#...#.................")]
        [DataRow(12, "........................##.#.#....#.#...#.#..##..##..##..................")]
        [DataRow(13, ".........................#..###.#....#.#...#....#...#...#....................")]
        [DataRow(14, "...........................#....##.#....#.#..##...##..##..##.....................")]
        [DataRow(15, ".............................##..#..#.#....#....#..#.#...#...#.......................")]
        [DataRow(16, "..............................#.#..#...#.#...##...#...#.#..##..##........................")]
        [DataRow(17, ".................................#...##...#.#.#.#...##...#....#...#..........................")]
        [DataRow(18, "...................................##.#.#....#####.#.#.#...##...##..##...........................")]
        [DataRow(19, "....................................#..###.#..#.#.#######.#.#.#..#.#...#.............................")]
        [DataRow(20, "......................................#....##....#####...#######....#.#..##..............................")]
        public void ProcessGenerations(int generations, string expected)
        {
            _day12.InitialState = "#..#.#..##......###...###";
            _day12.ParseRules(SampleRules);
            foreach (var i in expected)
            {
                var solved = _day12.SolveForGenerations(generations);
                Assert.AreEqual(expected, solved.PlantPots);
                Assert.AreEqual(-2 * generations, solved.Offset);
            }
        }

        [TestMethod]
        public void CalculateOffset()
        {
            _day12.InitialState = "##..##...##....#..#..#..##";
            _day12.ParseRules(SampleRules);
            var result = _day12.SolveForGenerations(1);
            Assert.AreEqual(".#.#...#..#.#....#..#..#...#..", result.PlantPots);
            Assert.AreEqual(-2, result.Offset);

        }

        [TestMethod]
        public void CountPlants()
        {
            _day12.InitialState = "#..#.#..##......###...###...........";
            _day12.ParseRules(SampleRules);

            var generation = _day12.SolveForGenerations(20);

            Assert.AreEqual(325, _day12.CountPlants(generation));
        }

        [TestMethod]
        public void Simulate20Generations()
        {
            _day12.ParseRules(FileReader.ReadFile("day12.txt"));
            
            var result = _day12.SolveForGenerations(20);
            
            Assert.AreEqual(3605, _day12.CountPlants(result));
        }

        [TestMethod]
        [DataRow(100, 8898)]
        [DataRow(200, 16998)]
        [DataRow(300, 25098)]
        [DataRow(400, 33198)]
        [DataRow(500, 41298)]
        public void LookForPattern(int generations, int expected)
        {
            var rules = FileReader.ReadFile("day12.txt");

            _day12.ParseRules(rules);
            Assert.AreEqual(expected, _day12.CountPlants(_day12.SolveForGenerations(generations)));
            Assert.AreEqual(expected, _day12.CountPlantsBasedOnPattern(generations));
        }

        [TestMethod]
        public void FiftyBillionGenerationsOfPlants()
        {
            var rules = FileReader.ReadFile("day12.txt");
            //50 billion is too many to brute force - is there a sequence in the answers?

            _day12.ParseRules(rules);
            //Assert.AreEqual(123, _day12.CountPlantsBasedOnPattern(500));
        }




    }
}
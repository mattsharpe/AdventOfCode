using System;
using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day15Tests
    {

        private Day15 _day15;

        [TestInitialize]
        public void TestInitialize()
        {
            _day15 = new Day15();
        }

        [TestMethod]
        public void ShortestPath()
        {
            string[] input =
            {
                @"#######",
                @"#.G...#",
                @"#...EG#",
                @"#.#.#G#",
                @"#..G#E#",
                @"#.....#",
                @"#######"
            };
            _day15.ParseInput(input);
            var path = _day15.ShortestPath((2, 1), (4, 1));
            Assert.AreEqual(2, path.Count);
            Assert.AreEqual((3,1), path[0]);
            Assert.AreEqual((4,1), path[1]);
        }

        [TestMethod]
        public void CombatRound()
        {
            string[] input =
                {
                    @"#######",
                    @"#.G...#",
                    @"#...EG#",
                    @"#.#.#G#",
                    @"#..G#E#",
                    @"#.....#",
                    @"#######"
                };
                
            _day15.ParseInput(input);
            _day15.RunGameToCompletion();

            Assert.AreEqual(47, _day15.Rounds);
            Assert.AreEqual(590, _day15.TotalHitPoints);
            Assert.AreEqual(27730, _day15.Outcome);
        }

        [TestMethod]
        public void SampleData()
        {
            string[] input =
            {
                @"#######",
                @"#G..#E#",
                @"#E#E.E#",
                @"#G.##.#",
                @"#...#E#",
                @"#...E.#",
                @"#######"
            };

            _day15.ParseInput(input);
            _day15.RunGameToCompletion();

            Assert.AreEqual(37, _day15.Rounds);
            Assert.AreEqual(982, _day15.TotalHitPoints);
            Assert.AreEqual(36334, _day15.Outcome);
        }

        [TestMethod]
        public void SampleData2()
        {
            string[] input =
            {
                @"#######",
                @"#E..EG#",
                @"#.#G.E#",
                @"#E.##E#",
                @"#G..#.#",
                @"#..E#.#",
                @"#######",
            };

            _day15.ParseInput(input);
            _day15.RunGameToCompletion();
            Assert.AreEqual(46, _day15.Rounds);
            Assert.AreEqual(859, _day15.TotalHitPoints);
            Assert.AreEqual(39514, _day15.Outcome);
        }

        [TestMethod]
        public void SampleData3()
        {
            string[] input =
            {
                @"#######",
                @"#E.G#.#",
                @"#.#G..#",
                @"#G.#.G#",
                @"#G..#.#",
                @"#...E.#",
                @"#######",
            };

            _day15.ParseInput(input);
            _day15.RunGameToCompletion();
            Assert.AreEqual(35, _day15.Rounds);
            Assert.AreEqual(793, _day15.TotalHitPoints);
            Assert.AreEqual(27755, _day15.Outcome);
        }

        [TestMethod]
        public void SampleData4()
        {
            string[] input =
            {
                @"#######",
                @"#.E...#",
                @"#.#..G#",
                @"#.###.#",
                @"#E#G#G#",
                @"#...#G#",
                @"#######",
            };

            _day15.ParseInput(input);
            _day15.RunGameToCompletion();
            Assert.AreEqual(54, _day15.Rounds);
            Assert.AreEqual(536, _day15.TotalHitPoints);
            Assert.AreEqual(28944, _day15.Outcome);
        }

        [TestMethod]
        public void SampleData5()
        {
            string[] input =
            {
                @"#########",
                @"#G......#",
                @"#.E.#...#",
                @"#..##..G#",
                @"#...##..#",
                @"#...#...#",
                @"#.G...G.#",
                @"#.....G.#",
                @"#########",
            };

            _day15.ParseInput(input);
            _day15.RunGameToCompletion();
            Assert.AreEqual(20, _day15.Rounds);
            Assert.AreEqual(937, _day15.TotalHitPoints);
            Assert.AreEqual(18740, _day15.Outcome);
        }

        [TestMethod]
        public void Part1()
        {
            _day15.ParseInput(FileReader.ReadFile("day15.txt"));
            Console.WriteLine(_day15.ToString());

            _day15.RunGameToCompletion();

            Assert.AreEqual(77, _day15.Rounds);
            Assert.AreEqual(2944, _day15.TotalHitPoints);
            Assert.AreEqual(226688, _day15.Outcome);
        }
    }
}

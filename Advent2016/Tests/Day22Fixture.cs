using System;
using System.Linq;
using Advent2016.Solutions;
using Advent2016.Utilities;
using Advent2016.Utilities.Day22;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day22Fixture
    {
        private Day22 _day22;

        [TestInitialize]
        public void Setup()
        {
            _day22 = new Day22();
        }

        
        private void TestBuildNode(string input, Day22Node result)
        {
            var node = _day22.BuildNode(input);
            Assert.AreEqual(result.Path, node.Path);
            Assert.AreEqual(result.Capacity, node.Capacity);
            Assert.AreEqual(result.Used, node.Used);
            Assert.AreEqual(result.X, node.X);
            Assert.AreEqual(result.Y, node.Y);
        }

        [TestMethod]
        public void BuildNode()
        {
            TestBuildNode(@"/dev/grid/node-x6-y7    507T  497T    10T   98%",
                new Day22Node { X = 6, Y = 7, Capacity = 507, Used = 497 });
        }

        [TestMethod]
        public void BuildNode2()
        {
            TestBuildNode(@"/dev/grid/node-x5-y15    92T   64T    28T   69%",
                new Day22Node { X = 5, Y = 15, Capacity = 92, Used = 64});
        }

        [TestMethod]
        public void BuildNetwork()
        {
            var contents = FileReader.ReadFile("day 22.txt").Skip(2).ToArray();
            var network = _day22.BuildNetwork(contents);
            Assert.AreEqual(925, network.Nodes.Count);
        }

        [TestMethod]
        public void ViablePairs()
        {
            var pairs = _day22.ViablePairs();
            Assert.AreEqual(892, pairs.Count);
        }

        private string[] _part2Sample = {
            "/dev/grid/node-x0-y0   10T    8T     2T   80%",
            "/dev/grid/node-x0-y1   11T    6T     5T   54%",
            "/dev/grid/node-x0-y2   32T   28T     4T   87%",
            "/dev/grid/node-x1-y0    9T    7T     2T   77%",
            "/dev/grid/node-x1-y1    8T    0T     8T    0%",
            "/dev/grid/node-x1-y2   11T    7T     4T   63%",
            "/dev/grid/node-x2-y0   10T    6T     4T   60%",
            "/dev/grid/node-x2-y1    9T    8T     1T   88%",
            "/dev/grid/node-x2-y2    9T    6T     3T   66%"
        };

        private string[] _part2Data = FileReader.ReadFile("day 22.txt").Skip(2).ToArray();

        [TestMethod]
        public void PrintMap()
        {
            var grid = _day22.BuildNetwork(FileReader.ReadFile("day 22.txt").Skip(2).ToArray());
            grid.Print();
        }

        [TestMethod]
        public void PrintSpaceMap()
        {
            //_day22.DrawSpaceMap(FileReader.ReadFile("day 22.txt").Skip(2).ToArray());
            _day22.DrawSpaceMap(_part2Sample);
        }

        [TestMethod]
        public void MatchedAdjacentPairs()
        {
            var pairs = _day22.ViablePairs(_part2Sample);
           // Assert.AreEqual(7, pairs.Count);

            var adjacentPairs = pairs.Where(tuple =>
            {
                var first = tuple.Item1;
                var second = tuple.Item2;

                //If one dimension varies we have constrain the other.
                return (first.X == second.X && (first.Y == second.Y + 1 || first.Y == second.Y - 1)) ||
                       (first.Y == second.Y && (first.X == second.X + 1 || first.X == second.X - 1));
            }).ToList();

            Console.WriteLine(adjacentPairs.Count());
            

        }


    }
}
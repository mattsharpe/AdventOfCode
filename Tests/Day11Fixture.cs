using System;
using System.CodeDom;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Solutions;
using AdventOfCode.Utilities.Day11;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day11Fixture
    {
        private Day11 _day11;

        [SetUp]
        public void Setup()
        {
            _day11 = new Day11();
        }

        [Test]
        public void SampleDataTest()
        {
            var result = _day11.CalculateMinimumNumberOfSteps(SampleData);
            
            Assert.AreEqual(11, result);
        }

        [Test, Explicit]
        public void Part1Test()
        {
            var result = _day11.CalculateMinimumNumberOfSteps(Part1StartState);
            
            Assert.AreEqual(47, result);
        }
        
        [Test]
        public void TupleTest()
        {
            var a = new Tuple<string,string>("a", "b");
            var b = new Tuple<string,string>("b", "a");
            Assert.AreNotEqual(a,b);
        }

        public static State SampleData => new State
        {
            ItemsOnFloor =
            {
                [0] = new List<Item>
                {
                    new Item("hydrogen", ElementType.MicroChip),
                    new Item("lithium", ElementType.MicroChip),
                },
                [1] = new List<Item>
                {
                    new Item("hydrogen", ElementType.Generator),
                },
                [2] = new List<Item>
                {
                    new Item("lithium", ElementType.Generator),
                },
                [3] = new List<Item>()
            }
        };

        //The first floor contains a polonium generator, a thulium generator, a thulium-compatible microchip, a promethium generator, a ruthenium generator, a ruthenium-compatible microchip, a cobalt generator, and a cobalt-compatible microchip.
        //The second floor contains a polonium-compatible microchip and a promethium-compatible microchip.
        //The third floor contains nothing relevant.
        //The fourth floor contains nothing relevant.
        public static State Part1StartState => new State
        {
            ItemsOnFloor =
            {
                [0] = new List<Item>
                {
                    new Item("polonium", ElementType.Generator),
                    new Item("thulium", ElementType.Generator),
                    new Item("thulium", ElementType.MicroChip),
                    new Item("promethium", ElementType.Generator),
                    new Item("ruthenium", ElementType.Generator),
                    new Item("ruthenium", ElementType.MicroChip),
                    new Item("cobalt", ElementType.Generator),
                    new Item("cobalt", ElementType.MicroChip),
                },
                [1] = new List<Item>
                {
                    new Item("polonium", ElementType.MicroChip),
                    new Item("promethium", ElementType.MicroChip),
                },
                [2] = new List<Item>(),
                [3] = new List<Item>()
            }
        };

        public static State Part2StartState => new State
        {
            ItemsOnFloor =
            {
                [0] = new List<Item>
                {
                    new Item("polonium", ElementType.Generator),
                    new Item("thulium", ElementType.Generator),
                    new Item("thulium", ElementType.MicroChip),
                    new Item("promethium", ElementType.Generator),
                    new Item("ruthenium", ElementType.Generator),
                    new Item("ruthenium", ElementType.MicroChip),
                    new Item("cobalt", ElementType.Generator),
                    new Item("cobalt", ElementType.MicroChip),
                    new Item("elerium", ElementType.Generator),
                    new Item("elerium", ElementType.MicroChip),
                    new Item("dilithium", ElementType.Generator),
                    new Item("dilithium", ElementType.MicroChip),
                },
                [1] = new List<Item>
                {
                    new Item("polonium", ElementType.MicroChip),
                    new Item("promethium", ElementType.MicroChip),
                },
                [2] = new List<Item>(),
                [3] = new List<Item>()
            }
        };

        [Test]
        public void SampleDataStartState()
        {
            var state = SampleData;
            state.PrintState();
        }

        [Test]
        public void BuildStartState()
        {
     
            var state = new State
            {
                ItemsOnFloor =
                {
                    [0] = new List<Item>
                    {
                        new Item("polonium", ElementType.Generator),
                        new Item("thulium", ElementType.Generator),
                        new Item("thulium", ElementType.MicroChip),
                        new Item("promethium", ElementType.Generator),
                        new Item("ruthenium", ElementType.Generator),
                        new Item("ruthenium", ElementType.MicroChip),
                        new Item("cobalt", ElementType.Generator),
                        new Item("cobalt", ElementType.MicroChip)
                    },
                    [1] = new List<Item>
                    {
                        new Item("polonium", ElementType.MicroChip),
                        new Item("promethium", ElementType.MicroChip)
                    },
                    [2] = new List<Item>(),
                    [3] = new List<Item>()
                }
            };
			
			state.PrintState();
        }

        [Test]
        public void GenerateNextStates()
        {
            var nextMoves = _day11.GenerateNextStates(SampleData);
            
			Assert.AreEqual(1, nextMoves.Count());
        }

        [Test]
        public void ValidState()
        {
            Assert.IsTrue(SampleData.Valid);
        }

        [Test]
        public void InvalidState()
        {
            var invalidState = new State
            {
                ItemsOnFloor =
                {
                    [0] = new List<Item>
                    {
                        new Item("hydrogen", ElementType.MicroChip),
                    },
                    [1] = new List<Item>
                    {
                        new Item("hydrogen", ElementType.Generator),
                        new Item("lithium", ElementType.MicroChip),
                    },
                    [2] = new List<Item>
                    {
                        new Item("lithium", ElementType.Generator),
                    },
                    [3] = new List<Item>()
                }
            };

            Assert.IsFalse(invalidState.Valid);
        }


        [Test]
        public void ValidStateMultipleMatchedPairs()
        {
            var state = new State
            {
                ItemsOnFloor =
                {
                    [0] = new List<Item>
                    {
                        new Item("hydrogen", ElementType.MicroChip),
                        new Item("lithium", ElementType.MicroChip),
                        new Item("hydrogen", ElementType.Generator),
                        new Item("lithium", ElementType.Generator),
                    },
                    [1] = new List<Item>(),
                    [2] = new List<Item>(),
                    [3] = new List<Item>()
                }
            };

            Assert.IsTrue(state.Valid);
        }

        [Test]
        public void IncompleteState()
        {
            Assert.IsFalse(SampleData.Complete);
        }

        [Test]
        public void CompleteState()
        {
            var completeState = new State
            {
                ItemsOnFloor =
                {
                    [0] = new List<Item>(),
                    [1] = new List<Item>(),
                    [2] = new List<Item>(),
                    [3] = new List<Item>
                    {
                        new Item("hydrogen", ElementType.MicroChip),
                        new Item("hydrogen", ElementType.Generator),
                        new Item("lithium", ElementType.MicroChip),
                        new Item("lithium", ElementType.Generator),
                    }
                }
            };

            Assert.IsTrue(completeState.Valid);
            Assert.IsTrue(completeState.Complete);
        }

        [Test]
        public void DontRevisitExploredStates()
        {
            Assert.AreEqual(0, _day11.VisitedStates.Count);
            var first = _day11.GenerateNextStates(SampleData).ToList();
            Assert.AreEqual(1, _day11.VisitedStates.Count);

            var second = first.SelectMany(x => _day11.GenerateNextStates(x)).ToList();
            Assert.AreEqual(2, _day11.VisitedStates.Count);

            var third = second.SelectMany(x => _day11.GenerateNextStates(x)).ToList();
            Assert.AreEqual(4, _day11.VisitedStates.Count);
        }
    }
}


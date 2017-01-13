using System;
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
            string[] input = {
                "The first floor contains a hydrogen-compatible microchip and a lithium-compatible microchip.",
                "The second floor contains a hydrogen generator.",
                "The third floor contains a lithium generator.",
                "The fourth floor contains nothing relevant."
            };
            var result = _day11.CalculateMinimumNumberOfSteps(SampleData);
            
            Assert.AreEqual(11, result);
        }

        [Test]
        public void TupleTest()
        {
            var a = new Tuple<string,string>("a", "b");
            var b = new Tuple<string,string>("b", "a");
            Assert.AreNotEqual(a,b);
        }

        private State SampleData => new State
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
        public void Recurse()
        {
            //we ideally want to build an ordered queue of states - each level we explore we'll get closer and further from the solution.
            // exploring those that are 'closest' first based on some heuristic would be better - scored by number of items on each floor?
            //we don't want to explore the same state multiple times. 
            Console.WriteLine(SampleData.GetHashCode());
            SampleData.PrintState();
            Console.WriteLine();
            var nextSteps = _day11.GenerateNextStates(SampleData);

            var results = new List<State>();

            foreach (var nextStep in nextSteps)
            {
                Console.WriteLine(nextStep.GetHashCode());
                nextStep.PrintState();
                Console.WriteLine();
                results.AddRange(_day11.GenerateNextStates(nextStep));
            }

            foreach (var result in results)
            {
                if (result.CurrentFloor == 0)
                {
                    Console.WriteLine(result == SampleData);
                }
                Console.WriteLine(result.GetHashCode());
                result.PrintState();
                Console.WriteLine("-----------------------");
            }
        }
    }
}

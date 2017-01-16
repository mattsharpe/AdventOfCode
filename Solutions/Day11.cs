using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Utilities.Day11;

namespace AdventOfCode.Solutions
{
/*
--- Day 11: Radioisotope Thermoelectric Generators ---

You come upon a column of four floors that have been entirely sealed off from the rest of the building except for a small dedicated lobby. There are some radiation warnings and a big sign which reads "Radioisotope Testing Facility".

According to the project status board, this facility is currently being used to experiment with Radioisotope Thermoelectric Generators (RTGs, or simply "generators") that are designed to be paired with specially-constructed microchips. Basically, an RTG is a highly radioactive rock that generates electricity through heat.

The experimental RTGs have poor radiation containment, so they're dangerously radioactive. The chips are prototypes and don't have normal radiation shielding, but they do have the ability to generate an electromagnetic radiation shield when powered. Unfortunately, they can only be powered by their corresponding RTG. An RTG powering a microchip is still dangerous to other microchips.

In other words, if a chip is ever left in the same area as another RTG, and it's not connected to its own RTG, the chip will be fried. Therefore, it is assumed that you will follow procedure and keep chips connected to their corresponding RTG when they're in the same room, and away from other RTGs otherwise.

These microchips sound very interesting and useful to your current activities, and you'd like to try to retrieve them. The fourth floor of the facility has an assembling machine which can make a self-contained, shielded computer for you to take with you - that is, if you can bring it all of the RTGs and microchips.

Within the radiation-shielded part of the facility (in which it's safe to have these pre-assembly RTGs), there is an elevator that can move between the four floors. Its capacity rating means it can carry at most yourself and two RTGs or microchips in any combination. (They're rigged to some heavy diagnostic equipment - the assembling machine will detach it for you.) As a security measure, the elevator will only function if it contains at least one RTG or microchip. The elevator always stops on each floor to recharge, and this takes long enough that the items within it and the items on that floor can irradiate each other. (You can prevent this if a Microchip and its Generator end up on the same floor in this way, as they can be connected while the elevator is recharging.)

You make some notes of the locations of each component of interest (your puzzle input). Before you don a hazmat suit and start moving things around, you'd like to have an idea of what you need to do.

When you enter the containment area, you and the elevator will start on the first floor.

For example, suppose the isolated area has the following arrangement:

The first floor contains a hydrogen-compatible microchip and a lithium-compatible microchip.
The second floor contains a hydrogen generator.
The third floor contains a lithium generator.
The fourth floor contains nothing relevant.
As a diagram (F# for a Floor number, E for Elevator, H for Hydrogen, L for Lithium, M for Microchip, and G for Generator), the initial state looks like this:

F4 .  .  .  .  .  
F3 .  .  .  LG .  
F2 .  HG .  .  .  
F1 E  .  HM .  LM 
Then, to get everything up to the assembling machine on the fourth floor, the following steps could be taken:

Bring the Hydrogen-compatible Microchip to the second floor, which is safe because it can get power from the Hydrogen Generator:

F4 .  .  .  .  .  
F3 .  .  .  LG .  
F2 E  HG HM .  .  
F1 .  .  .  .  LM 
Bring both Hydrogen-related items to the third floor, which is safe because the Hydrogen-compatible microchip is getting power from its generator:

F4 .  .  .  .  .  
F3 E  HG HM LG .  
F2 .  .  .  .  .  
F1 .  .  .  .  LM 
Leave the Hydrogen Generator on floor three, but bring the Hydrogen-compatible Microchip back down with you so you can still use the elevator:

F4 .  .  .  .  .  
F3 .  HG .  LG .  
F2 E  .  HM .  .  
F1 .  .  .  .  LM 
At the first floor, grab the Lithium-compatible Microchip, which is safe because Microchips don't affect each other:

F4 .  .  .  .  .  
F3 .  HG .  LG .  
F2 .  .  .  .  .  
F1 E  .  HM .  LM 
Bring both Microchips up one floor, where there is nothing to fry them:

F4 .  .  .  .  .  
F3 .  HG .  LG .  
F2 E  .  HM .  LM 
F1 .  .  .  .  .  
Bring both Microchips up again to floor three, where they can be temporarily connected to their corresponding generators while the elevator recharges, preventing either of them from being fried:

F4 .  .  .  .  .  
F3 E  HG HM LG LM 
F2 .  .  .  .  .  
F1 .  .  .  .  .  
Bring both Microchips to the fourth floor:

F4 E  .  HM .  LM 
F3 .  HG .  LG .  
F2 .  .  .  .  .  
F1 .  .  .  .  .  
Leave the Lithium-compatible microchip on the fourth floor, but bring the Hydrogen-compatible one so you can still use the elevator; this is safe because although the Lithium Generator is on the destination floor, you can connect Hydrogen-compatible microchip to the Hydrogen Generator there:

F4 .  .  .  .  LM 
F3 E  HG HM LG .  
F2 .  .  .  .  .  
F1 .  .  .  .  .  
Bring both Generators up to the fourth floor, which is safe because you can connect the Lithium-compatible Microchip to the Lithium Generator upon arrival:

F4 E  HG .  LG LM 
F3 .  .  HM .  .  
F2 .  .  .  .  .  
F1 .  .  .  .  .  
Bring the Lithium Microchip with you to the third floor so you can use the elevator:

F4 .  HG .  LG .  
F3 E  .  HM .  LM 
F2 .  .  .  .  .  
F1 .  .  .  .  .  
Bring both Microchips to the fourth floor:

F4 E  HG HM LG LM 
F3 .  .  .  .  .  
F2 .  .  .  .  .  
F1 .  .  .  .  .  
In this arrangement, it takes 11 steps to collect all of the objects at the fourth floor for assembly. (Each elevator stop counts as one step, even if nothing is added to or removed from it.)

In your situation, what is the minimum number of steps required to bring all of the objects to the fourth floor?


    */
    class Day11
    {
        public HashSet<State> VisitedStates = new HashSet<State>();

        public int CalculateMinimumNumberOfSteps(State input)
        {
            //first turn input into current state, which floor is lift on, where are the chips / generators
            //generate graph of availble moves, each chip / generator one floor +/- 
            //prune invald states - outside range of lift, mis matched chips 
            //find shortest distance between start and finish - Dijkstra / A* ?

            var nextLevel = GenerateNextStates(input).Distinct().ToList();
            
            for (int i = 0; i < 100; i++)
            {
                nextLevel = nextLevel.SelectMany(GenerateNextStates).Distinct().ToList();
                if (nextLevel.Any(x=>x.Complete))
                {
                    return nextLevel.Single(x => x.Complete).Depth;
                }
                Console.WriteLine($"iteration {i}, next level {nextLevel.Count}");
            }

            Console.WriteLine($"We visited {VisitedStates.Count} unique states ");
            var completed = VisitedStates.Single(x => x.Complete);
            return completed.Depth;
        }

        public IEnumerable<State> GenerateNextStates(State state)
        {
            VisitedStates.Add(state);
            

            var items = state.ItemsOnFloor[state.CurrentFloor];
            var thingsToMove = new HashSet<ItemPair>();
            foreach (var item in items)
            {
                thingsToMove.Add(new ItemPair {A = item}); //base case - we just move the one item
                foreach (var otherItem in items.Where(x=> x != item))
                {
                    //we can only move 2 chips, or 2 generators or a matching chip AND generator
                    thingsToMove.Add(new ItemPair {A = item, B = otherItem});
                }
                //TODO: what about equivalence here - Ag + Bg === Bg + Ag [DONE]
            }

            //where can we move them to?
            //for floor f +/- current floor, where f > 0 & f< 5
            //find valid floors to move to
            var floors = new List<int> {state.CurrentFloor - 1, state.CurrentFloor + 1};
            if (state.CurrentFloor == 0) floors.Remove(state.CurrentFloor - 1);
            if (state.CurrentFloor == 3) floors.Remove(state.CurrentFloor + 1);

            //if the lower floor (and all lower floors) are empty, don't move anything down in the wrong direction
            var preventDown = state.CurrentFloor == 1 && state.ItemsOnFloor[0].Count == 0 || 
                state.CurrentFloor == 2 && state.ItemsOnFloor[0].Count == 0 && state.ItemsOnFloor[1].Count == 0;

            if (preventDown)
            {
                //Console.WriteLine("removed all moves to floor " + (state.CurrentFloor-1));
                floors.Remove(state.CurrentFloor - 1);
            }

            var states = new List<State>();

            foreach (var floor in floors)
            {
                foreach (var move in thingsToMove)
                {
                    //move towards to the goal state:

                    //if I can move 2 things upstairs, don't bother only bringing one. 



                    //if I can move 1 thing downstairs, dont bother taking two.
                    //if possible pick an item that has a matching pair the floor below
                    //Console.WriteLine(move + $" to floor {floor} ");
                    var clone = state.Clone();
                    clone.MoveToFloor(move,floor);
                    
                    //prune invalid states here
                    if (clone.Valid && !VisitedStates.Contains(clone))
                    {
                        states.Add(clone);
                    }
                        
                }
            }

            

            return states;
        }

        public State GenerateStartState()
        {
            var state = new State
            {
                ItemsOnFloor =
                {
                    [0] = new List<Item>
                    {
                        new Item("polonium", ElementType.Generator),
                        new Item("thulium", ElementType.Generator),
                        new Item("promethium", ElementType.Generator),
                        new Item("ruthenium", ElementType.Generator),
                        new Item("ruthenium", ElementType.MicroChip),
                        new Item("cobalt", ElementType.Generator)
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
            
            return state;
        }
    }
}

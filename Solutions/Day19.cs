using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    class Day19
    {
        private LinkedList<Elf> _circle = new LinkedList<Elf>();
        /*
        --- Day 19: An Elephant Named Joseph ---

        The Elves contact you over a highly secure emergency channel. 
        Back at the North Pole, the Elves are busy misunderstanding White Elephant parties.

        Each Elf brings a present. They all sit in a circle, numbered starting with position 1. 
        Then, starting with the first Elf, they take turns stealing all the presents from the Elf to their left. 
        An Elf with no presents is removed from the circle and does not take turns.

        For example, with five Elves (numbered 1 to 5):

          1
        5   2
         4 3

        Elf 1 takes Elf 2's present.
        Elf 2 has no presents and is skipped.
        Elf 3 takes Elf 4's present.
        Elf 4 has no presents and is also skipped.
        Elf 5 takes Elf 1's two presents.
        Neither Elf 1 nor Elf 2 have any presents, so both are skipped.
        Elf 3 takes Elf 5's three presents.
        So, with five Elves, the Elf that sits starting in position 3 gets all the presents.

        With the number of Elves given in your puzzle input, which Elf gets all the presents?

        Your puzzle input is 3018458.

        */

        public int Simulate(int numberOfElves)
        {
            var elves = Enumerable.Repeat(1, numberOfElves).ToArray();
            
            for (int i = 0; i < elves.Length; i++)
            {
                _circle.AddLast(new Elf {Location = i + 1, Presents = 1});
            }
            //foreach elf, if elf has no presents then skip
            //else find next elf that does have presents,
            //take presents from that elf.
            //move to next elf.

            while (_circle.All(x => x.Presents != _circle.Count))
            {
                ProcessTurn();
            }

            return _circle.Single(elf => elf.Presents == _circle.Count).Location;
        }

        private void ProcessTurn()
        {
            var current = _circle.First;
            while (current != null)
            {
                if (current.Value.Presents == 0)
                {
                    current = current.Next;
                    continue;
                }

                var target = current.Next ?? _circle.First;

                while (target.Value.Presents == 0)
                {
                    target = target.Next ?? _circle.First;
                }

                current.Value.Presents += target.Value.Presents;
                target.Value.Presents = 0;
                current = current.Next;
            }
        }

        public void PrintCircle()
        {
            Console.WriteLine();

            foreach (var elf in _circle)
            {
                Console.WriteLine($"{elf.Location} : {elf.Presents}");
            }
        }

        public int Part2(int numberOfElves)
        {
            //Because Maths
            int section = (int)Math.Pow(3, (int)Math.Log(numberOfElves - 1, 3));
            int result = numberOfElves - section + Math.Max(0, numberOfElves - 2 * section);
            return result;
        }


    }

    public class Elf
    {
        public int Location { get; set; }
        public int Presents { get; set; }
    }
}

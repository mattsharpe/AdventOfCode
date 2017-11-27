using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Utilities.Day11
{
    public class State
    {
        public static string[] ItemType = {"G", "M"};
        public static string[] Elements = { "Po", "Th", "Pr", "Ru", "Co" };//, "El", "Dl"};

        public int[] Items { get; set; } = new int[Elements.Length * 2];
        public int Depth { private set; get; } = 0;

        public bool Complete => Items.All(x => x == 3);

        public int CurrentFloor { get; set; } = 0;

        
        public bool Valid
        {
            get
            {
                for (int i = 0; i < Items.Length; i += 2) //for each pair
                {
                    if (Items[i] == Items[i + 1]) continue; //if chip and gen are both present or absent, move onto the next pair
                    for (var j = 0; j < Items.Length; j += 2) //loop through all the items 
                    {
                        if (Items[j] == Items[i + 1]) //if this generator is on the same floor as another chip it's we're not valid
                            return false;
                    }
                }
                return true;
            }
        }
        
        public void MoveToFloor(ItemPair items, int destFloor)
        {
            throw new NotImplementedException();
          
        }

        public State Clone(bool incrementDepth = true)
        {
            var state = new State
            {
                CurrentFloor = CurrentFloor,
                Items = Items.ToArray()
            };
            if (incrementDepth) state.Depth = Depth + 1;
            return state;
        }

        public void PrintState()
        {
            var floors = new[] { "F1", "F2", "F3", "F4" };
            for (var i = 0; i < floors.Length; i++)
            {
                floors[i] += i == CurrentFloor ? " [E]" : " .  ";
            }
            for (var i = 0; i < Items.Length; i++)
            {
                for (var f = 0; f < floors.Length; f++)
                {
                    var type = i % 2;
                    var element = (i - type) / 2;
                    floors[f] += Items[i] == f ? " " + Elements[element] + ItemType[type] : " .  ";
                }
            }

            foreach (var floor in floors.Reverse())
            {
                Console.WriteLine(floor);
            }
        }

        protected bool Equals(State other)
        {
            return GetHashString() == other.GetHashString();
        }

        private string GetHashString()
        {
            var pairs = new List<string>();
            for (var i = 0; i < Items.Length; i += 2)
            {
                pairs.Add($"{Items[i]}{Items[i + 1]}");
            }
            return $"{CurrentFloor}{string.Join("", pairs.OrderBy(x => x))}";
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((State) obj);
        }

        public override int GetHashCode()
        {
            return GetHashString().GetHashCode();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AdventOfCode.Utilities.Day11
{
    public class State
    {
        public int Depth { private set; get; } = 0;

        public bool Complete => ItemsOnFloor[0].Count == 0 && ItemsOnFloor[1].Count == 0 && ItemsOnFloor[2].Count == 0;

        public int CurrentFloor { get; set; } = 0;

        public Dictionary<int, List<Item>> ItemsOnFloor { get; set; } = new Dictionary<int, List<Item>>();
        public bool Valid
        {
            get
            {
                //for all floors, there does not exists a MC with an unmatched generator
                return ItemsOnFloor.All(floor => 
                    !floor.Value.Exists(x => x.ElementType == ElementType.MicroChip 
                    && floor.Value.Exists(y => y.ElementType == ElementType.Generator && y.Name != x.Name) 
                    && !floor.Value.Exists(y => y.ElementType == ElementType.Generator && y.Name == x.Name)));
            }
        }
        
        public void MoveToFloor(ItemPair items, int destFloor)
        {
            if (items.A != null)
            {
                ItemsOnFloor[CurrentFloor].Remove(items.A);
                ItemsOnFloor[destFloor].Add(items.A);
            }
            if (items.B != null)
            {
                ItemsOnFloor[CurrentFloor].Remove(items.B);
                ItemsOnFloor[destFloor].Add(items.B);
            }

            CurrentFloor = destFloor;
        }

        public State Clone(bool incrementDepth = true)
        {
            var clone = new State
            {
                CurrentFloor = CurrentFloor,
                ItemsOnFloor = new Dictionary<int, List<Item>>(),
            };
            if (incrementDepth)
            {
                clone.Depth = Depth + 1;
            }
            foreach (var floor in ItemsOnFloor)
            {
                clone.ItemsOnFloor[floor.Key] = new List<Item>(floor.Value);
            }
            return clone;
        }

        public void PrintState()
        {
            var allElements = ItemsOnFloor.SelectMany(x => x.Value.Select(e => e.Name)).Distinct().OrderBy(x=>x).ToList();
            for (int i = ItemsOnFloor.Count - 1; i >= 0; i--)
            {
                Console.Write($"F{i+1} ");
                Console.Write(i == CurrentFloor ? "E  " : ".  ");

                foreach (var element in allElements)
                {
                    var elementGenerator = ItemsOnFloor[i].SingleOrDefault(x => x.Name == element && x.ElementType == ElementType.Generator);
                    var elementMicrochip = ItemsOnFloor[i].SingleOrDefault(x => x.Name == element && x.ElementType == ElementType.MicroChip);
                    
                    Console.Write(elementGenerator != null ? elementGenerator.Name.ToUpper().First() + "G " : ".  ");
                    Console.Write(elementMicrochip != null ? elementMicrochip.Name.ToUpper().First() + "M " : ".  ");
                }
                Console.WriteLine();
            }
        }

        protected bool Equals(State other)
        {

            var floorsSame = ItemsOnFloor.All(floor =>
                floor.Value.Count == other.ItemsOnFloor[floor.Key].Count &&
                new HashSet<Item>(floor.Value).SetEquals(other.ItemsOnFloor[floor.Key]));

            return CurrentFloor == other.CurrentFloor 
                && floorsSame; 
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
            int hashCode = CurrentFloor * 7;
            foreach (var floor in ItemsOnFloor)
            {
                foreach (var item in floor.Value)
                {
                    hashCode += item.GetHashCode() * 17;
                }
            }
            return hashCode;

        }
    }
}
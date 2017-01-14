using System;
using System.Collections.Generic;
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

        public State Clone()
        {
            var clone = new State
            {
                CurrentFloor = CurrentFloor,
                ItemsOnFloor = new Dictionary<int, List<Item>>(),
                Depth = Depth + 1

            };
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
    }
}
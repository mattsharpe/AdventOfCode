using System;

namespace AdventOfCode.Solutions
{
    public class Day22Node
    {
        public string Path => $"x{X}-y{Y}";
        public string Raw { get; set; }
        public int Capacity { get; set; }
        public int Used { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Space => Capacity - Used;
        public int Connections { get; set; }
        public bool HasGoalData { get; set; }

        public NodeState NodeState
        {
            get
            {
                if (Used == 0) return NodeState.Empty;
                if(X==0 && Y == 0) return NodeState.StartNode;
                if(Connections==0) return NodeState.Immovable;
                return NodeState.HasData;
            }
        }

        public override string ToString()
        {
            return $"{X},{Y}, {Used} / {Capacity}";
        }
        
    }
}
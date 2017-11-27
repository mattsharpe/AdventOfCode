namespace AdventOfCode2016.Utilities
{
    public class MazeState
    {
        public MazeState PreviousStep { get; set; }
        public MazeState(int x, int y, MazeState previous)
        {
            X = x;
            Y = y;
            Depth = previous?.Depth +1 ?? 0;
            PreviousStep = previous;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Depth { get; set; }

        protected bool Equals(MazeState other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MazeState) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString()
        {
            return X + "," + Y;
        }
    }
}
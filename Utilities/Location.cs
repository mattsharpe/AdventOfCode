namespace AdventOfCode.Utilities
{
    public class Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public static Location operator +(Location a, Location b)
        {
            return new Location(a.X + b.X, a.Y + b.Y);
        }
        public static Location operator *(Location loc, int magnitude)
        {
            return new Location(loc.X * magnitude, loc.Y * magnitude);
        }
        protected bool Equals(Location other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }
    }
}
namespace Advent2016.Utilities.Day11
{
    public class ItemPair
    {
        public Item A { get; set; }
        public Item B { get; set; }

        protected bool Equals(ItemPair other)
        {
            return (Equals(A, other.A) && Equals(B, other.B)) || 
                   (Equals(A, other.B) && Equals(B, other.A));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ItemPair) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = (A?.GetHashCode() ?? 0) * (B?.GetHashCode() ?? 0);
                return result;
            }
        }

        public override string ToString()
        {
            return A == null ? "" : A.ToString()
                                    + (B == null ? "" : "," + B.ToString());
        }
    }
}
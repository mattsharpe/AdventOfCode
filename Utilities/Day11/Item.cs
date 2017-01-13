namespace AdventOfCode.Utilities.Day11
{
    public class Item
    {
        public Item(string name, ElementType type)
        {
            Name = name;
            ElementType = type;
        }
        public string Name { get; set; }
        public ElementType ElementType { get; set; }

        public override string ToString()
        {
            return $"{Name} {(ElementType == ElementType.Generator ? "Generator" : "MicroChip")}";
        }

        protected bool Equals(Item other)
        {
            return string.Equals(Name, other.Name) && ElementType == other.ElementType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = ((Name?.GetHashCode() ?? 0)*397) ^ (int) ElementType;
                return result;
            }
        }
    }
}
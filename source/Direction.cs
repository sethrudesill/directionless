[System.Diagnostics.DebuggerDisplay("Name", Name = "{Name} ({Id})")]
public abstract class Direction : System.IComparable<Direction>, System.IEquatable<Direction>, System.IEquatable<string>, System.IEquatable<byte>, System.IEquatable<int>
{
    public static Direction Default => Cardinal.North;
    public static readonly System.Collections.Generic.IEnumerable<Direction> CardinalDirections = new System.Collections.Generic.List<Direction>() { Cardinal.North, Cardinal.East, Cardinal.South, Cardinal.West };
    public static readonly System.Collections.Generic.IEnumerable<Direction> IntercardinalDirections = new System.Collections.Generic.List<Direction>() { Intercardinal.NorthNortheast, Intercardinal.NorthNorthwest, Intercardinal.SouthSoutheast, Intercardinal.SouthSouthwest, Intercardinal.EastNortheast, Intercardinal.EastSoutheast, Intercardinal.WestNorthwest, Intercardinal.WestSouthwest };
    public static readonly System.Collections.Generic.IEnumerable<Direction> IntermediateCardinalDirections = new System.Collections.Generic.List<Direction>() { IntermediateCardinal.Northeast, IntermediateCardinal.Northwest, IntermediateCardinal.Southeast, IntermediateCardinal.Southwest, };

    public static System.Collections.Generic.IEnumerable<Direction> CycleClockwise()
    {
        yield return Cardinal.North;
        yield return Intercardinal.NorthNortheast;
        yield return IntermediateCardinal.Northeast;
        yield return Intercardinal.EastNortheast;
        yield return Cardinal.East;
        yield return Intercardinal.EastSoutheast;
        yield return IntermediateCardinal.Southeast;
        yield return Intercardinal.SouthSoutheast;
        yield return Cardinal.South;
        yield return Intercardinal.SouthSouthwest;
        yield return IntermediateCardinal.Southwest;
        yield return Intercardinal.WestSouthwest;
        yield return Cardinal.West;
        yield return Intercardinal.WestNorthwest;
        yield return IntermediateCardinal.Northwest;
        yield return Intercardinal.NorthNorthwest;
    }

    public static System.Collections.Generic.IEnumerable<Direction> CycleCounterClockwise() => System.Linq.Enumerable.Reverse(CycleClockwise());

    public static System.Collections.Generic.IEnumerable<Direction> RotateClockwise()
    {
        foreach (var direction in CycleClockwise())
            yield return direction;

        yield return System.Linq.Enumerable.First(CycleClockwise());
    }

    public static System.Collections.Generic.IEnumerable<Direction> RotateCounterClockwise()
    {
        foreach (var direction in CycleCounterClockwise())
            yield return direction;

        yield return System.Linq.Enumerable.First(CycleCounterClockwise());
    }

    protected abstract byte Id { get; }
    public abstract string Name { get; }
    public abstract Direction Inverse { get; }
    public int CompareTo(Direction other) => other?.Id.CompareTo(this.Id) ?? -1;
    public bool Equals(Direction other) => other?.GetHashCode().Equals(this.GetHashCode()) ?? false;
    public bool Equals(string name) => this.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase);
    public bool Equals(byte other) => this.Id.Equals(other);
    public bool Equals(int other) => other.Equals(this.Id);
    public override bool Equals(object obj) => (obj as Direction)?.Equals(this) ?? false;
    public override int GetHashCode() => this.Id;
    public override string ToString() => this.Name;
    public static bool operator ==(Direction left, Direction right) => left != null && right != null && left.Equals(right);
    public static bool operator !=(Direction left, Direction right) => !(left == right);

    public abstract class Cardinal : Direction
    {
        public static readonly Cardinal North = new NorthCardinal(), South = new SouthCardinal(), East = new EastCardinal(), West = new WestCardinal();
        
        private sealed class NorthCardinal : Cardinal
        {
            protected override byte Id { get; } = 0;
            public override string Name { get; } = nameof(North);
            public override Direction Inverse => South;
        }

        private sealed class SouthCardinal : Cardinal
        {
            protected override byte Id { get; } = 1;
            public override string Name { get; } = nameof(South);
            public override Direction Inverse => North;
        }

        private sealed class EastCardinal : Cardinal
        {
            protected override byte Id { get; } = 2;
            public override string Name { get; } = nameof(East);
            public override Direction Inverse => West;
        }

        private sealed class WestCardinal : Cardinal
        {
            protected override byte Id { get; } = 3;
            public override string Name { get; } = nameof(West);
            public override Direction Inverse => East;
        }
    }

    public abstract class Intercardinal : Direction
    {
        public static readonly Intercardinal NorthNortheast = new NorthNortheastIntercardinal(), NorthNorthwest = new NorthNorthwestIntercardinal(), SouthSoutheast = new SouthSoutheastIntercardinal(), SouthSouthwest = new SouthSouthwestIntercardinal(), EastNortheast = new EastNortheastIntercardinal(), EastSoutheast = new EastSoutheastIntercardinal(), WestNorthwest = new WestNorthwestIntercardinal(), WestSouthwest = new WestSouthwestIntercardinal();

        private sealed class NorthNortheastIntercardinal : Intercardinal
        {
            protected override byte Id { get; } = 4;
            public override string Name { get; } = nameof(NorthNortheast);
            public override Direction Inverse => SouthSouthwest;
        }

        private sealed class NorthNorthwestIntercardinal : Intercardinal
        {
            protected override byte Id { get; } = 5;
            public override string Name { get; } = nameof(NorthNorthwest);
            public override Direction Inverse => SouthSoutheast;
        }

        private sealed class SouthSoutheastIntercardinal : Intercardinal
        {
            protected override byte Id { get; } = 6;
            public override string Name { get; } = nameof(SouthSoutheast);
            public override Direction Inverse => NorthNorthwest;
        }

        private sealed class SouthSouthwestIntercardinal : Intercardinal
        {
            protected override byte Id { get; } = 7;
            public override string Name { get; } = nameof(SouthSouthwest);
            public override Direction Inverse => NorthNortheast;
        }

        private sealed class EastNortheastIntercardinal : Intercardinal
        {
            protected override byte Id { get; } = 8;
            public override string Name { get; } = nameof(EastNortheast);
            public override Direction Inverse => WestSouthwest;
        }

        private sealed class EastSoutheastIntercardinal : Intercardinal
        {
            protected override byte Id { get; } = 9;
            public override string Name { get; } = nameof(EastSoutheast);
            public override Direction Inverse => WestNorthwest;
        }

        private sealed class WestSouthwestIntercardinal : Intercardinal
        {
            protected override byte Id { get; } = 10;
            public override string Name { get; } = nameof(WestSouthwest);
            public override Direction Inverse => EastNortheast;
        }

        private sealed class WestNorthwestIntercardinal : Intercardinal
        {
            protected override byte Id { get; } = 11;
            public override string Name { get; } = nameof(WestNorthwest);
            public override Direction Inverse => EastSoutheast;
        }
    }

    public abstract class IntermediateCardinal : Direction
    {
        public static readonly IntermediateCardinal Northwest = new NorthwestIntermediateCardinal(), Northeast = new NortheastIntermediateCardinal(), Southwest = new SouthwestIntermediateCardinal(), Southeast = new SoutheastIntermediateCardinal();
        
        private sealed class NorthwestIntermediateCardinal : IntermediateCardinal
        {
            protected override byte Id { get; } = 12;
            public override string Name { get; } = nameof(Northwest);
            public override Direction Inverse => Southeast;
        }

        private sealed class NortheastIntermediateCardinal : IntermediateCardinal
        {
            protected override byte Id { get; } = 13;
            public override string Name { get; } = nameof(Northeast);
            public override Direction Inverse => Southwest;
        }

        private sealed class SouthwestIntermediateCardinal : IntermediateCardinal
        {
            protected override byte Id { get; } = 14;
            public override string Name { get; } = nameof(Southwest);
            public override Direction Inverse => Northeast;
        }

        private sealed class SoutheastIntermediateCardinal : IntermediateCardinal
        {
            protected override byte Id { get; } = 15;
            public override string Name { get; } = nameof(Southeast);
            public override Direction Inverse => Northwest;
        }
    }
}
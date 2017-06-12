using System;
using System.Collections.Generic;

[System.Diagnostics.DebuggerDisplay("Name", Name = "{Name} ({Id})")]
public abstract class Direction : IDirection, IComparable<Direction>, IEquatable<Direction>, IEquatable<string>, IEquatable<byte>, IEquatable<int>
{
    protected abstract byte Id { get; }
    public abstract string Name { get; }
    public abstract IDirection Inverse { get; }

    /// <summary>
    ///     Prevent outsiders from creating new types of directions.
    /// </summary>
    private Direction()
    {
        
    }    

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
    public static bool operator ==(string left, Direction right) => right?.Equals(left) ?? false;
    public static bool operator !=(string left, Direction right) => !(left == right);
    public static IEnumerable<Direction> CycleClockwise()
    {
        yield return Cardinal.North;
        yield return InterCardinal.NorthNortheast;
        yield return IntermediateCardinal.Northeast;
        yield return InterCardinal.EastNortheast;
        yield return Cardinal.East;
        yield return InterCardinal.EastSoutheast;
        yield return IntermediateCardinal.Southeast;
        yield return InterCardinal.SouthSoutheast;
        yield return Cardinal.South;
        yield return InterCardinal.SouthSouthwest;
        yield return IntermediateCardinal.Southwest;
        yield return InterCardinal.WestSouthwest;
        yield return Cardinal.West;
        yield return InterCardinal.WestNorthwest;
        yield return IntermediateCardinal.Northwest;
        yield return InterCardinal.NorthNorthwest;
    }

    public static IEnumerable<Direction> CycleCounterClockwise() => System.Linq.Enumerable.Reverse(CycleClockwise());

    public static IEnumerable<Direction> RotateClockwise()
    {
        foreach (var direction in CycleClockwise())
            yield return direction;

        yield return System.Linq.Enumerable.First(CycleClockwise());
    }

    public static IEnumerable<Direction> RotateCounterClockwise()
    {
        foreach (var direction in CycleCounterClockwise())
            yield return direction;

        yield return System.Linq.Enumerable.First(CycleCounterClockwise());
    }

    public static class Cardinal
    {
        public static Direction North { get; } = new NorthCardinal();
        public static Direction South { get; } = new SouthCardinal();
        public static Direction East { get; } = new EastCardinal();
        public static Direction West { get; } = new WestCardinal();

        public static IEnumerable<Direction> All
        {
            get
            {
                yield return North;
                yield return South;
                yield return East;
                yield return West;
            }
        }

        private sealed class NorthCardinal : Direction
        {
            protected override byte Id { get; } = 0;
            public override string Name { get; } = nameof(North);
            public override IDirection Inverse => South;
        }

        private sealed class SouthCardinal : Direction
        {
            protected override byte Id { get; } = 1;
            public override string Name { get; } = nameof(South);
            public override IDirection Inverse => North;
        }

        private sealed class EastCardinal : Direction
        {
            protected override byte Id { get; } = 2;
            public override string Name { get; } = nameof(East);
            public override IDirection Inverse => West;
        }

        private sealed class WestCardinal : Direction
        {
            protected override byte Id { get; } = 3;
            public override string Name { get; } = nameof(West);
            public override IDirection Inverse => East;
        }
    }

    public static class InterCardinal
    {
        public static Direction NorthNortheast { get; } = new NorthNortheastInterCardinal();
        public static Direction NorthNorthwest { get; } = new NorthNorthwestInterCardinal();
        public static Direction SouthSoutheast { get; } = new SouthSoutheastInterCardinal();
        public static Direction SouthSouthwest { get; } = new SouthSouthwestInterCardinal();
        public static Direction EastNortheast { get; } = new EastNortheastInterCardinal();
        public static Direction EastSoutheast { get; } = new EastSoutheastInterCardinal();
        public static Direction WestNorthwest { get; } = new WestNorthwestInterCardinal();
        public static Direction WestSouthwest { get; } = new WestSouthwestInterCardinal();

        public static IEnumerable<Direction> All
        {
            get
            {
                yield return NorthNortheast;
                yield return NorthNorthwest;
                yield return SouthSoutheast;
                yield return SouthSouthwest;
                yield return EastNortheast;
                yield return EastSoutheast;
                yield return WestNorthwest;
                yield return WestSouthwest;
            }
        }

        private sealed class NorthNortheastInterCardinal : Direction
        {
            protected override byte Id { get; } = 4;
            public override string Name { get; } = nameof(NorthNortheast);
            public override IDirection Inverse => SouthSouthwest;
        }

        private sealed class NorthNorthwestInterCardinal : Direction
        {
            protected override byte Id { get; } = 5;
            public override string Name { get; } = nameof(NorthNorthwest);
            public override IDirection Inverse => SouthSoutheast;
        }

        private sealed class SouthSoutheastInterCardinal : Direction
        {
            protected override byte Id { get; } = 6;
            public override string Name { get; } = nameof(SouthSoutheast);
            public override IDirection Inverse => NorthNorthwest;
        }

        private sealed class SouthSouthwestInterCardinal : Direction
        {
            protected override byte Id { get; } = 7;
            public override string Name { get; } = nameof(SouthSouthwest);
            public override IDirection Inverse => NorthNortheast;
        }

        private sealed class EastNortheastInterCardinal : Direction
        {
            protected override byte Id { get; } = 8;
            public override string Name { get; } = nameof(EastNortheast);
            public override IDirection Inverse => WestSouthwest;
        }

        private sealed class EastSoutheastInterCardinal : Direction
        {
            protected override byte Id { get; } = 9;
            public override string Name { get; } = nameof(EastSoutheast);
            public override IDirection Inverse => WestNorthwest;
        }

        private sealed class WestSouthwestInterCardinal : Direction
        {
            protected override byte Id { get; } = 10;
            public override string Name { get; } = nameof(WestSouthwest);
            public override IDirection Inverse => EastNortheast;
        }

        private sealed class WestNorthwestInterCardinal : Direction
        {
            protected override byte Id { get; } = 11;
            public override string Name { get; } = nameof(WestNorthwest);
            public override IDirection Inverse => EastSoutheast;
        }
    }

    public static class IntermediateCardinal
    {
        public static Direction Northwest { get; } = new NorthwestIntermediateCardinal();
        public static Direction Northeast { get; } = new NortheastIntermediateCardinal();
        public static Direction Southwest { get; } = new SouthwestIntermediateCardinal();
        public static Direction Southeast { get; } = new SoutheastIntermediateCardinal();

        public static IEnumerable<Direction> All
        {
            get
            {
                yield return IntermediateCardinal.Northeast;
                yield return IntermediateCardinal.Northwest;
                yield return IntermediateCardinal.Southeast;
                yield return IntermediateCardinal.Southwest;
            }
        }

        private sealed class NorthwestIntermediateCardinal : Direction
        {
            protected override byte Id { get; } = 12;
            public override string Name { get; } = nameof(Northwest);
            public override IDirection Inverse => Southeast;
        }

        private sealed class NortheastIntermediateCardinal : Direction
        {
            protected override byte Id { get; } = 13;
            public override string Name { get; } = nameof(Northeast);
            public override IDirection Inverse => Southwest;
        }

        private sealed class SouthwestIntermediateCardinal : Direction
        {
            protected override byte Id { get; } = 14;
            public override string Name { get; } = nameof(Southwest);
            public override IDirection Inverse => Northeast;
        }

        private sealed class SoutheastIntermediateCardinal : Direction
        {
            protected override byte Id { get; } = 15;
            public override string Name { get; } = nameof(Southeast);
            public override IDirection Inverse => Northwest;
        }
    }
}
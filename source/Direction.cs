/// <summary>
///     Private class-constructor definitions are here because they are most important. Do not change these (yet).
/// </summary>
public abstract partial class Direction : System.IComparable<Direction>, System.IEquatable<Direction>
{
    protected byte Id { get; }
    public abstract string Name { get; }
    public abstract Direction Inverse { get; }

    private Direction(byte id)
    {
        Id = id;
    }

    public abstract partial class Cardinal : Direction
    {
        public static readonly Cardinal North = new NorthCardinal(), South = new SouthCardinal(), East = new EastCardinal(), West = new WestCardinal();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Must be unique.</param>
        private Cardinal(byte id) : base(id)
        {

        }

        public sealed class NorthCardinal : Cardinal
        {
            public override string Name { get; }

            public override Direction Inverse => South;

            public NorthCardinal() : base(0)
            {
                this.Name = nameof(North);
            }
        }

        public sealed class SouthCardinal : Cardinal
        {
            public override string Name { get; }

            public override Direction Inverse => North;

            public SouthCardinal() : base(1)
            {
                this.Name = nameof(South);
            }
        }

        public sealed class EastCardinal : Cardinal
        {
            public override string Name { get; }

            public override Direction Inverse => West;

            public EastCardinal() : base(2)
            {
                this.Name = nameof(East);
            }
        }

        public sealed class WestCardinal : Cardinal
        {
            public override string Name { get; }

            public override Direction Inverse => East;

            public WestCardinal() : base(3)
            {
                this.Name = nameof(West);
            }
        }
    }

    public abstract partial class Intercardinal : Direction
    {
        internal static readonly Intercardinal NorthNortheast, NorthNorthwest, SouthSoutheast, SouthSouthwest, EastNortheast, EastSoutheast, WestNorthwest, WestSouthwest;

        static Intercardinal()
        {
            NorthNortheast = new NorthNortheastIntercardinal();
            NorthNorthwest = new NorthNorthwestIntercardinal();
            SouthSoutheast = new SouthSoutheastIntercardinal();
            SouthSouthwest = new SouthSouthwestIntercardinal();
            EastNortheast = new EastNortheastIntercardinal();
            EastSoutheast = new EastSoutheastIntercardinal();
            WestNorthwest = new WestNorthwestIntercardinal();
            WestSouthwest = new WestSouthwestIntercardinal();
        }

        private Intercardinal(byte id) : base(id)
        {

        }

        public sealed class NorthNortheastIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => SouthSouthwest;

            public NorthNortheastIntercardinal() : base(4)
            {
                this.Name = nameof(NorthNortheast);
            }
        }

        public sealed class NorthNorthwestIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => SouthSoutheast;

            public NorthNorthwestIntercardinal() : base(5)
            {
                this.Name = nameof(NorthNorthwest);
            }
        }

        public sealed class SouthSoutheastIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => NorthNorthwest;

            public SouthSoutheastIntercardinal() : base(6)
            {
                this.Name = nameof(SouthSoutheast);
            }
        }

        public sealed class SouthSouthwestIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => NorthNortheast;

            public SouthSouthwestIntercardinal() : base(7)
            {
                this.Name = nameof(SouthSouthwest);
            }
        }

        public sealed class EastNortheastIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => WestSouthwest;

            public EastNortheastIntercardinal() : base(8)
            {
                this.Name = nameof(EastNortheast);
            }
        }

        public sealed class EastSoutheastIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => WestNorthwest;

            public EastSoutheastIntercardinal() : base(9)
            {
                this.Name = nameof(EastSoutheast);
            }
        }

        public sealed class WestSouthwestIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => EastNortheast;

            public WestSouthwestIntercardinal() : base(10)
            {
                this.Name = nameof(WestSouthwest);
            }
        }

        public sealed class WestNorthwestIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => WestNorthwest;

            public WestNorthwestIntercardinal() : base(11)
            {
                this.Name = nameof(WestNorthwest);
            }
        }
    }

    public int CompareTo(Direction other) => other?.Id.CompareTo(this.Id) ?? -1;
    public bool Equals(Direction other) => other?.GetHashCode().Equals(this.GetHashCode()) ?? false;
    public override bool Equals(object obj) => (obj as Direction)?.Equals(this) ?? false;
    public override int GetHashCode() => this.Id;
    public static bool operator ==(Direction left, Direction right) => left != null && right != null && left.Equals(right);
    public static bool operator !=(Direction left, Direction right) => !(left == right);
}

/// <summary>
///     Static symbol definitions.
/// </summary>
public abstract partial class Direction
{
    public static Direction Default => Cardinal.North;

    public static readonly System.Collections.Generic.IReadOnlyList<Direction>
        CardinalDirections = new System.Collections.Generic.List<Direction>()
        {
            Cardinal.North,
            Cardinal.East,
            Cardinal.South,
            Cardinal.West
        };

    public static readonly System.Collections.Generic.IReadOnlyList<Direction>
        IntercardinalDirections = new System.Collections.Generic.List<Direction>()
        {
            Intercardinal.NorthNortheast,
            Intercardinal.NorthNorthwest,
            Intercardinal.SouthSoutheast,
            Intercardinal.SouthSouthwest,
            Intercardinal.EastNortheast,
            Intercardinal.EastSoutheast,
            Intercardinal.WestNorthwest,
            Intercardinal.WestSouthwest
        };

    /// <summary>
    ///     Starting with <see cref="Direction.Cardinal.North"/>, enumerates first to <see cref="Direction.Intercardinal.NorthNortheast"/>.
    /// </summary>
    /// <returns>A series of <see cref="Direction.Cardinal"/> and <see cref="Direction.Intercardinal"/> types.</returns>
    public static System.Collections.Generic.IEnumerable<Direction> CycleClockwise()
    {
        yield return Cardinal.North;
        yield return Intercardinal.NorthNortheast;
        yield return Intercardinal.EastNortheast;
        yield return Cardinal.East;
        yield return Intercardinal.EastSoutheast;
        yield return Intercardinal.SouthSoutheast;
        yield return Cardinal.South;
        yield return Intercardinal.SouthSouthwest;
        yield return Intercardinal.WestSouthwest;
        yield return Cardinal.West;
        yield return Intercardinal.WestNorthwest;
        yield return Intercardinal.NorthNorthwest;
        yield return Cardinal.North;
    }

    public static System.Collections.Generic.IEnumerable<Direction> CycleCounterClockwise() => System.Linq.Enumerable.Reverse(CycleClockwise());
}
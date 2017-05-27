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
        public static readonly Cardinal 
            North = new NorthCardinal(), 
            South = new SouthCardinal(), 
            East = new EastCardinal(), 
            West = new WestCardinal();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Must be unique.</param>
        private Cardinal(byte id) : base(id)
        {

        }

        private sealed class NorthCardinal : Cardinal
        {
            public override string Name { get; }

            public override Direction Inverse => South;

            public NorthCardinal() : base(0)
            {
                this.Name = nameof(North);
            }
        }

        private sealed class SouthCardinal : Cardinal
        {
            public override string Name { get; }

            public override Direction Inverse => North;

            public SouthCardinal() : base(1)
            {
                this.Name = nameof(South);
            }
        }

        private sealed class EastCardinal : Cardinal
        {
            public override string Name { get; }

            public override Direction Inverse => West;

            public EastCardinal() : base(2)
            {
                this.Name = nameof(East);
            }
        }

        private sealed class WestCardinal : Cardinal
        {
            public override string Name { get; }

            public override Direction Inverse => East;

            public WestCardinal() : base(3)
            {
                this.Name = nameof(West);
            }
        }
    }

    public abstract class Intercardinal : Direction
    {
        internal static readonly Intercardinal
            NorthNortheast = new NorthNortheastIntercardinal(),
            NorthNorthwest = new NorthNorthwestIntercardinal(),
            SouthSoutheast = new SouthSoutheastIntercardinal(),
            SouthSouthwest = new SouthSouthwestIntercardinal(),
            EastNortheast = new EastNortheastIntercardinal(),
            EastSoutheast = new EastSoutheastIntercardinal(),
            WestNorthwest = new WestNorthwestIntercardinal(),
            WestSouthwest = new WestSouthwestIntercardinal();
        
        private Intercardinal(byte id) : base(id)
        {

        }

        private sealed class NorthNortheastIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => SouthSouthwest;

            public NorthNortheastIntercardinal() : base(4)
            {
                this.Name = nameof(NorthNortheast);
            }
        }

        private sealed class NorthNorthwestIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => SouthSoutheast;

            public NorthNorthwestIntercardinal() : base(5)
            {
                this.Name = nameof(NorthNorthwest);
            }
        }

        private sealed class SouthSoutheastIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => NorthNorthwest;

            public SouthSoutheastIntercardinal() : base(6)
            {
                this.Name = nameof(SouthSoutheast);
            }
        }

        private sealed class SouthSouthwestIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => NorthNortheast;

            public SouthSouthwestIntercardinal() : base(7)
            {
                this.Name = nameof(SouthSouthwest);
            }
        }

        private sealed class EastNortheastIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => WestSouthwest;

            public EastNortheastIntercardinal() : base(8)
            {
                this.Name = nameof(EastNortheast);
            }
        }

        private sealed class EastSoutheastIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => WestNorthwest;

            public EastSoutheastIntercardinal() : base(9)
            {
                this.Name = nameof(EastSoutheast);
            }
        }

        private sealed class WestSouthwestIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => EastNortheast;

            public WestSouthwestIntercardinal() : base(10)
            {
                this.Name = nameof(WestSouthwest);
            }
        }

        private sealed class WestNorthwestIntercardinal : Intercardinal
        {
            public override string Name { get; }
            public override Direction Inverse => WestNorthwest;

            public WestNorthwestIntercardinal() : base(11)
            {
                this.Name = nameof(WestNorthwest);
            }
        }
    }

    public abstract class IntermediateCardinal : Direction
    {
        public static readonly IntermediateCardinal
            Northwest = new NorthwestIntermediateCardinal(),
            Northeast = new NortheastIntermediateCardinal(),
            Southwest = new SouthwestIntermediateCardinal(),
            Southeast = new SoutheastIntermediateCardinal();

        private IntermediateCardinal(byte id) : base(id)
        {

        }

        private sealed class NorthwestIntermediateCardinal : IntermediateCardinal
        {
            public override string Name { get; }
            public override Direction Inverse => Southeast;

            public NorthwestIntermediateCardinal() : base(12)
            {
                this.Name = nameof(Northwest);
            }
        }

        private sealed class NortheastIntermediateCardinal : IntermediateCardinal
        {
            public override string Name { get; }
            public override Direction Inverse => Southwest;

            public NortheastIntermediateCardinal() : base(13)
            {
                this.Name = nameof(Northeast);
            }
        }

        private sealed class SouthwestIntermediateCardinal : IntermediateCardinal
        {
            public override string Name { get; }
            public override Direction Inverse => Northeast;

            public SouthwestIntermediateCardinal() : base(14)
            {
                this.Name = nameof(Southwest);
            }
        }

        private sealed class SoutheastIntermediateCardinal : IntermediateCardinal
        {
            public override string Name { get; }
            public override Direction Inverse => Northeast;

            public SoutheastIntermediateCardinal() : base(15)
            {
                this.Name = nameof(Southwest);
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

    public static readonly System.Collections.Generic.IReadOnlyList<Direction>
        IntermediateCardinalDirections = new System.Collections.Generic.List<Direction>()
        {
            IntermediateCardinal.Northeast,
            IntermediateCardinal.Northwest,
            IntermediateCardinal.Southeast,
            IntermediateCardinal.Southwest,
        };

    /// <summary>
    ///     Starting with <see cref="Direction.Cardinal.North"/>, enumerates first to <see cref="Direction.Intercardinal.NorthNortheast"/>.
    /// </summary>
    /// <returns>A series of <see cref="Direction.Cardinal"/> and <see cref="Direction.Intercardinal"/> types.</returns>
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
        yield return Cardinal.North;
    }

    public static System.Collections.Generic.IEnumerable<Direction> CycleCounterClockwise() 
        => System.Linq.Enumerable.Reverse(CycleClockwise());
}
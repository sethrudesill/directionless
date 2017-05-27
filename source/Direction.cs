/// <summary>
///     Private class-constructor definitions are here because they are most important. Do not change these (yet).
/// </summary>
public abstract partial class Direction
{
    private Direction()
    {

    }

    private abstract partial class Cardinal
    {
        private Cardinal()
        {

        }
    }

    private abstract partial class Intercardinal
    {
        private Intercardinal()
        {

        }
    }
}

/// <summary>
///     Static symbol definitions.
/// </summary>
public abstract partial class Direction
{
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

    private abstract partial class Cardinal : Direction
    {
        internal static readonly Cardinal North, South, East, West;

        static Cardinal()
        {
            North = default(Cardinal);
            South = default(Cardinal);
            East = default(Cardinal);
            West = default(Cardinal);
        }
    }

    private abstract partial class Intercardinal : Direction
    {
        internal static readonly Intercardinal NorthNortheast, NorthNorthwest, SouthSoutheast, SouthSouthwest, EastNortheast, EastSoutheast, WestNorthwest, WestSouthwest;

        static Intercardinal()
        {
            NorthNortheast = default(Intercardinal);
            NorthNorthwest = default(Intercardinal);
            SouthSoutheast = default(Intercardinal);
            SouthSouthwest = default(Intercardinal);
            EastNortheast = default(Intercardinal);
            EastSoutheast = default(Intercardinal);
            WestNorthwest = default(Intercardinal);
            WestSouthwest = default(Intercardinal);
        }
    }
}
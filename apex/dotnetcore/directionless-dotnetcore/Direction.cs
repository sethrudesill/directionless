/// <summary>
///     This interface's sole purpose is to define the public API boundary so-as to avoid exposing infinite-recursion in intellisense.
/// </summary>
/// <remarks>Visual Studio 2017 Preview 15.3 cannot stand the way I am defining these things and wants this interface to be in this same file. Whatever.</remarks>
public interface IDirection
{
    /// <summary>
    ///     The primary word used to describe whatever a direction is.
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     None = 0, North = 360, East = 90, South = 180, West = 270
    /// </summary>
    ushort Ordinal { get; }
}

[System.Diagnostics.DebuggerDisplay("Name")]
public abstract class Direction : IDirection
{
    public static readonly Direction North, South, East, West;

    public string Name { get; }

    public ushort Ordinal { get; }

    /// <summary>
    ///     Exposing the inverse property prevents Visual Studio intellisense from infinitely recursing type-definitions on the Direction class.
    /// </summary>
    public abstract IDirection Reverse { get; }

    /// <summary>
    ///     Implementations cannot supply a value to <see cref="Reverse"/> because of how the compiler does or does not choose to compile static and readonly fields.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ordinal"></param>
    protected Direction(string name, ushort ordinal)
    {
        this.Name = name;
        this.Ordinal = ordinal;  
    }
    
    static Direction()
    {
        North = new Northward();
        South = new Southward();
    }

    /// <summary>
    ///     
    /// </summary>
    protected internal abstract class DirectionData : Direction
    {
        protected DirectionData(string name, ushort ordinal) : base(name, ordinal)
        {
            
        }
    }

    //protected internal sealed class None : DirectionData, IDirection
    //{
    //    public static readonly IDirection Default;

    //    static None()
    //    {
    //        Default = new None();
    //    }

    //    public override IDirection Reverse { get; }

    //    private None() : base(nameof(None), 0)
    //    {
    //        Reverse = this;
    //    }
    //}

    private sealed class Northward : DirectionData
    {
        public override IDirection Reverse => South;

        public Northward() : base(nameof(North), 360)
        {
                
        }
    }

    private sealed class Southward : DirectionData
    {
        public override IDirection Reverse => North;

        public Southward() : base(nameof(South), 180)
        {
            
        }
    }
}
//public abstract class Direction : IDirection
//{
//    /// <summary>
//    ///     Use expression-bodied-member initialization syntax for all derived types.
//    /// </summary>
//    public abstract IDirection Reverse { get; }
//}
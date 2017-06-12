using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    const int iterations = 100000;
    private static readonly List<string> results = new List<string>(iterations * 4);
    private static readonly Stopwatch castingSwitchStopwatch = new Stopwatch();
    private static readonly Stopwatch castingStopwatch = new Stopwatch();
    private static readonly Stopwatch staticDictionaryStopwatch = new Stopwatch();
    private static readonly Stopwatch enumPatternStopwatch = new Stopwatch();
    private static readonly DirectionTypes[] AllDirectionTypes;
    private static readonly Dictionary<DirectionTypes, DirectionTypes> AllDirectionTypesInversed;
    private enum DirectionTypes
    {
        North,
        Northeast,
        Northwest,
        NorthNortheast,
        NorthNorthwest,
        South,
        Southeast,
        Southwest,
        SouthSoutheast,
        SouthSouthwest,
        EastNortheast,
        EastSoutheast,
        WestNorthwest,
        WestSouthwest,
        East,
        West
    }

    static Program()
    {
        AllDirectionTypes = new DirectionTypes[]
        {
            DirectionTypes.North,
            DirectionTypes.Northeast,
            DirectionTypes.Northwest,
            DirectionTypes.NorthNortheast,
            DirectionTypes.NorthNorthwest,
            DirectionTypes.South,
            DirectionTypes.SouthSoutheast,
            DirectionTypes.SouthSouthwest,
            DirectionTypes.Southwest,
            DirectionTypes.Southeast,
            DirectionTypes.EastNortheast,
            DirectionTypes.EastSoutheast,
            DirectionTypes.WestSouthwest,
            DirectionTypes.WestNorthwest,
            DirectionTypes.East,
            DirectionTypes.West
        };

        AllDirectionTypesInversed = new Dictionary<DirectionTypes, DirectionTypes>()
        {
            {DirectionTypes.North, DirectionTypes.South},
            {DirectionTypes.Northeast, DirectionTypes.Southwest},
            {DirectionTypes.Northwest, DirectionTypes.Southeast},
            {DirectionTypes.NorthNortheast, DirectionTypes.SouthSouthwest},
            {DirectionTypes.NorthNorthwest, DirectionTypes.SouthSoutheast},
            {DirectionTypes.South, DirectionTypes.North},
            {DirectionTypes.Southeast, DirectionTypes.Northwest},
            {DirectionTypes.Southwest, DirectionTypes.Northeast},
            {DirectionTypes.SouthSoutheast, DirectionTypes.NorthNorthwest},
            {DirectionTypes.SouthSouthwest, DirectionTypes.NorthNortheast},
            {DirectionTypes.EastNortheast, DirectionTypes.WestSouthwest},
            {DirectionTypes.EastSoutheast, DirectionTypes.WestNorthwest},
            {DirectionTypes.WestNorthwest, DirectionTypes.EastSoutheast},
            {DirectionTypes.WestSouthwest, DirectionTypes.EastNortheast},
            {DirectionTypes.East, DirectionTypes.West},
            {DirectionTypes.West, DirectionTypes.East}
        };
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please wait...");

        var names = Enum.GetNames(typeof(DirectionTypes));

        castingSwitchStopwatch.Start();

        for (int i = 0; i < iterations; i++)
            foreach (var name in names)
            {
                var t = (DirectionTypes)Enum.Parse(typeof(DirectionTypes), name);
                switch (t)
                {
                    case DirectionTypes.North:
                        results.Add($"{t} -> {DirectionTypes.South}");
                        break;
                    case DirectionTypes.Northeast:
                        results.Add($"{t} -> {DirectionTypes.Southwest}");
                        break;
                    case DirectionTypes.Northwest:
                        results.Add($"{t} -> {DirectionTypes.Southeast}");
                        break;
                    case DirectionTypes.NorthNortheast:
                        results.Add($"{t} -> {DirectionTypes.SouthSouthwest}");
                        break;
                    case DirectionTypes.NorthNorthwest:
                        results.Add($"{t} -> {DirectionTypes.SouthSoutheast}");
                        break;
                    case DirectionTypes.South:
                        results.Add($"{t} -> {DirectionTypes.North}");
                        break;
                    case DirectionTypes.Southeast:
                        results.Add($"{t} -> {DirectionTypes.Northwest}");
                        break;
                    case DirectionTypes.Southwest:
                        results.Add($"{t} -> {DirectionTypes.Northeast}");
                        break;
                    case DirectionTypes.SouthSoutheast:
                        results.Add($"{t} -> {DirectionTypes.NorthNorthwest}");
                        break;
                    case DirectionTypes.SouthSouthwest:
                        results.Add($"{t} -> {DirectionTypes.NorthNortheast}");
                        break;
                    case DirectionTypes.EastNortheast:
                        results.Add($"{t} -> {DirectionTypes.WestNorthwest}");
                        break;
                    case DirectionTypes.EastSoutheast:
                        results.Add($"{t} -> {DirectionTypes.WestSouthwest}");
                        break;
                    case DirectionTypes.WestNorthwest:
                        results.Add($"{t} -> {DirectionTypes.EastSoutheast}");
                        break;
                    case DirectionTypes.WestSouthwest:
                        results.Add($"{t} -> {DirectionTypes.EastNortheast}");
                        break;
                    case DirectionTypes.East:
                        results.Add($"{t} -> {DirectionTypes.West}");
                        break;
                    case DirectionTypes.West:
                        results.Add($"{t} -> {DirectionTypes.East}");
                        break;
                }
            }

        castingSwitchStopwatch.Stop();

        castingStopwatch.Start();

        for (int i = 0; i < iterations; i++)
            foreach (var name in names)
                results.Add($"{name} -> {AllDirectionTypesInversed[(DirectionTypes)Enum.Parse(typeof(DirectionTypes), name)]}");

        castingStopwatch.Stop();

        staticDictionaryStopwatch.Start();

        for (int i = 0; i < iterations; i++)
            foreach (var direction in AllDirectionTypes)
                results.Add($"{direction} -> {AllDirectionTypesInversed[direction]}");

        staticDictionaryStopwatch.Stop();

        enumPatternStopwatch.Start();

        for (int i = 0; i < iterations; i++)
            foreach (var direction in Direction.CycleClockwise())
                results.Add($"{direction} -> {direction.Inverse}");

        enumPatternStopwatch.Stop();

        Console.Clear();
        Console.WriteLine("Inversion Matching Results{0}{1}{0}", Environment.NewLine, new string('_', 60));
        Console.WriteLine("{0} | Casting Switch", castingSwitchStopwatch.Elapsed);
        Console.WriteLine("{0} | Parse Casting", castingStopwatch.Elapsed);
        Console.WriteLine("{0} | Dictionary Lookup", staticDictionaryStopwatch.Elapsed);
        Console.WriteLine("{0} | Strongly Typed Enum Read-Only Reference Type", enumPatternStopwatch.Elapsed);
        Console.ReadKey();
    }
}
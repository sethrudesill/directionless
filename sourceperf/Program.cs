using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace sourceperf
{
    class Program
    {
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
            const int iterations = 10000;
            var castingSwitchStopwatch = new Stopwatch();
            var castingStopwatch = new Stopwatch();
            var staticDictionaryStopwatch = new Stopwatch();
            var enumPatternStopwatch = new Stopwatch();
            var names = Enum.GetNames(typeof(DirectionTypes));

            Console.WriteLine("Switch/Casting System.Enum");
            castingSwitchStopwatch.Start();
            
            for (int i = 0; i < iterations; i++)
                foreach (var name in names)
                {
                    var t = (DirectionTypes) Enum.Parse(typeof(DirectionTypes), name);
                    switch (t)
                    {
                        case DirectionTypes.North:
                            Console.WriteLine($"{t} -> {DirectionTypes.South}");
                            break;
                        case DirectionTypes.Northeast:
                            Console.WriteLine($"{t} -> {DirectionTypes.Southwest}");
                            break;
                        case DirectionTypes.Northwest:
                            Console.WriteLine($"{t} -> {DirectionTypes.Southeast}");
                            break;
                        case DirectionTypes.NorthNortheast:
                            Console.WriteLine($"{t} -> {DirectionTypes.SouthSouthwest}");
                            break;
                        case DirectionTypes.NorthNorthwest:
                            Console.WriteLine($"{t} -> {DirectionTypes.SouthSoutheast}");
                            break;
                        case DirectionTypes.South:
                            Console.WriteLine($"{t} -> {DirectionTypes.North}");
                            break;
                        case DirectionTypes.Southeast:
                            Console.WriteLine($"{t} -> {DirectionTypes.Northwest}");
                            break;
                        case DirectionTypes.Southwest:
                            Console.WriteLine($"{t} -> {DirectionTypes.Northeast}");
                            break;
                        case DirectionTypes.SouthSoutheast:
                            Console.WriteLine($"{t} -> {DirectionTypes.NorthNorthwest}");
                            break;
                        case DirectionTypes.SouthSouthwest:
                            Console.WriteLine($"{t} -> {DirectionTypes.NorthNortheast}");
                            break;
                        case DirectionTypes.EastNortheast:
                            Console.WriteLine($"{t} -> {DirectionTypes.WestNorthwest}");
                            break;
                        case DirectionTypes.EastSoutheast:
                            Console.WriteLine($"{t} -> {DirectionTypes.WestSouthwest}");
                            break;
                        case DirectionTypes.WestNorthwest:
                            Console.WriteLine($"{t} -> {DirectionTypes.EastSoutheast}");
                            break;
                        case DirectionTypes.WestSouthwest:
                            Console.WriteLine($"{t} -> {DirectionTypes.EastNortheast}");
                            break;
                        case DirectionTypes.East:
                            Console.WriteLine($"{t} -> {DirectionTypes.West}");
                            break;
                        case DirectionTypes.West:
                            Console.WriteLine($"{t} -> {DirectionTypes.East}");
                            break;
                    }
                }
            
            castingSwitchStopwatch.Stop();

            Console.WriteLine("Casting System.Enum");
            castingStopwatch.Start();
            for (int i = 0; i < iterations; i++)
                foreach (var name in names)
                    Console.WriteLine($"{name} -> {AllDirectionTypesInversed[(DirectionTypes)Enum.Parse(typeof(DirectionTypes), name)]}");

            castingStopwatch.Stop();

            Console.WriteLine("System.Enum");
            staticDictionaryStopwatch.Start();
            for (int i = 0; i < iterations; i++)
                foreach (var direction in AllDirectionTypes)
                    Console.WriteLine($"{direction} -> {AllDirectionTypesInversed[direction]}");

            staticDictionaryStopwatch.Stop();

            Console.WriteLine("Enum Pattern");
            enumPatternStopwatch.Start();
            for (int i = 0; i < iterations; i++)
                foreach (var direction in Direction.CycleClockwise())
                    Console.WriteLine($"{direction} -> {direction.Inverse}");

            enumPatternStopwatch.Stop();

            Console.Clear();
            Console.WriteLine("Switch/Casting System.Enum took {0}", castingSwitchStopwatch.Elapsed);
            Console.WriteLine("Casting/Parsing System.Enum took {0}", castingStopwatch.Elapsed);
            Console.WriteLine("Static Dictionary Lookups using System.Enum took {0}", staticDictionaryStopwatch.Elapsed);
            Console.WriteLine("Enum Pattern took {0}", enumPatternStopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}

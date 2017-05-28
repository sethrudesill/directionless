using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Direction;

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
            const int iterations = 1000;
            var castingStopwatch = new Stopwatch();
            var staticDictionaryStopwatch = new Stopwatch();
            var enumPatternStopwatch = new Stopwatch();

            Console.WriteLine("Casting System.Enum");
            castingStopwatch.Start();
            var names = Enum.GetNames(typeof(DirectionTypes));
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
                foreach (var direction in CycleClockwise())
                {
                    Console.WriteLine($"{direction} -> {direction.Inverse}");
                }
            enumPatternStopwatch.Stop();

            Console.Clear();
            Console.WriteLine("Casting/Parsing System.Enum took {0}", castingStopwatch.Elapsed);
            Console.WriteLine("Static Dictionary Lookups using System.Enum took {0}", staticDictionaryStopwatch.Elapsed);
            Console.WriteLine("Enum Pattern took {0}", enumPatternStopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}

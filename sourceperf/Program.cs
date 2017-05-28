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
            TimeSpan durationForSystemEnum;
            TimeSpan durationForEnumPattern;
            const int iterations = 100000;
            Console.WriteLine("System.Enum");
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                foreach (var direction in AllDirectionTypes)
                {
                    Console.WriteLine($"{direction} -> {AllDirectionTypesInversed[direction]}");
                }
            }
            sw.Stop();
            durationForSystemEnum = sw.Elapsed;

            Console.WriteLine("Enum Pattern");
            sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                foreach (var direction in CycleClockwise())
                {
                    Console.WriteLine($"{direction} -> {direction.Inverse}");
                }
            }
            sw.Stop();
            durationForEnumPattern = sw.Elapsed;
            Console.Clear();
            Console.WriteLine("System.Enum took {0}", durationForSystemEnum);
            Console.WriteLine("Enum Pattern took {0}", durationForEnumPattern);
            Console.ReadKey();
        }
    }
}

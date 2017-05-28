# directionless
C# 7.1 and .NET Standard 2.0 cardinal & intercardinal TypeSafeEnum. Import the nuget package, build your own dll, or reference the library directly. Once referenced, there is no namespace. Use Direction.CycleClockwise() to enumerate all of the cardinal, intercardinal, and intermediate cardinal directions.

## performance
A troll online accused this "convoluted" repository of being "magic" if it were faster than using System.Enum to perform the inverse lookup with a dictionary so now there is a crude performance test project.

The results are consistently over 50% faster in a single-threaded, single-stack process for the Enum Pattern implementation. The last execution yielded these facts:

System.Enum took 00:00:04.4541985
Enum Pattern took 00:00:02.1867595

Performance increases can potentially be stretched further by implementations which aren't trading off the performance gains for the benefit of derived-classes used purely for categoryization and sanity-checking at runtime.

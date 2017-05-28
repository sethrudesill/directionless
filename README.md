# directionless
C# 7.1 and .NET Standard 2.0 cardinal & intercardinal TypeSafeEnum. Import the nuget package, build your own dll, or reference the library directly. Once referenced, there is no namespace. Use Direction.CycleClockwise() to enumerate all of the cardinal, intercardinal, and intermediate cardinal direction. The purpose is to demonstrate that treating System.Object as a compile-time-constant by restricting signature accessibility provides several benefits:

1. Code that is safe. There is no implicit type-conversion between the protected, arbitrary "Id" value or integer
2. Equality can be verified
3. Switch statements with dangling / obsolete / neglected cases are not impossible
4. Psuedo-mutability, extensibility, and avoidance of runtime errors related to improper use of System.Enum are attainable with other design patterns such as Facade, Singleton, Decorator, Component, and Builder patterns.

# performance
Performance increases can potentially be stretched further by implementations which aren't trading off the performance gains for the benefit of derived-classes used purely for categoryization and sanity-checking at runtime. Here are the most recent results from version 2.0.1.

* Casting/Parsing System.Enum took 00:03:56.8550442
* Static Dictionary Lookups using System.Enum took 00:03:28.3953109
* Enum Pattern took 00:03:05.3879664

# maintenance
I will add more scientific analysis of the runtime performance such as garbage collection behavior in a managed runtime when the currently private sealed concrete types are exposed public (while still having a private constructor) and C# 7.0+ pattern-matching type-switching is utilized.

# directionless
C# 7.1 and .NET Standard 2.0 [cardinal & intercardinal](https://en.wikipedia.org/wiki/Cardinal_direction) [TypeSafeEnum](https://en.wikibooks.org/wiki/More_C%2B%2B_Idioms/Type_Safe_Enum). The purpose is to demonstrate that treating System.Object as a compile-time-constant by restricting signature accessibility provides several benefits:

1. Code that is safe. There is no implicit type-conversion between the protected, arbitrary "Id" value or integer
2. Equality can be verified
3. Switch statements with dangling / obsolete / neglected cases are "impossible"
4. Psuedo-mutability, extensibility, and avoidance of runtime errors related to improper use of System.Enum are attainable with other design patterns such as Facade, Singleton, Decorator, Component, and Builder patterns.

![directionless](https://github.com/sethrudesill/directionless/blob/master/directionless-type-dependency-diagram.png)

# performance
## dotnetcore/dotnetstandard 2.0
Performance increases can potentially be stretched further by implementations which aren't trading off the performance gains for the benefit of derived-classes used purely for categorization and sanity-checking at runtime. Here are the most recent results from version 2.0.1 after 1,000,000 iterations in a single-threaded, single-stack console application:

* Switch/Casting System.Enum took 00:13:54.7920955
* Casting/Parsing System.Enum took 00:17:00.8266394
* Static Dictionary Lookups using System.Enum took 00:14:53.4875283
* Enum Pattern took 00:03:37.4088701

## dotnetframework 4.5
For comparison's sake, I compiled a 'Release', non-optimized executable running 1,000,000 iterations and observed these results:

* Casting/Parsing System.Enum took 00:06:29.8809348
* Static Dictionary Lookups using System.Enum took 00:04:09.8360970
* Enum Pattern took 00:03:37.8053674

# usage
Import the nuget package, build your own dll, or reference the library directly. Once referenced, there is no namespace. Use Direction.CycleClockwise() to enumerate all of the cardinal, intercardinal, and intermediate cardinal directions. 

# maintenance
I will add more scientific analysis of the runtime performance such as garbage collection behavior in a managed runtime when the currently private sealed concrete types are exposed public (while still having a private constructor) and C# 7.0+ pattern-matching type-switching is utilized.

# controversy

![directionless-controversy](https://github.com/sethrudesill/directionless/blob/master/directionless-controversy.png)

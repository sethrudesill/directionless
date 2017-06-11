# directionless
## executive summary

My purpose is to demonstrate that putting in the upfront-effort of designing a finite, closed, categorization system using .NET's System.Object Reference Type as a compile-time-constant has significant performance benefits and code-composition clarity over the conventional usage of System.Enum (excluding use-cases for the [Flags] attribute). The initial implementation of this project was published shortly before the C# designers announced a proposal for "read-only-reference-types" which you can [learn more about on an InfoQ article published June 7th by John Allen](https://www.infoq.com/news/2017/06/CSharp-7.2).

## technical overview

By encapsulating initialization details as private, only extension-of and not mutation-of an implementation adhering to this pattern is allowed. Using C# 7.2+ and adhering to the [TypeSafeEnum](https://en.wikibooks.org/wiki/More_C%2B%2B_Idioms/Type_Safe_Enum), this repository demonstrates how the real-world, high-level representation of [cardinal & intercardinal](https://en.wikipedia.org/wiki/Cardinal_direction) can be modeled to include dangerous, potentially unsafe operations while only ever allowing one instance of a given concrete-symbol. Other "modern" programming languages (specifically Java and C++) have support for this concept of strict, deterministic interactions with nebulous domain-objects instead of using the flawed, though critical, System.Enum. Similar to those languages, this is only possible with C# 4.0+ when Expression-Bodied Members are supported by the compiler (note: only .NET 4.0 being installed should suffice, though I am not interested in seeing that proven).

![directionless](https://github.com/sethrudesill/directionless/blob/master/directionless-type-dependency-diagram.png)

## usage
Import the nuget package, build your own dll, or reference the library directly. Once referenced, there is no namespace. Use Direction.CycleClockwise() to enumerate all of the cardinal, intercardinal, and intermediate cardinal directions. 

## maintenance
I will add more scientific analysis of the runtime performance such as garbage collection behavior in a managed runtime when the currently private sealed concrete types are exposed public (while still having a private constructor) and C# 7.0+ pattern-matching type-switching is utilized.

## controversy

![directionless-controversy](https://github.com/sethrudesill/directionless/blob/master/directionless-controversy.png)

# performance metrics (naive)
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

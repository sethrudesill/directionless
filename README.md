# directionless
## executive summary

My purpose is to demonstrate that putting in the upfront-effort of designing a finite, closed, categorization system using .NET's System.Object Reference Type as a compile-time-constant has significant performance benefits and code-composition clarity over the conventional usage of System.Enum (excluding use-cases for the [Flags] attribute). The initial implementation of this project was published shortly before the C# designers announced a proposal for "read-only-reference-types" which you can [learn more about on an InfoQ article published June 7th by John Allen](https://www.infoq.com/news/2017/06/CSharp-7.2).

## technical overview

By encapsulating initialization details as private, only extension-of and not mutation-of an implementation adhering to this pattern is allowed. Using C# 7.1+ and adhering to the [TypeSafeEnum](https://en.wikibooks.org/wiki/More_C%2B%2B_Idioms/Type_Safe_Enum) pattern, this repository demonstrates how the real-world, high-level representation of [cardinal & intercardinal](https://en.wikipedia.org/wiki/Cardinal_direction) can be modeled to include dangerous, potentially unsafe operations while only ever allowing one instance of a given concrete-symbol. Using test-driven development and live-unit-testing as a guide, these "unsafe", obscure, or otherwise arcane types of logic, association, and relevancy can be proven to be self-contained and any potential failure should only occur in "extension" code (e.g.: a Decorator / Adapter object which wraps a StronglyTypedEnum and provides some new, additional behavior not anticipated by the original intent of a given library statically exposing its contact details). Other "modern" programming languages (specifically Java and C++) have support for this concept of strict, deterministic interactions with nebulous domain-objects instead of using the flawed, though critical, System.Enum. Similar to those languages, this is only possible with C# 6.0+ when Expression-Bodied Members are supported by the compiler (note: only .NET 4.0 being installed should suffice, though I am not interested in seeing that proven).

![directionless](https://github.com/sethrudesill/directionless/blob/master/directionless-type-dependency-diagram.png)

![directionless](https://github.com/sethrudesill/directionless/blob/master/directionless-code-map.png)

### performance metrics (naive)
#### dotnetcore/dotnetstandard 2.0
Version 3.0.0 results from 1,000,000 iterations

* 00:00:06.4303034 | Casting Switch
* 00:00:05.2790896 | Parse Casting
* 00:00:03.0351476 | Dictionary Lookup
* 00:00:01.4391368 | Strongly Typed Enum Read-Only Reference Type

#### dotnetframework 4.5
Who cares? Seriously.

# usage
Import the nuget package, build your own dll, or reference the library directly. Once referenced, there is no namespace. Use Direction.CycleClockwise() to enumerate all of the cardinal, intercardinal, and intermediate cardinal directions. 

## tools
As-is, Visual Studio 2017 version 15.3 Preview with the DotNetCore 2.0 SDK is required, however you can simply copy and paste the code into a new project and do whatever you want.

# maintenance
I will add more scientific analysis of the runtime performance such as garbage collection behavior in a managed runtime when the currently private sealed concrete types are exposed public (while still having a private constructor) and C# 7.0+ pattern-matching type-switching is utilized.

# controversy

![directionless-controversy](https://github.com/sethrudesill/directionless/blob/master/directionless-controversy.png)

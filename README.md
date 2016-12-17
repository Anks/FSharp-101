# F# 101

This is a series of hands-on examples that will teach you the basics of F#.

You should read the script files present in this repository in-order.

## Prerequisites

1. Make sure that you have a F# environment installed. You can install F# on [Mac][], [Linux][] and [Windows][].
2. Recommended for beginners: Install [Visual Studio Code][Code] and the [Ionide][] plugin for enabling F# development within VS Code.
   
You should be able to create a new F# script file in your editor, and evaluate it. In VS Code, this means creating a new `.fsx` file, and evaluating expressions by selecting them and pressing `Alt-Enter`.


[Mac]: http://fsharp.org/use/mac/
[Linux]: http://fsharp.org/use/linux/
[Windows]: http://fsharp.org/use/windows/
[Code]: https://code.visualstudio.com/
[Ionide]: http://ionide.io/

## Reading order

1. [01-Primitives.fsx](01-Primitives.fsx)
   
   Introduction to primitive types in F#; using `let` to create immutable variables.
   
2. [02-Functions.fsx](02-Functions.fsx)

   Using `let` to create functions; calling functions; recursion.

3. [03-ComplexTypes.fsx](03-ComplexTypes.fsx)

   Introduction to F# types: tuples, records, discriminated unions.
   
4. [04-Collections.fsx](04-Collections.fsx)

   F# collection types: lists, arrays, maps, sets.
   
5. [05-PartialApplication.fsx](05-PartialApplication.fsx)

   Currying & partial applications; pipeline operator in F#; common operations defined in the sequence module.

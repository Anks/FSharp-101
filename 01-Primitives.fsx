
(* Primitive types, and 'let' *)
// You can use 'let' to assign values to an identifier
let a = 100         // int
let b = 3.14        // float
let c = true        // boolean
let d = "Hello"     // string
let e = 'A'         // char

(*
Immutability:

'let' bindings are immutable.
You cannot modify a value once it is set.
Uncommenting the following line will give a compiler error.
*)
// let a = 101

(*
Static Typing and Type Inference

These values are strongly typed.
The compiler actually infers the type by looking at the RHS.
As a result, you don't have to manually specify it.
*)

// You can sitll specify the types of variables like this:
let f : string = "World"
let g : bool = false

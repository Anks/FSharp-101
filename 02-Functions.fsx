(*
    Functions!

    Functions are a basic building block in F#.
    You can define functions with 'let' too.
*)

let increment i =
    i + 1

// Calling a function is easy.
let two = increment 1
printfn "%d" two


let three = increment two
printfn "%d" three

let div a b =
    a / b

// printfn is a built-in function that takes the format and arguments.

(*
    Function Types:

    Notice the type signature of the function is 'int -> int'
    This indicates that it's a function that takes an int (lhs)
    and returns an int (rhs).

    We did not explicitly mention this, but the compiler still figured it out.
    Can anyone guess how?
*)

// Creating functions that take multiple arguments is easy too.
let addMod100 (a : int) (b : int) : int =
    let sum = a + b
    sum % 100

// We explicitly added type signatures here.
// When you have a multi-line function, you always return the last line.
// There is no need to add a 'return' keyword.

// Functions can also be defined as a 'lambda expression'
// This form is useful when you want to define a function on the rhs
// Example: when passing a function to another function
let increment' = fun (i : int) -> i + 1


// The 'plus' keyword here is actually a function.
// It's a special type of function called an 'infix' function,
// which is basically syntactic sugar.
// Instead of calling an infix function like this: (+ 1 2)
// You can call it like this: (1 + 2)

// You can actually call '+' like any other function like this
let total = (+) 1 2

// Since a function is like any other value,
// you can pass a function to another function, of course.
// (Contrived example)
let twice (fn : int -> int) (value : int) =
    let first = fn value
    fn first

let three' = twice increment 1

(*
    Recursion

    You need to use the `rec` keyword if your function is recursive.
*)

let rec factorial a =
    if a = 0 then
        1
    else
        a * (factorial (a - 1))

(*
    Exercises:

    1. Write a hello world function:
       Given a name, return "Hello <name>"

    2. Write a recursive function to implement
       multiplication with addition.

*)

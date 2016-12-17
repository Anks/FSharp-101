(*
    Partial application

    Partial application (currying) is a fundamental feature of the language.
    Basically, each function in F# takes exactly 1 argument, and returns 1 value.

    😱 😱 😱
*)

let increment a =
    a + 1


// Recall the add function
let add (a : int) (b : int) =
    a + b

let add' a =
    (fun b -> a + b)


(*
    The type of add is:
        int -> int -> int

    It should actually be read as:
        int -> (int -> int)
        A function that:
            - takes an integer
            - returns a function that
                - takes an integer
                - returns an integer

    What does this mean?
*)

// Partial application is passing only part of the arguments.

let add1 = add 1

// This fixes the first argument ('a') in place
// The add1 function is now a function that basically does this:
//      let add1 b = 1 + b

printfn "%d" (add1 100)

// When you call a function with 2 arguments, it's actually doing
// two function calls.

// This:
add 1 2
// is the same as
(add 1) 2

// Tuples are considered a single value
// Just due to muscle memory, you may tend to write a function like this
let compareTo (t1, t2) =
    t1 = t2

// This is a different function. It takes 1 argument, an (int * int) tuple
// and returns an integer. Look at the type signature!

// Calling this function is

compareTo (1, 2)

// Which is same as:

let t = 1, 2
compareTo t

// Another way to write it is:
let compareTo' (t : int * int) =
    let t1, t2 = t
    t1 = t2

(*
    Pipeline Operators

    The pipeline operator basically does this:

    let (|>) data fn = fn data

    It flips the order.

    (|>) 1 add1
    is the same as
    add1 1

    And since it's defined as an infix operator, you can do:

    1 |> add1

    You can now read your code left-to-right!
*)


// Pipeline lets you do this:

1
|> add1
|> add1

// You can actually use partial application along with pipeline.
1
|> add 5
|> add 6

// Pipeline lets you write your code in a 'dataflow' style.
// It's a huge win for readability.

(*
    Sequence operations

    F# defines a large number of operations on sequences / lists.
    These include your standard map / reduce / filter operations, along
    with a lot of different options.

    All sequence operators work great with the pipeline.
*)



let square x =
    x * x
let isEven x =
    (x % 2) = 0

[ 1 ; 2; 3 ; 4 ]
|> Seq.map square
|> Seq.filter isEven
|> printfn "%A"

// You can use named functions, or lambda expressions
[ 1; 2; 3; 4 ]
|> Seq.map (fun x -> x * x)
|> printfn "%A"

// There is a difference between Seq and List
// Let us add a trace to our 'isEven' function
let isEven' x =
    printfn "Checking if %d is even" x
    (x % 2) = 0


// No trace is printed
let seq = [1 ; 2; 3; 4 ] |> Seq.filter isEven'


// This would print the trace twice
printfn "%A" seq
printfn "%A" seq

// This prints the trace once
let list = [1 ; 2; 3; 4 ] |> List.filter isEven'
// Trace is not printed for any print statements
printfn "%A" list
printfn "%A" list

// List module is strict -- it will evaluate the enire list.
//
// Seq module is lazy -- which is great for performance if you
// do not use all the values.
//
// Seq is harmful if you're going to evaluate the expression twice, though

(*

    Exercises:

    1. Assuming you have a 'scale' method on shapes,
       find what happens to the area of each type of shape
       when you scale by 1, 2, 3, 4

       Does the area also scale constantly?
       Does the rate of growth change for different types of shapes?

       Do the same for perimeters.
*)

(*
    Tuples

    Tuples are a collection of values, which can be of any type themselves.
    You can create a tuple using the comma operator (',')
    Whenever you see a comma in F#, assume it's there to create a tuple.
*)

let coordinates = 5, 6
let names = "Ankit", "Solanki"
let address = "Hosur Road", "Bangalore", "Karnataka", 560068

(* 
    Tuple type signatures are something like: int * int, int * string, etc
    A '*' represents that the tuple is a 'product type'.

    For now, you can imagine it to be a type that represents the cartesion
    product of two different types.

    Explicit type declaration also works for tuples.
*)
let position : int * int = 100, 200

(*
    All tuples are defined by their base types.
    Any pair of ints (int * int) is of the same type as any other pair of ints.
    You can alias this 'raw' type with a human friendly name though.
*)
type Position = int * int
let currentPos : Position = 1, 2



(*
    Destructuring, or pulling values out of a tuple

    It is possible to get a value out of a tuple using a simple assignment operation
*)
let x, y = currentPos

// You can ignore some values if you don't care about them using '_'
let x1, _ = currentPos

// You always have to match the number of items mentioned in the tuple
// This will be a compiler error
// let locality, _ = address

(*
    Records

    Records types have named fields.
    You need to define a record before you use it (unlike typle) 
*)

type CoOrdinates = { x : int ; y : int }
// You can omit the semi-colon if you separate fields by newlines
type Contact = {
    name     : string
    address  : string
    pincode  : int
    verified : bool
}

module Contact =
    let isNotverified (c : Contact) = not c.verified



// Creating instances of a record type is very similar
let a = { x = 1 ; y = 2 }
// Compiler will automatically infer the type of the record
// based on the fields you use.
// But you can give a type annotation too.
let b : CoOrdinates = { x = 1 ; y = 2 }

let me = {
    name     = "Ankit"
    address  = "Bangalore"
    pincode  = 560068
    verified = true
}


(*
    Characteristics of records

    - Immutable. You can't update a field once you initialize it.
    - Compiler requires you to give value for all fields on initialization.
    - Automatic structural integrity comparison. 
    - Can be used as a key in a map, etc. 
 *)

// Structural equality
printfn """
a = %A
b = %A
is a == b? %A""" a b (a = b)

// If you need to modify a record, you can use a 'copy constructor'
let newCoordinates = { a with x = 5 }


// You can use records as function arguments, of course.
let incrementX (position : CoOrdinates) =
    { position with x = position.x + 1 }

incrementX a

(*
    Discriminated Unions

    These are similar to enum type in other languages.
    But much more powerful.
*)

type State =
    | Karnataka
    | UttarPradesh
    | Maharashtra
    | TamilNadu

// Usage: you can refer to the value directly
let s = Karnataka

let s2 = Karnataka

// Or by using prefixes.
let s' = State.TamilNadu

s = s2  // Equality checking is built-in


// Now, introducing the 'match' expression
// 'match' has to be exhaustive.
let stateName (state : State) : string =
    match state with
    | Karnataka    -> "Karnataka"
    | UttarPradesh -> "Uttar Pradesh"
    | Maharashtra  -> "Maharashtra"
    | TamilNadu    -> "Tamil Nadu"

printfn "%s" (stateName TamilNadu)

// Compiler will give a warning if you do not consider all cases.
// Example: add a new state to the State type

(* Discriminated unions can have associated data *)

type Shape = 
    | Square of decimal 
    | Rectangle of decimal * decimal
    | Circle of decimal

// You can create a value of this type like this:
let unitSquare : Shape = Square 1M

// One easy way to think about this is to consider 'Square'
// to be a constructor for the type 'Shape', that takes a
// decimal value and return a Shape instances.

// You can use `match` to pattern match the different cases,
// and get the associated values.
let area (shape : Shape) : decimal =
    match shape with
    | Square side                  -> side * side
    | Rectangle (length , breadth) -> length * breadth
    | Circle radius                -> 3.14M * radius * radius 

// One of the most common union types you will see is 'Option'
// Option is a built-in type.
// It represents duality: either you have a value, or no value.

// This is F#'s way to remove nulls from the language.
// Any possible function that could return null would in fact 
// return an option instead, and the compiler will force you to
// handle both the cases.a

// Even though 'Option' is built-in, we can create it very easily.

// Using ' with the name to prevent conflict with the built-in type.
// type MyOption<'T> =
//     | Some' of 'T 
//     | None'

// Example usage: load contact from db given a name.
let load (name : string) : Contact option =
    // Stub implementation
    let doesUserExist name =
        false
    
    // Stub implementation
    let loadUser name : Contact =
        {   
            name     = "A"
            address  = "A"
            pincode  = 123456
            verified = false
        }

    match (doesUserExist name) with
    | true  -> Some (loadUser name)
    | false -> None


// Using option types forces you to always make sure that 
// you handle the failure cases.

// You can do that at the edge of your system, ideally only
// a single time, instead of doing null checks throughout. 

(*
    Built-in collections in F# are lists, arrays, maps & sets.
*)

(*
    Lists: each element needs to be of the same type.
    You initialize by using square brackets, separated by semi-colon.
    Internally, this is a linked-list.
*)
let intList = [ 1 ; 2; 3; 4 ]

// Linked-list can be represented as:
// head :: tail, where
//      head is the first element
//      tail is the rest of the list (a sub-list)

// It's possible to de-construct a list like this.

let rec sum (values : int list) : int =
    match values with
    // Empty list. Sum = 0
    | [] -> 0
    // List with a single value. Sum is the value itself
    | head :: [] -> head
    // List with multiple values.
    // Sum is the head value + sum of the rest of the list.
    | head :: rest ->
        head + (sum rest)

printfn "%d" (sum intList)

(*
    Arrays. Use the pipe symbol with square brackets to create arrays.
*)

let numArray = [| 1 ; 2; 3; 4 |]

(*
    Maps: dictionary / hashtable.
    Maps use generic types for key / value types
*)

let values =  [
                1 , "One"
                2 , "Two"
                3 , "Three"
            ]

let map : Map<int, string> = Map.ofList values

// No literal syntax, but easy to create from a list or array of 2-tuple items
// Will implicitly consider first item as key, second as value.

(*
    Immutability

    F#'s default collections are immutable. Adding an item to a Map
    will create a new map (keeping the existing as-is).

    These types of data structures are often called 'Persistant Data Structures',
    especially popularised in languages like Clojure.

    They use a very optimised method to do this internally.
    Immutability gives a lot of benefits, we are not going to cover this
    in-depth for this talk. Consider this a homework assignment :)
*)

(*
    Hands-on exercises

    1. Create a full-fledged type, for representing a Contact in an address book.
       These are the requirements:
        - Name, Address fields
        - Contact can have multiple email addresses & phone numbers
        - Each email and phone number should be tagged with a type (Work, Personal, etc)
        - You can optionally mark any email or phone as the 'default'.

    2. Flesh out the 'shape' type.
         - Add a function to get perimeter of shapes.
         - Add a function that will scale up or scale down the shape
           Example: increase area by 2x, or decrease area by 2x
         - Add a new type of shape (eg: right angled triangle)
*)

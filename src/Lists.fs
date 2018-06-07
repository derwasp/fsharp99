module Lists

// Problem 1 : Find the last element of a list.

let crash() = raise (new System.NotImplementedException())

let getLast lst = lst |>  List.rev |> List.head

let rec getLastButOne lst =
    match lst with
        | [] -> failwith "The list could not be empty"
        | [x] -> failwith "The list is too short"
        | [x;y] -> x
        | head::tail -> getLastButOne tail

let elementAt k lst = 
    lst
    |> List.skip (k-1)
    |> List.head

let myLength lst = List.length lst

let reverse lst = List.rev lst

let isPalindrome lst =
     lst
    |> List.zip (lst |> List.rev)
    |> List.fold
        (fun state (f,r) -> state && f = r)
        true

let rec flatten lst =
    seq { 
            match lst with 
            | Elem x -> yield x
            | List xs-> yield! xs |> List.collect flatten
        } |> List.ofSeq

let compress lst = crash()

let pack lst = crash()

let encode lst = crash()

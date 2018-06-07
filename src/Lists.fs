module Lists

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

let compress (lst: 'a list) = 
    List.foldBack
        (fun i acc -> 
            if acc |> List.isEmpty then
                [i]
            elif i = List.head acc then
                acc
            else
                i :: acc)
        lst
        []
    
let pack lst = 
    List.foldBack
        (fun i acc ->
            match acc with
                | x::xs when i = List.head x -> (i::x)::xs
                | x -> [i]::x
        )                    
        lst
        []

let encode lst = 
    lst
    |> pack
    |> List.map (fun innerList -> innerList |> List.length, innerList |> List.head)

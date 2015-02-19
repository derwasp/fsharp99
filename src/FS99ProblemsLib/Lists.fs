namespace FS99ProblemsLib

module ListsSolutions = 

    let problem1Solver list = 
        list |> List.rev |> List.head

    let rec problem2Solver list = 
        match list with
        | [] -> failwith "The list could not be empty"
        | [x] -> failwith "The list is too short"
        | [x;y] -> x
        | head::tail -> problem2Solver tail

    let rec problem3Solver list k =
        list
        |> List.skip (k-1)
        |> List.head

    let problem4Solver list = List.length list
    let problem5Solver list = ()
    let problem6Solver list = ()
    let problem7Solver (list : NestedList<'a>)= ()
    let problem8Solver list = ()
    let problem9Solver list = ()
    let problem10Solver list = ()
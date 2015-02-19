namespace FS99ProblemsLib.Tests

open Xunit
open FsUnit.Xunit
open Swensen.Unquote

open FS99ProblemsLib.ListsSolutions

module Lists =
    [<Fact>]
    let ``Problem1Solver should find last element in the list``() =
        let list = [1;3;4]
        let actual = (problem1Solver (list))
        let expected = 4
        test <@ actual = expected @>

    [<Fact>]
    let ``Problem2Solver should find last but one element in the list``() =
        let list = [1;3;4]
        let actual = (problem2Solver (list))
        let expected = 3
        test <@ actual = expected @>

    [<Fact>]
    let ``Problem3Solver should find kth element in the list, where the first element is number 1``() =
        let list = [1;3;4]
        let k = 2
        let actual = problem3Solver list k
        let expected = 3
        test <@ actual = expected @>

    [<Fact>]
    let ``Problem4Solver should find the number of elements in the list``() = 
        let list = [1;3;4;5]
        let actual = problem4Solver list
        let expected = 4
        test <@ actual = expected @>
        
    [<Fact>]
    let ``Problem5Solver should reverse the list``() = ()

    [<Fact>]
    let ``Problem6Solver should find out whether the list is a palindrome``() = ()

    [<Fact>]
    let ``Problem7Solver should flatten the nested list structure``() = ()

    [<Fact>]
    let ``Problem8Solver should eliminate consecutive duplicates of list elements``() = ()

    [<Fact>]
    let ``Problem9Solver should pack consecutive duplicates of list elements into sublists``() = ()

    [<Fact>]
    let ``Problem10Solver should do run-length encoding of a list``() = ()

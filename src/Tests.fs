module Tests

open System
open Xunit
open Swensen.Unquote


// [snippet: (*) Problem 1 : Find the last element of a list.]
/// Example in F#: 
/// > myLast [1; 2; 3; 4];;
/// val it : int = 4
/// > myLast ['x';'y';'z'];;
/// val it : char = 'z'

[<Fact>]
let ``Lists.getLast returns last element`` () =
    let expected = 1
    let testList = [2; 3; expected]
    let actual = testList |> Lists.getLast
    test <@ expected = actual @>

// [snippet: (*) Problem 2 : Find the last but one element of a list.]
/// (Note that the Lisp transcription of this problem is incorrect.) 
///
/// Example in F#: 
/// myButLast [1; 2; 3; 4];;
/// val it : int = 3
/// > myButLast ['a'..'z'];;
/// val it : char = 'y'

[<Fact>]
let ``Lists.getLastButOne returns last but one element`` () =
    let expected = 1
    let testList = [2; expected; 3]
    let actual = testList |> Lists.getLastButOne
    test <@ expected = actual @>

// [snippet: (*) Problem 3 : Find the K'th element of a list. The first element in the list is number 1.]
/// Example: 
/// * (element-at '(a b c d e) 3)
/// c
/// 
/// Example in F#: 
/// > elementAt [1; 2; 3] 2;;
/// val it : int = 2
/// > elementAt (List.ofSeq "fsharp") 5;;
/// val it : char = 'r'
[<Fact>]
let ``Lists.elementAt returns the correct element by id`` () =
    let expected = 6
    let testList = [2;expected;12;3;8]
    let k = 2    
    let actual = 
        testList
        |> Lists.elementAt 2
    test <@ expected = actual @>

// [snippet: (*) Problem 4 : Find the number of elements of a list.]
/// Example in F#: 
/// 
/// > myLength [123; 456; 789];;
/// val it : int = 3
/// > myLength <| List.ofSeq "Hello, world!"
/// val it : int = 13 
[<Fact>]
let ``Lists.myLength calculates the number of the elements in the list`` () =
    let testList = [2;6;12;3;8]
    let expected = List.length testList
    
    let actual = testList
                 |> Lists.myLength
    test <@ expected = actual @>


// [snippet: (*) Problem 5 : Reverse a list.]
/// Example in F#: 
///
/// > reverse <| List.ofSeq ("A man, a plan, a canal, panama!")
/// val it : char list =
///  ['!'; 'a'; 'm'; 'a'; 'n'; 'a'; 'p'; ' '; ','; 'l'; 'a'; 'n'; 'a'; 'c'; ' ';
///   'a'; ' '; ','; 'n'; 'a'; 'l'; 'p'; ' '; 'a'; ' '; ','; 'n'; 'a'; 'm'; ' ';
///   'A']
/// > reverse [1,2,3,4];;
/// val it : int list = [4; 3; 2; 1]
[<Fact>]
let ``Lists.reverse reverses the list`` () =
    let testList = [2;6;12;3;8]
    let expected = List.rev testList
    
    let actual = testList
                 |> Lists.reverse
    test <@ expected = actual @>

// [snippet: (*) Problem 6 : Find out whether a list is a palindrome.]
/// A palindrome can be read forward or backward; e.g. (x a m a x).
/// 
/// Example in F#: 
/// > isPalindrome [1;2;3];;
/// val it : bool = false
/// > isPalindrome <| List.ofSeq "madamimadam";;
/// val it : bool = true
/// > isPalindrome [1;2;4;8;16;8;4;2;1];;
/// val it : bool = true
[<Fact>]
let ``Lists.isPalindrome checks whether the list is a palindrome`` () =
    let testList = List.ofSeq "madamimadam"
    let expected = true
    
    let actual = testList
                 |> Lists.isPalindrome
    test <@ expected = actual @>

// [snippet: (**) Problem 7 : Flatten a nested list structure.]
/// Transform a list, possibly holding lists as elements into a `flat' list by replacing each 
/// list with its elements (recursively).
///  
/// Example: 
/// * (my-flatten '(a (b (c d) e)))
/// (A B C D E)
///  
/// Example in F#: 
/// 
// 
///
/// > flatten (Elem 5);;
/// val it : int list = [5]
/// > flatten (List [Elem 1; List [Elem 2; List [Elem 3; Elem 4]; Elem 5]]);;
/// val it : int list = [1;2;3;4;5]
/// > flatten (List [] : int NestedList);;
/// val it : int list = []
[<Fact>]
let ``Lists.flatten Transform a nested list into a `flat' list by replacing each list with its elements (recursively)`` () =
    let testList = List [Elem 1; List [Elem 2; List [Elem 3; Elem 4]; Elem 5]]
    let expected = [1;2;3;4;5]
    
    let actual = testList
                 |> Lists.flatten
    test <@ expected = actual @>


// [snippet: (**) Problem 8 : Eliminate consecutive duplicates of list elements.] 
/// If a list contains repeated elements they should be replaced with a single copy of the 
/// element. The order of the elements should not be changed.
///  
/// Example: 
/// * (compress '(a a a a b c c a a d e e e e))
/// (A B C A D E)
///  
/// Example in F#: 
/// 
/// > compress ["a";"a";"a";"a";"b";"c";"c";"a";"a";"d";"e";"e";"e";"e"];;
/// val it : string list = ["a";"b";"c";"a";"d";"e"]
[<Fact>]
let ``Lists.compress eliminates consecutive duplicates of list elements`` () =
    let testList = ["a";"a";"a";"a";"b";"c";"c";"a";"a";"d";"e";"e";"e";"e"]
    let expected = ["a";"b";"c";"a";"d";"e"]
    
    let actual = testList
                 |> Lists.compress
    test <@ expected = actual @>

// [snippet: (**) Problem 9 : Pack consecutive duplicates of list elements into sublists.] 
/// If a list contains repeated elements they should be placed 
/// in separate sublists.
///  
/// Example: 
/// * (pack '(a a a a b c c a a d e e e e))
/// ((A A A A) (B) (C C) (A A) (D) (E E E E))
///  
/// Example in F#: 
/// 
/// > pack ['a'; 'a'; 'a'; 'a'; 'b'; 'c'; 'c'; 'a'; 
///         'a'; 'd'; 'e'; 'e'; 'e'; 'e']
/// val it : char list list =
///  [['a'; 'a'; 'a'; 'a']; ['b']; ['c'; 'c']; ['a'; 'a']; ['d'];
///   ['e'; 'e'; 'e'; 'e']]
[<Fact>]
let ``Lists.pack packs consecutive duplicates of list elements into sublists`` () =
    let testList = ['a'; 'a'; 'a'; 'a'; 'b'; 'c'; 'c'; 'a'; 'a'; 'd'; 'e'; 'e'; 'e'; 'e']
    let expected = [['a'; 'a'; 'a'; 'a'];
                    ['b'];
                    ['c'; 'c'];
                    ['a'; 'a'];
                    ['d'];
                    ['e'; 'e'; 'e'; 'e']]
    
    let actual = testList
                 |> Lists.pack
    test <@ expected = actual @>

// [snippet: (*) Problem 10 : Run-length encoding of a list.]
/// Use the result of problem P09 to implement the so-called run-length 
/// encoding data compression method. Consecutive duplicates of elements 
/// are encoded as lists (N E) where N is the number of duplicates of the element E.
///  
/// Example: 
/// * (encode '(a a a a b c c a a d e e e e))
/// ((4 A) (1 B) (2 C) (2 A) (1 D)(4 E))
///  
/// Example in F#: 
/// 
/// encode <| List.ofSeq "aaaabccaadeeee"
/// val it : (int * char) list =
///   [(4,'a');(1,'b');(2,'c');(2,'a');(1,'d');(4,'e')]
[<Fact>]
let ``Lists.encode does run-length encoding of a list`` () =
    let testList = List.ofSeq "aaaabccaadeeee"
    let expected = [(4,'a');(1,'b');(2,'c');(2,'a');(1,'d');(4,'e')]
    
    let actual = testList
                 |> Lists.encode
    test <@ expected = actual @>

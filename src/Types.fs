[<AutoOpen>]
module SharedTypes

    type 'a NestedList = List of 'a NestedList list | Elem of 'a
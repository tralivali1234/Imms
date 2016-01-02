[<AutoOpen>]
module Imms.FSharp.MoreModules

open Imms
open Imms.FSharp
open Imms.FSharp.Implementation
open Imms.FSharp.Operators
module ImmList = 
    ///Adds an element to the beginning of the collection.
    let addFirst value (collection:'elem ImmList) = collection.AddFirst(value)
    ///inserts an element at the specified index.
    let insert index value (collection :'elem ImmList) = collection.Insert(index,value)
    ///removes the element at the specified index.
    let removeAt index (collection :'elem ImmList) = collection.RemoveAt(index)
     
module ImmSet = 
    ///Returns an empty ImmSet that uses the specified equality comparer.
    let emptyWith(Eq : IEq<'elem>) = ImmSet<'elem>.Empty(Eq)
    ///Returns an empty ImmSet that uses the default equality comparer for the type.
    let empty<'v when 'v : equality> = ImmSet<'v>.Empty()
    ///Constructs an ImmSet from a sequence, using the default equality comparer for the type.
    let ofSeq (vs : seq<'k> when 'k : equality) = ImmSet.ToImmSet(vs)
    ///Constructs an ImmSet from a sequence, using the specified equality comparer.
    let ofSeqWith eq vs = ImmSet.ToImmSet(vs, eq)

module ImmOrderedSet = 
    ///Returns an empty ImmOrderedSet that uses the default comparer for the type.
    let empty<'k when 'k : comparison> = ImmOrderedSet<'k>.Empty(null)
    ///Returns an empty ImmOrderedSet that uses the specified comparer.
    let emptyWith(cm : ICmp<'elem>) = ImmOrderedSet<'elem>.Empty(cm)
    ///Constructs an ImmOrderedSet from a sequence, using the default comparer for the type.
    let ofSeq (vs : 'a seq when 'a : comparison) = ImmOrderedSet.ToImmOrderedSet(vs, null)
    ///Constructs an ImmOrderedSet from a sequence, using the specified comparer.
    let ofSeqWith cmp vs = ImmOrderedSet.ToImmOrderedSet(vs, cmp)
    ///Returns the ith element of the set, by sort order.
    let byOrder i (set : _ ImmOrderedSet) = set.ByOrder i
    ///Returns the minimal element of the set.
    let min (set : _ ImmOrderedSet) = set.MinItem
    ///Returns the maximal element of the set.
    let max (set : _ ImmOrderedSet) = set.MaxItem
    ///Removes the minimal element of the set.
    let removeMin (set :_ ImmOrderedSet) = set.RemoveMin()
    ///Removes the maximal element of the set.
    let removeMax (set :_ ImmOrderedSet) = set.RemoveMax()

module ImmMap = 
    ///Returns an empty ImmMap that uses the specified equality comparer.
    let emptyWith(eq : Eq<'key>) = ImmMap<'key,'value>.Empty(eq)
    ///Returns an empty ImmMap that uses the default equality comparer for the type.
    let empty<'key,'value when 'key : equality> = ImmMap<'key,'value>.Empty()
    ///Constructs an ImmMap from a sequence of ordered pairs, using the default equality comparer for the type.
    let ofPairsSeq (vs : seq<'key * 'value> when 'key : equality) = ImmMap.Empty() /++ (vs |> Seq.map Kvp)
    ///Constructs an ImmSet from a sequence of key-value pairs, using the default equality comparer for the type.
    let ofKvpSeq (vs : seq<Kvp<'key,'value>> when 'key : equality) = ImmMap.ToImmMap(vs)
    ///Constructs an ImmMap from a sequence of key-value pairs, using the specified equality comparer.
    let ofKvpSeqWith eq vs = ImmMap.ToImmMap(vs, eq)
    ///Constructs an ImmMap from a sequence of ordered pairs, using the specified equality comparer.
    let ofPairsSeqWith eq (vs : seq<'key * 'value>) = ImmMap.Empty(eq).AddRange(vs |> Seq.map Kvp)

module ImmOrderedMap = 
///Returns an empty ImmOrderedMap that uses the default comparer for the type.
    let empty<'key, 'value when 'key : comparison> = ImmOrderedMap<'key, 'value>.Empty(null)
    ///Returns an empty ImmOrderedMap that uses the specified comparer.
    let emptyWith(cm : Cmp<'key>) = ImmOrderedMap<'key,'value>.Empty(cm)
    ///Constructs an ImmOrderedMap from a sequence of ordered pairs, using the default comparer for the type.
    let ofPairsSeq (vs : seq<'key * 'value> when 'key : comparison) = ImmOrderedMap.Empty(null) /++ (vs |> Seq.map Kvp)
    ///Constructs an ImmOrderedMap from a sequence of key-value pairs, using the default comparer for the type.
    let ofKvpSeq (vs : seq<Kvp<'key,'value>> when 'key : comparison) = ImmOrderedMap.Empty(null) /++ (vs)
    ///Constructs an ImmOrderedMap from a sequence of key-value pairs, using the specified comparer.
    let ofKvpSeqWith cmp vs = ImmOrderedMap.ToImmOrderedMap(vs, cmp)
    ///Constructs an ImmOrderedMap from a sequence of ordered pairs, using the specified comparer.
    let ofSeqWith cmp (vs : seq<'key * 'value>) = ImmOrderedMap.Empty(cmp).AddRange(vs |> Seq.map Kvp)
    ///Returns the nth element of the map, by sort order.
    let byOrder n (map : ImmOrderedMap<_,_>) = map.ByOrder n |> Kvp.ToTuple
    ///Returns the minimal element of the map.
    let min (map : ImmOrderedMap<_,_>) = map.MinItem |> Kvp.ToTuple
    ///Returns the maximal element of the map.
    let max (map : ImmOrderedMap<_,_>) = map.MaxItem |> Kvp.ToTuple
    ///Removes the minimal element of the map.
    let removeMin (map : ImmOrderedMap<_,_>) = map.RemoveMin()
    ///Removes the maximal element of the map.
    let removeMax (map : ImmOrderedMap<_,_>) = map.RemoveMax()
    
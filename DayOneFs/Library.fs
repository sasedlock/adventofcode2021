namespace DayOneFs

module Comparer =
    let private isGreaterThan x y = 
        y > x
    
    let CountIncreasesInSequence (x : list<int>) : int = 
        let mutable count = 0
        for i in 1..x.Length - 1 do
            if isGreaterThan x.[i - 1] x.[i] then
                count <- count + 1
        count

    let CountThreeMeasurementIncreases (x : list<int>) : int = 
        let mutable count = 0
        for i in 0..x.Length - 4 do
            let firstSum = x.[i] + x.[i + 1] + x.[i + 2]
            let secondSum = firstSum - x.[i] + x.[i + 3]
            if isGreaterThan firstSum secondSum then
                count <- count + 1
        count
        


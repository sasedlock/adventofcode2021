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
        
module SubmarineCalculator = 
    let CalculateDepth (initialDepth : int) (direction : string) (movement : int) : int = 
        let newDepth = 
            if direction = "down" then
                initialDepth + movement
            elif direction = "up" then 
                initialDepth - movement
            else initialDepth
        newDepth

    let CalculateHorizontalPosition (initialPosition : int) (movement : int) : int = 
        initialPosition + movement

    let CalculateNewPosition (position : (int * int)) (movement : string) : int * int = 
        let move = movement.Split ' '
        let movementDirection = move.[0]
        let movementAmount = move.[1] |> int

        let xPosition = fst position
        let yPosition = snd position

        let newXPosition = if movementDirection = "forward" then CalculateHorizontalPosition xPosition movementAmount else xPosition
        let newYPosition = CalculateDepth yPosition movementDirection movementAmount
        (newXPosition, newYPosition)

    let CalculateNewPositionWithAim (position : (int * int * int)) (movement : string) : int * int * int = 
        let move = movement.Split ' ' 
        let movementDirection = move.[0]
        let movementAmount = move.[1] |> int

        let (xPosition, yPosition, aim) = position
        let newPosition = 
            if movementDirection = "forward" then
                (xPosition + movementAmount, yPosition + aim * movementAmount, aim)
            elif movementDirection = "up" then
                (xPosition, yPosition, aim - movementAmount)
            else 
                (xPosition, yPosition, aim + movementAmount)
        newPosition

    let CalculateTotalTravel (movements : list<string>) : int * int = 
        let mutable finalPosition = (0,0)
        for movement in movements do
            finalPosition <- CalculateNewPosition finalPosition movement
        finalPosition

    let CalculateTotalTravelWithAim (movements : list<string>) : int * int * int= 
        let mutable finalPosition = (0,0,0)
        for movement in movements do
            finalPosition <- CalculateNewPositionWithAim finalPosition movement
        finalPosition

    let ProcessDiagnosticReport (diagnosticReport : list<string>) : int = 
        let diagnosticReportLength = diagnosticReport.Length
        
        let halfDiagnosticLength = 
            if diagnosticReportLength % 2 = 0 then
                diagnosticReportLength / 2
            else  
                (diagnosticReportLength + 1) / 2

        let mutable gammaBinaryString = "0b"
        let mutable epsilonBinaryString = "0b"
        let lengthOfEachElement = diagnosticReport.Head.Length

        for i in 0..lengthOfEachElement - 1 do 
            let mutable columnSum = 0
            for element in diagnosticReport do
                let cellValueChar = element.[i]
                let cellValue = cellValueChar |> sprintf "%c" |> int
                columnSum <- columnSum + cellValue
            if columnSum > halfDiagnosticLength then 
                gammaBinaryString <- gammaBinaryString + "1"
                epsilonBinaryString <- epsilonBinaryString + "0"
            else 
                gammaBinaryString <- gammaBinaryString + "0"
                epsilonBinaryString <- epsilonBinaryString + "1"
            columnSum <- 0

        printfn "%s" gammaBinaryString
        let gammaInt = gammaBinaryString |> int
        let epsilonInt = epsilonBinaryString |> int
        gammaInt * epsilonInt

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

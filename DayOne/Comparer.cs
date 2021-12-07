namespace DayOne;
public static class Comparer
{
    public static bool IsGreaterThan(int one, int two) {
        return two > one;
    }

    public static int CountIncreasesInArray(int[] input) {
        int result = 0;
        
        if (input.Length == 0 || input.Length == 1) {
            return result;
        }

        for (int i = 1; i < input.Length; i++) {
            if (IsGreaterThan(input[i-1],input[i])) {
                result++;
            }
        }

        return result;
    }

    public static int CountThreeMeasurementIncreasesInArray(int[] input) {
        int result = 0;

        for (int i = 0; i <= input.Length - 4; i++) {
            int firstSum = input[i] + input[i + 1] + input[i + 2];
            int secondSum = firstSum - input[i] + input[i + 3];
            if (IsGreaterThan(firstSum, secondSum)) {
                result++;
            }
        }

        return result;
    }
}

public static class SubmarineCalculator
{
    public static int CalculateDepth(int initialDepth, string direction, int movement) {
        int newDepth = initialDepth;

        if (direction == "down") {
            newDepth = initialDepth + movement;
        } else if (direction == "up") {
            newDepth = initialDepth - movement;
        }

        return newDepth;
    }

    public static int CalculateHorizontalPosition(int initialPosition, int movement) {
        return initialPosition + movement;
    }

    public static (int, int) CalculateNewPosition((int x, int y) position, string move) {
        string[] movement = move.Split(" ");
        string movementDirection = movement[0];
        int movementAmount = int.Parse(movement[1]);

        (int x, int y) newPosition = position;

        if (movementDirection == "forward") {
            newPosition.x = CalculateHorizontalPosition(position.x, movementAmount);
        } else {
            newPosition.y = CalculateDepth(position.y, movementDirection, movementAmount);
        }

        return newPosition;
    }

    public static (int, int) CalculateTotalTravel(string[] movements) {
        (int, int) finalPosition = (0,0);

        foreach(string movement in movements) {
            finalPosition = CalculateNewPosition(finalPosition, movement);
        }

        return finalPosition;
    }
}
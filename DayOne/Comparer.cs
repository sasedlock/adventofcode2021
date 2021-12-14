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

    public static int CalculateOxygenGeneratorRating(string[] diagnosticReport) {
        string[] oxygenRatingArray = diagnosticReport;
        int indexToCheck = 0;
        int lengthToNotExceed = oxygenRatingArray.FirstOrDefault().Length;

        while (oxygenRatingArray.Length > 1 && indexToCheck < lengthToNotExceed) {
            List<string> ListOfOnes = new List<string>();
            List<string> ListOfZeros = new List<string>();

            Console.WriteLine($"Using index {indexToCheck} to check");

            foreach(string row in oxygenRatingArray) {
                Console.WriteLine(row);
                if (row[indexToCheck] == 1) {
                    ListOfOnes.Add(row);
                } else {
                    ListOfZeros.Add(row);
                }
            }

            int listOfOnesCount = ListOfOnes.Count;
            int listOfZerosCount = ListOfZeros.Count;

            if (listOfOnesCount >= listOfZerosCount) {
                Console.WriteLine("1's won");
                oxygenRatingArray = ListOfOnes.ToArray();
            } else {
                Console.WriteLine("0's won");
                oxygenRatingArray = ListOfZeros.ToArray();
            }

            indexToCheck++;
        }

        return 1;
    }
}
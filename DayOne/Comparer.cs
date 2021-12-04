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

        for (int i = 0; i < input.Length - 3; i++) {
            int firstSum = input[i] + input[i + 1] + input[i + 2];
            Console.WriteLine(firstSum);
            int secondSum = firstSum - input[i] + input[i + 3];
            Console.WriteLine(secondSum);
            if (IsGreaterThan(firstSum, secondSum)) {
                result++;
            }
        }

        return result;
    }
}

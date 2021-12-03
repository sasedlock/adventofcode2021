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
}

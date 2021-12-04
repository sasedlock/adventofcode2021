using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayOne;

namespace DayOneTest;

[TestClass]
public class DayOneUnitTests
{
    [TestMethod]
    public void ComparerReturnsTrueWhenSecondParameterIsGreaterThan()
    {
        int[] input = { 199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263};

        int input1 = 1;
        int input2 = 2;

        bool result = Comparer.IsGreaterThan(input1, input2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ComparerCountsExpectedIncreasesWhenAllIncreasing()
    {
        // int[] input = { 199,
        //         200,
        //         208,
        //         210,
        //         200,
        //         207,
        //         240,
        //         269,
        //         260,
        //         263};

        int[] input = {1,2,3};

        int result = Comparer.CountIncreasesInArray(input);
        Assert.AreEqual(2, result);
    }

 [TestMethod]
    public void ComparerCountsExpectedIncreasesFromTestInput()
    {
        int[] input = { 199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263};

        int result = Comparer.CountIncreasesInArray(input);
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void ComparerReturnsZeroIfArrayEmpty(){
        int[] input = {};
        Assert.AreEqual(0, Comparer.CountIncreasesInArray(input));
    }

    [TestMethod]
    public void ComparerReturnsZeroIfArrayHasOnlyOneElement(){
        int[] input = {1};
        Assert.AreEqual(0, Comparer.CountIncreasesInArray(input));
    }
}
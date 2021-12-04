namespace DayOneFsTest

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open DayOneFs

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        Assert.IsTrue(true);

    [<TestMethod>]
    member this.ComparerCountsExpectedIncreasesFromTestInput () =
        let input = [ 199;
            200;
            208;
            210;
            200;
            207;
            240;
            269;
            260;
            263]
        let expected = 7
        let actual = Comparer.CountIncreasesInSequence input
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.ComparerCountsExpectedIncreasesWhenAllIncreasing () =
        let expected = 2
        let actual = Comparer.CountIncreasesInSequence [1;2;3]
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.ComparerReturnsZeroIfArrayHasOnlyOneElement () =
        let expected = 0
        let actual = Comparer.CountIncreasesInSequence []
        Assert.AreEqual(expected, actual)
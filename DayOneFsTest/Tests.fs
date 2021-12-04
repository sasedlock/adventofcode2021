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
    member this.ComparerCountsExpectedIncreasesWhenAllIncreasing () =
        let expected = 2
        let actual = Comparer.CountIncreasesInSequence [1;2;3]
        Assert.AreEqual(expected, actual)
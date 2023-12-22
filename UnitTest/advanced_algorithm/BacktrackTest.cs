using algorithm_pattern.advanced_algorithm.Backtrack;

namespace UnitTest.advanced_algorithm;

public class BacktrackTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SubsetsTest()
    {
        var result = new Backtrack_Subsets().Subsets(new int[] { 1, 2, 3 });
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int>
            {
                Capacity = 0
            },
            new List<int> { 1 },
            new List<int> { 2 },
            new List<int> { 1, 2 },
            new List<int> { 3 },
            new List<int> { 1, 3 },
            new List<int> { 2, 3 },
            new List<int> { 1, 2, 3 },
        }, result);
    }

    [Test]
    public void SubsetsTest_2()
    {
        var result = new Backtrack_Subsets().Subsets(new int[] { 0 });
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int>
            {
                Capacity = 0
            },
            new List<int> { 0 },
        }, result);
    }

    [Test]
    public void SubsetsWithDupTest()
    {
        var result = new Backtrack_SubsetsWithDup().SubsetsWithDup(new int[] { 1, 2, 2 });
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int>
            {
                Capacity = 0
            },
            new List<int> { 1 },
            new List<int> { 1, 2 },
            new List<int> { 1, 2, 2 },
            new List<int> { 2 },
            new List<int> { 2, 2 },
        }, result);
    }

    [Test]
    public void SubsetsWithDupTest_2()
    {
        var result = new Backtrack_SubsetsWithDup().SubsetsWithDup(new int[] { 0 });
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int>
            {
                Capacity = 0
            },
            new List<int> { 0 },
        }, result);
    }

    [Test]
    public void PermuteTest()
    {
        var result = new Backtrack_Permute().Permute(new int[] { 1, 2, 3 });
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 1, 3, 2 },
            new List<int> { 2, 1, 3 },
            new List<int> { 2, 3, 1 },
            new List<int> { 3, 1, 2 },
            new List<int> { 3, 2, 1 }
        }, result);
    }

    [Test]
    public void PermuteTest_2()
    {
        var result = new Backtrack_Permute().Permute(new int[] { 0, 1 });
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int> { 0, 1 },
            new List<int> { 1, 0 }
        }, result);
    }

    [Test]
    public void PermuteTest_3()
    {
        var result = new Backtrack_Permute().Permute(new int[] { 1 });
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int> { 1 }
        }, result);
    }


    [Test]
    public void PermuteUniqueTest()
    {
        var result = new Backtrack_PermuteUnique().PermuteUnique(new int[] { 1, 1, 2 });
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int> { 1, 1, 2 },
            new List<int> { 1, 2, 1 },
            new List<int> { 2, 1, 1 }
        }, result);
    }

    [Test]
    public void PermuteUniqueTest_2()
    {
        var result = new Backtrack_PermuteUnique().PermuteUnique(new int[] { 1, 2, 3 });
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 1, 3, 2 },
            new List<int> { 2, 1, 3 },
            new List<int> { 2, 3, 1 },
            new List<int> { 3, 1, 2 },
            new List<int> { 3, 2, 1 }
        }, result);
    }

    [Test]
    public void CombinationSumTest()
    {
        var result = new Backtrack_CombinationSum().CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int> { 2, 2, 3 },
            new List<int> { 7 }
        }, result);
    }

    [Test]
    public void CombinationSumTest_2()
    {
        var result = new Backtrack_CombinationSum().CombinationSum(new int[] { 2, 3, 5 }, 8);
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            new List<int> { 2, 2, 2, 2 },
            new List<int> { 2, 3, 3 },
            new List<int> { 3, 5 }
        }, result);
    }

    [Test]
    public void CombinationSumTest_3()
    {
        var result = new Backtrack_CombinationSum().CombinationSum(new int[] { 2 }, 1);
        CollectionAssert.AreEquivalent(new List<List<int>>
        {
            Capacity = 0
        }, result);
    }

    [Test]
    public void LetterCombinationsTest()
    {
        var result = new Backtrack_LetterCombinations().LetterCombinations("23");
        CollectionAssert.AreEquivalent(new List<string>
        {
            "ad",
            "ae",
            "af",
            "bd",
            "be",
            "bf",
            "cd",
            "ce",
            "cf"
        }, result);
    }

    [Test]
    public void LetterCombinationsTest_2()
    {
        var result = new Backtrack_LetterCombinations().LetterCombinations("");
        CollectionAssert.AreEquivalent(new List<string>
        {
            Capacity = 0
        }, result);
    }

    [Test]
    public void LetterCombinationsTest_3()
    {
        var result = new Backtrack_LetterCombinations().LetterCombinations("2");
        CollectionAssert.AreEquivalent(new List<string>
        {
            "a",
            "b",
            "c"
        }, result);
    }
}